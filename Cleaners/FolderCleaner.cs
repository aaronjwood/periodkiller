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

        public FolderCleaner(bool recursiveProcessing)
        {
            this.recursiveProcessingEnabled = recursiveProcessing;
        }

        public bool recursiveProcessingEnabled
        {
            get;
            set;
        }

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
            Stack<DirectoryInfo> directories = new Stack<DirectoryInfo>();

            //If recursive processing is enabled then grab all the directories, otherwise grab only the top level directories
            string[] items;
            if (!this.recursiveProcessingEnabled)
            {
                try
                {
                    items = Directory.GetDirectories(selectedFolder.SelectedPath);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    items = Directory.GetDirectories(selectedFolder.SelectedPath, "*", SearchOption.AllDirectories);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
            }

            foreach (string directory in items)
            {
                directories.Push(new DirectoryInfo(directory));
            }

            MessageBox.Show(directories.Count.ToString());

            while (directories.Count > 0)
            {
                DirectoryInfo directory = directories.Pop();

                if (directory.Name.Contains("."))
                {
                    //Build the absolute path with the modified directory name
                    string parentDirectory = Directory.GetParent(directory.FullName).FullName;
                    string destinationDirectory = directory.Name.Replace(".", " ");
                    destinationDirectory = Path.Combine(parentDirectory, destinationDirectory).Trim();

                    //Rename the directory if the directory doesn't already exist
                    if (!Directory.Exists(destinationDirectory))
                    {
                        try
                        {
                            Directory.Move(directory.FullName, destinationDirectory);
                            this.numPeriods++;
                        }
                        catch (IOException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                    else
                    {
                        string[] duplicate = { "Folder", directory.FullName, destinationDirectory, destinationDirectory };
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
            Stack<DirectoryInfo> directories = new Stack<DirectoryInfo>();

            //If recursive processing is enabled then grab all the directories, otherwise grab only the top level directories
            string[] dirs;
            if (!this.recursiveProcessingEnabled)
            {
                dirs = Directory.GetDirectories(selectedFolder.SelectedPath);
            }
            else
            {
                dirs = Directory.GetDirectories(selectedFolder.SelectedPath, "*", SearchOption.AllDirectories);
            }

            foreach (string directory in dirs)
            {
                directories.Push(new DirectoryInfo(directory));
            }

            while (directories.Count > 0)
            {
                DirectoryInfo directory = directories.Pop();

                //Get the parent of each directory and the actual directory name that we'll be working with
                string parentDirectory = Directory.GetParent(directory.FullName).FullName;
                string currentDirectory = directory.Name;

                if (currentDirectory.IndexOf(variable, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    //Make sure we're not removing the entire folder name!
                    if (currentDirectory.IndexOf(variable, StringComparison.OrdinalIgnoreCase) >= 0 && currentDirectory.Substring(0, currentDirectory.IndexOf(variable, StringComparison.OrdinalIgnoreCase)) != "")
                    {
                        //Get the index based on the lowercase versions at which to start removing text
                        int idx = currentDirectory.IndexOf(variable, StringComparison.OrdinalIgnoreCase);
                        string sourceDirectory = Path.Combine(parentDirectory, currentDirectory);
                        string destinationDirectory = Path.Combine(parentDirectory, currentDirectory.Substring(0, idx)).Trim();

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

    }
}
