using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datacollectionserver
{
    public class WavFileGenerator
    {
        public static void GenerateAudioFile(string path, short[]data, int frequency)
        {
            // If playback needed: var mStrm = new MemoryStream();
            var mStrm = File.Open(path, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(mStrm);

            int formatChunkSize = 16;
            int headerSize = 8;
            short formatType = 1;
            short tracks = 1;
            int samplesPerSecond = frequency;
            short bitsPerSample = 16;
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int waveSize = 4;
            int dataChunkSize = data.Length * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;
            
            writer.Write(0x46464952); // = encoding.GetBytes("RIFF")
            writer.Write(fileSize);
            writer.Write(0x45564157); // = encoding.GetBytes("WAVE")
            writer.Write(0x20746D66); // = encoding.GetBytes("fmt ")
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(0x61746164); // = encoding.GetBytes("data")
            writer.Write(dataChunkSize);
            {
                for (int step = 0; step < data.Length; step++)
                {
                    short s = data[step];
                    writer.Write(s);
                }
            }

            // If playback needed
            // mStrm.Seek(0, SeekOrigin.Begin);
            // new System.Media.SoundPlayer(mStrm).Play();

            writer.Close();
            mStrm.Close();
        }
    }
}
