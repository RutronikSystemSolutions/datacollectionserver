using Microsoft.VisualBasic;
using System.IO.Ports;
using static datacollectionserver.DataCollector;

namespace datacollectionserver
{
    public partial class MainForm : Form
    {
        private DataCollector collector = new DataCollector();
        private ConfigurationHolder configurationHolder = new ConfigurationHolder();
        private int recordCounter = 0;

        public MainForm()
        {
            InitializeComponent();
            collector.OnNewConnectionState += Collector_OnNewConnectionState;
            collector.OnNewPacket += Collector_OnNewPacket;
            collector.OnNewRecording += Collector_OnNewRecording;
            configurationHolder.OnNewOutputDirectory += ConfigurationHolder_OnNewOutputDirectory;
            configurationHolder.OnNewFilePrefix += ConfigurationHolder_OnNewFilePrefix;

            configurationHolder.LoadFromMemory();
        }

        private void ConfigurationHolder_OnNewFilePrefix(string filePrefix)
        {
            filePrefixTextBox.Text = filePrefix;
        }

        private void ConfigurationHolder_OnNewOutputDirectory(string outputDirectory)
        {
            outputDirectoryTextBox.Text = outputDirectory;
        }

        private void Collector_OnNewRecording(List<byte[]> sample, int samplesPerPacket, SampleType sampleType)
        {
            // Consider wav file only at the moment
            // TODO: handle other types

            short[] buffer = new short[sample.Count * samplesPerPacket];
            for (int i = 0; i < sample.Count; i++)
            {
                int index = 0;
                for (int j = 0; j < samplesPerPacket; j++)
                {
                    buffer[i * samplesPerPacket + j] = BitConverter.ToInt16(sample[i], index);
                    index += 2;
                }
            }

            string filePath = string.Format("{0}\\{1}_{2}.wav", configurationHolder.OutputDirectory, configurationHolder.FilePrefix, recordCounter);
            WavFileGenerator.GenerateAudioFile(filePath, buffer, 16000);

            recordCounter++;
            counterTextBox.Text = recordCounter.ToString();
        }

        private void Collector_OnNewPacket(byte[] packet, int samplesPerPacket, SampleType sampleType)
        {
            if (packet == null) return;
            int elementSizeByte = GetElementSizeByType(sampleType);
            if (packet.Length != (elementSizeByte * samplesPerPacket)) return;

            if (sampleType == SampleType.SampleTypeShort)
            {
                short[] buffer = new short[samplesPerPacket];
                int index = 0;
                for (int i = 0; i < samplesPerPacket; ++i)
                {
                    buffer[i] = BitConverter.ToInt16(packet, index);
                    index += 2;
                }
                liveSignalView.Feed(buffer);
            }
        }

        private void LockUnlockControls(bool locked)
        {
            comPortComboBox.Enabled = !locked;
            refreshButton.Enabled = !locked;
            baudRateTextBox.Enabled = !locked;
            outputFormatComboBox.Enabled = !locked;
            dataTypeComboBox.Enabled = !locked;
            samplesPerPacketTextBox.Enabled = !locked;
            featuresTextBox.Enabled = !locked;
            sampleRateTextBox.Enabled = !locked;
            selectOutputDirectoryButton.Enabled = !locked;
            filePrefixTextBox.Enabled = !locked;
            collectDataButton.Enabled = !locked;
            stopButton.Enabled = locked;
        }

        private void Collector_OnNewConnectionState(DataCollector.ConnectionState state, string lastError)
        {
            switch (state)
            {
                case ConnectionState.Connected:
                    statusTextBox.Text = "Connected";
                    LockUnlockControls(true);
                    break;
                case ConnectionState.Iddle:
                    statusTextBox.Text = "Iddle";
                    LockUnlockControls(false);
                    break;
                case ConnectionState.Error:
                    statusTextBox.Text = "Error. " + lastError;
                    LockUnlockControls(false);
                    break;
                case ConnectionState.WaitingData:
                    statusTextBox.Text = "Waiting data";
                    break;
                case ConnectionState.CollectingData:
                    statusTextBox.Text = "Collecting data";
                    break;
            }
        }

        private void LoadComPorts()
        {
            string[] serialPorts = SerialPort.GetPortNames();
            comPortComboBox.DataSource = serialPorts;
        }

        private void LoadStandardValues()
        {
            outputFormatComboBox.SelectedIndex = 0;
            dataTypeComboBox.SelectedIndex = 0;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadComPorts();
            LoadStandardValues();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadComPorts();
        }

        private void collectDataButton_Click(object sender, EventArgs e)
        {
            configurationHolder.setFilePrefix(filePrefixTextBox.Text);

            if ((comPortComboBox.SelectedIndex < 0) || (comPortComboBox.SelectedIndex >= comPortComboBox.Items.Count)) return;

            var selectedItem = comPortComboBox.Items[comPortComboBox.SelectedIndex];
            if (selectedItem != null)
            {
                string? portName = selectedItem.ToString();
                if (portName != null)
                {
                    collector.StartCollecting(portName, 1000000, SampleType.SampleTypeShort, 1024);
                }
            }
        }

        private void selectOutputDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            configurationHolder.setOutputDirectory(dlg.SelectedPath);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            collector.Stop();
        }
    }
}
