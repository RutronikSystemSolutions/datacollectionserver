using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace datacollectionserver
{
    public class DataCollector
    {
        public enum SampleType
        {
            SampleTypeShort,
            SampleTypeFloat
        }

        public enum ConnectionState
        {
            Iddle,
            Connected,
            WaitingData,
            CollectingData,
            Error,
            StartNew
        };

        public delegate void OnNewConnectionStateEventHandler(ConnectionState state, string lastError);
        public event OnNewConnectionStateEventHandler? OnNewConnectionState;

        public delegate void OnNewPacketEventHandler(byte[] packet, int samplesPerPacket, SampleType sampleType);
        public event OnNewPacketEventHandler? OnNewPacket;

        public delegate void OnNewRecordingEventHandler(List<byte[]> recording, int samplesPerPacket, SampleType sampleType);
        public event OnNewRecordingEventHandler? OnNewRecording;

        private SampleType sampleType = SampleType.SampleTypeShort;
        private int samplesPerPacket = 1;

        private SerialPort? port = null;
        private BackgroundWorker? worker = null;

        private const int WORKER_PROGRESS_NEW_PACKET = 0;
        private const int WORKER_PROGRESS_NEW_RECORDING = 1;
        private const int WORKER_PROGRESS_NEW_STATUS = 2;
        private const int WORKER_PROGRESS_START_NEW = 3;

        /// <summary>
        /// Defines how much packets need to be dropped at start (to avoid to "hear" the button click)
        /// </summary>
        private const int packetsAtStartToDrop = 10;

        public static int GetElementSizeByType(SampleType sampleType)
        {
            switch(sampleType)
            {
                case SampleType.SampleTypeShort:
                    return 2;
                case SampleType.SampleTypeFloat:
                    return 4;
            }
            return 2;
        }

        public void StartCollecting(string portName, int baudRate, SampleType sampleType, int samplesPerPacket)
        {
            this.sampleType = sampleType;
            this.samplesPerPacket = samplesPerPacket;

            try
            {
                port = new SerialPort
                {
                    BaudRate = baudRate,
                    DataBits = 8,
                    Handshake = Handshake.None,
                    Parity = Parity.None,
                    PortName = portName,
                    StopBits = StopBits.One,
                    ReadTimeout = 500,
                    WriteTimeout = 2000
                };
                port.Open();
            }
            catch(Exception ex)
            {
                OnNewConnectionState?.Invoke(ConnectionState.Error, ex.ToString());
                return;
            }

            OnNewConnectionState?.Invoke(ConnectionState.Connected, string.Empty);

            CreateAndStartBackgroundWorker();
        }

        public void Stop()
        {
            if (worker != null) worker.CancelAsync();
        }

        private void CreateAndStartBackgroundWorker()
        {
            if (worker != null)
            {
                worker.CancelAsync();
            }

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void Worker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            OnNewConnectionState?.Invoke(ConnectionState.Iddle, string.Empty);
        }

        private void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            if (sender == null) return;
            if (port == null) return;

            BackgroundWorker worker = (BackgroundWorker)sender;

            int elementSizeByte = GetElementSizeByType(sampleType);
            int packetSize = elementSizeByte * samplesPerPacket;

            for (; ; )
            {
                if (worker.CancellationPending)
                {
                    try
                    {
                        port.Close();
                    }
                    catch (Exception) { }
                    return;
                }

                // Flush
                try
                {
                    port.ReadExisting();
                }
                catch (Exception) { }

                long lastReadPacketTimestamp = 0;
                //int remainingToDrop = packetsAtStartToDrop;
                int remainingToDrop = 0;

                List<byte[]> recording = new List<byte[]>();

                worker.ReportProgress(WORKER_PROGRESS_NEW_STATUS, ConnectionState.WaitingData);

                // Wait until something available
                for(; ;)
                {
                    if (worker.CancellationPending)
                    {
                        try
                        {
                            port.Close();
                        }
                        catch (Exception) { }
                        return;
                    }

                    if (port.BytesToRead > 0)
                    {
                        worker.ReportProgress(WORKER_PROGRESS_NEW_STATUS, ConnectionState.StartNew);
                        break;
                    }
                }

                for (; ; )
                {
                    if (worker.CancellationPending)
                    {
                        try
                        {
                            port.Close();
                        }
                        catch (Exception) { }
                        return;
                    }

                    // Wait for enough data
                    if (port.BytesToRead >= packetSize)
                    {
                        if (lastReadPacketTimestamp == 0)
                        {
                            worker.ReportProgress(WORKER_PROGRESS_NEW_STATUS, ConnectionState.CollectingData);
                        }

                        byte[] readBuffer = new byte[packetSize];
                        int toRead = packetSize;
                        int offset = 0;

                        // Get the answer
                        while (toRead > 0)
                        {
                            int r = port.Read(readBuffer, offset, toRead);
                            offset += r;
                            toRead -= r;
                        }

                        if (remainingToDrop == 0)
                        {
                            worker.ReportProgress(WORKER_PROGRESS_NEW_PACKET, readBuffer);
                            recording.Add(readBuffer);
                        }
                        else
                        {
                            remainingToDrop--;
                        }
                        lastReadPacketTimestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    }
                    else if (lastReadPacketTimestamp != 0)
                    {
                        long timeDiff = DateTimeOffset.Now.ToUnixTimeMilliseconds() - lastReadPacketTimestamp;
                        if (timeDiff > 500)
                        {
                            worker.ReportProgress(WORKER_PROGRESS_NEW_RECORDING, recording);
                            break;
                        }
                        Thread.Sleep(100);
                    }
                }
            }
        }

        private void Worker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            switch(e.ProgressPercentage)
            {
                case WORKER_PROGRESS_NEW_PACKET:
                    if (e.UserState != null)
                    {
                        byte[] values = (byte[])e.UserState;
                        OnNewPacket?.Invoke(values, samplesPerPacket, sampleType);
                    }
                    break;
                case WORKER_PROGRESS_NEW_RECORDING:
                    if (e.UserState != null)
                    {
                        List<byte[]> recording = (List<byte[]>)e.UserState;
                        OnNewRecording?.Invoke(recording, samplesPerPacket, sampleType);
                    }
                    break;
                case WORKER_PROGRESS_NEW_STATUS:
                    if (e.UserState != null)
                    {
                        ConnectionState state = (ConnectionState)e.UserState;
                        OnNewConnectionState?.Invoke(state, string.Empty);
                    }
                    break;
                case WORKER_PROGRESS_START_NEW:
                    OnNewConnectionState?.Invoke(ConnectionState.StartNew, string.Empty);
                    break;
            }
        }
    }
}
