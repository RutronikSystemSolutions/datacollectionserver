using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datacollectionserver
{
    public class ConfigurationHolder
    {
        public delegate void OnNewOutputDirectoryEventHandler(string outputDirectory);
        public event OnNewOutputDirectoryEventHandler? OnNewOutputDirectory;

        public delegate void OnNewFilePrefixEventHandler(string filePrefix);
        public event OnNewFilePrefixEventHandler? OnNewFilePrefix;

        private string outputDirectory = "";
        private string filePrefix = "";

        public void setOutputDirectory(string outputDirectory)
        {
            this.outputDirectory = outputDirectory;
            Properties.Settings.Default.outputDirectory = outputDirectory;
            Properties.Settings.Default.Save();
            OnNewOutputDirectory?.Invoke(outputDirectory);
        }

        public void setFilePrefix(string filePrefix)
        {
            this.filePrefix = filePrefix;
            Properties.Settings.Default.prefix = filePrefix;
            Properties.Settings.Default.Save();
        }

        public string OutputDirectory
        {
            get { return outputDirectory; }
        }

        public string FilePrefix
        {
            get { return filePrefix; }
        }

        public void LoadFromMemory()
        {
            outputDirectory = Properties.Settings.Default.outputDirectory;
            filePrefix = Properties.Settings.Default.prefix;

            OnNewOutputDirectory?.Invoke(outputDirectory);
            OnNewFilePrefix?.Invoke(filePrefix);
        }
    }
}
