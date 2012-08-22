using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace PeriodKiller
{
    class FilenameCleaner
    {
        public int numPeriods
        {
            get;
            set;
        }

        public int numRenames
        {
            get;
            set;
        }

        private List<string> duplicates = new List<string>();

        public List<string> Duplicates
        {
            get
            {
                return this.duplicates;
            }
        }

        public void removePeriods(FolderBrowserDialog selectedFolder)
        {
            //Start removing the periods from file names
            string[] files = Directory.GetFiles(selectedFolder.SelectedPath);
            foreach (string file in files)
            {
                //Get the filename without the extension, the parent directory, and the extension of the filename we're working with
                string filename = Path.GetFileNameWithoutExtension(file);
                string parentDirectory = Path.GetDirectoryName(file) + "\\";
                string extension = Path.GetExtension(file);
                if (filename.Contains("."))
                {
                    //Build the absolute path with the modified filename
                    string destinationFile = filename.Replace(".", " ");
                    destinationFile = parentDirectory + destinationFile + extension;

                    //Does the file already exist?
                    if (!File.Exists(destinationFile))
                    {
                        try
                        {
                            File.Move(file, destinationFile);
                            this.numPeriods++;
                        }
                        catch (IOException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                    else
                    {
                        this.duplicates.Add(file);
                    }
                }
            }
        }

        //TODO handle removing text from filenames

        public void resetCounts()
        {
            this.numPeriods = 0;
            this.numRenames = 0;
            this.duplicates.Clear();
        }
    }
}
