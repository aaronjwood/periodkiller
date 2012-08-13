using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PeriodKiller
{
    class FolderCleaner
    {
        private int numPeriods = 0;
        private int numRenames = 0;
        private List<string> duplicates = new List<string>();

        public void removePeriods(FolderBrowserDialog selectedFolder)
        {
            //Start removing the periods from folder names
            string[] directories = Directory.GetDirectories(selectedFolder.SelectedPath);
            foreach (string directory in directories)
            {
                if (directory.Contains("."))
                {
                    string destinationDirectory = directory.Replace(".", " ");
                    if (!Directory.Exists(destinationDirectory))
                    {
                        Directory.Move(directory, destinationDirectory);
                        numPeriods++;
                    }
                    else
                    {
                        duplicates.Add(directory);
                    }
                }
            }
        }

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
                        string sourceDirectory = directoryParent + "\\" + directory;
                        string destinationDirectory = directoryParent + "\\" + directory.Substring(0, idx);
                            
                        //Does the directory already exist?
                        if (!Directory.Exists(destinationDirectory))
                        {
                            //Perform the rename with the variable removal and increment the number of directory renames
                            Directory.Move(sourceDirectory, destinationDirectory);
                            numRenames++;
                        }
                        else
                        {
                            duplicates.Add(directoryName);
                        }
                    }
                }
            }
        }

        public int PeriodRemovals
        {
            get
            {
                return numPeriods;
            }
        }

        public int FolderRenames
        {
            get
            {
                return numRenames;
            }
        }

        public List<string> Duplicates
        {
            get
            {
                return duplicates;
            }
        }
    }
}
