using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PeriodKiller
{
    class FolderCleaner
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
            //Start removing the periods from folder names
            string[] directories = Directory.GetDirectories(selectedFolder.SelectedPath);
            foreach (string directory in directories)
            {
                if (directory.Contains("."))
                {
                    string destinationDirectory = directory.Replace(".", " ");
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
                        this.duplicates.Add(directory);
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
                        else
                        {
                            this.duplicates.Add(directoryName);
                        }
                    }
                }
            }
        }

        public void resetCounts()
        {
            this.numPeriods = 0;
            this.numRenames = 0;
            this.duplicates.Clear();
        }
    }
}
