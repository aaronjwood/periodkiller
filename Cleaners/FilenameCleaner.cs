using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PeriodKiller.Interface;

namespace PeriodKiller.Cleaners
{
    class FilenameCleaner : ICleaner
    {
        private List<string[]> duplicates = new List<string[]>();

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

        public List<string[]> Duplicates
        {
            get
            {
                return this.duplicates;
            }
        }

        /// <summary>
        /// Removes periods from filenames
        /// </summary>
        /// <param name="selectedFolder">The folder that has been selected</param>
        public void removePeriods(FolderBrowserDialog selectedFolder)
        {
            //Start removing the periods from file names
            string[] files = Directory.GetFiles(selectedFolder.SelectedPath);
            foreach (string file in files)
            {
                //Get the filename without the extension
                string filename = Path.GetFileNameWithoutExtension(file);

                if (filename.Contains("."))
                {
                    //Build the absolute path with the modified filename
                    string parentDirectory = Path.GetDirectoryName(file);
                    string destinationFile = filename.Replace(".", " ");
                    string extension = Path.GetExtension(file);
                    destinationFile = Path.Combine(parentDirectory, destinationFile + extension);

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
                        string[] duplicate = { "File", file, destinationFile, destinationFile };
                        this.duplicates.Add(duplicate);
                    }
                }
            }
        }

        /// <summary>
        /// Removes a chunk of text from each filename
        /// </summary>
        /// <param name="selectedFolder">The folder that has been selected</param>
        /// <param name="variable">The text to remove from each filename</param>
        public void removeText(FolderBrowserDialog selectedFolder, string variable)
        {
            string[] files = Directory.GetFiles(selectedFolder.SelectedPath);
            foreach (string file in files)
            {
                //Get the filename without the extension
                string filename = Path.GetFileNameWithoutExtension(file);

                //Convert the filename and variable to lowercase to ignore case
                string lowerVariable = variable.ToLower();
                string lowerFilename = filename.ToLower();

                if (lowerFilename.Contains(lowerVariable))
                {
                    //Make sure we're not removing the entire filename!
                    if (lowerFilename.IndexOf(lowerVariable) >= 0 && lowerFilename.Substring(0, lowerFilename.IndexOf(lowerVariable)) != "")
                    {
                        //Build the absolute path
                        string parentDirectory = Path.GetDirectoryName(file);
                        int idx = lowerFilename.IndexOf(lowerVariable);
                        string extension = Path.GetExtension(file);
                        string newFilename = filename.Substring(0, idx) + extension;
                        string destinationFile = Path.Combine(parentDirectory, newFilename);

                        //Does the file already exist?
                        if (!File.Exists(destinationFile))
                        {
                            try
                            {
                                File.Move(file, destinationFile);
                                this.numRenames++;
                            }
                            catch (IOException e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }
                        else
                        {
                            string[] duplicate = { "File", file, destinationFile, destinationFile };
                            this.duplicates.Add(duplicate);
                        }
                    }
                }
            }
        }

        //TODO handle removing text from filenames

        /// <summary>
        /// Reset the number of operations performed and clear the duplicates list
        /// </summary>
        public void resetCounts()
        {
            this.numPeriods = 0;
            this.numRenames = 0;
            this.duplicates.Clear();
        }
    }
}
