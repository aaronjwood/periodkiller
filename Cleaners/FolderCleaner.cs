using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PeriodKiller.Interface;

namespace PeriodKiller.Cleaners
{
    class FolderCleaner : ICleaner
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
        /// Removes periods from folder names
        /// </summary>
        /// <param name="selectedFolder">The folder that has been selected</param>
        public void removePeriods(FolderBrowserDialog selectedFolder)
        {
            //Start removing the periods from folder names
            string[] directories = Directory.GetDirectories(selectedFolder.SelectedPath);
            foreach (string directory in directories)
            {
                string currentDirectory = new DirectoryInfo(directory).Name;

                if (currentDirectory.Contains("."))
                {
                    //Build the absolute path with the modified directory name
                    string parentDirectory = Path.GetDirectoryName(directory);
                    string destinationDirectory = currentDirectory.Replace(".", " ");
                    destinationDirectory = Path.Combine(parentDirectory, destinationDirectory);

                    if (!Directory.Exists(destinationDirectory))
                    {
                        try
                        {
                            Directory.Move(directory, destinationDirectory);
                            this.numPeriods++;
                        }
                        catch (IOException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                    else
                    {
                        string[] duplicate = { "Folder", directory, destinationDirectory, destinationDirectory };
                        this.duplicates.Add(duplicate);
                    }
                }
            }
        }

        /// <summary>
        /// Removes a chunk of text from folder names
        /// </summary>
        /// <param name="selectedFolder">The folder that has been selected</param>
        /// <param name="variable">The text to remove from each folder name</param>
        public void removeText(FolderBrowserDialog selectedFolder, string variable)
        {
            string[] directories = Directory.GetDirectories(selectedFolder.SelectedPath);
            foreach (string directoryName in directories)
            {
                //Get the parent of each directory and the actual directory name that we'll be working with
                string directoryParent = Directory.GetParent(directoryName).FullName;
                string directory = directoryName.Substring(directoryName.LastIndexOf("\\") + 1);

                //Convert the directory name and the variable to lowercase to ignore case
                string lowerDirectory = directory.ToLower();
                string lowerVariable = variable.ToLower();

                if (lowerDirectory.Contains(lowerVariable))
                {
                    //Make sure we're not removing the entire folder name!
                    if (lowerDirectory.IndexOf(lowerVariable) >= 0 && lowerDirectory.Substring(0, lowerDirectory.IndexOf(lowerVariable)) != "")
                    {
                        //Get the index based on the lowercase versions at which to start removing text
                        int idx = lowerDirectory.IndexOf(lowerVariable);
                        string sourceDirectory = Path.Combine(directoryParent, directory);
                        string destinationDirectory = Path.Combine(directoryParent, directory.Substring(0, idx));

                        //Does the directory already exist?
                        if (!Directory.Exists(destinationDirectory))
                        {
                            try
                            {
                                Directory.Move(sourceDirectory, destinationDirectory);
                                this.numRenames++;
                            }
                            catch (IOException e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }

                        //The directory exists, add it to the duplicate structure
                        else
                        {
                            string[] duplicate = { "Folder", sourceDirectory, destinationDirectory, destinationDirectory };
                            this.duplicates.Add(duplicate);
                        }
                    }
                }
            }
        }

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
