using PeriodKiller.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PeriodKiller.Cleaners
{
    class FilenameCleaner : ICleaner
    {
        private List<string[]> duplicates = new List<string[]>();

        public FilenameCleaner(bool recursiveProcessing)
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
        /// Removes periods from filenames
        /// </summary>
        /// <param name="selectedFolder">The folder that has been selected</param>
        public void removePeriods(FolderBrowserDialog selectedFolder)
        {

            //If recursive processing is enabled then grab all the directories, otherwise grab only the top level directories
            IEnumerable<String> allFiles = (!this.recursiveProcessingEnabled) ? Directory.EnumerateFiles(selectedFolder.SelectedPath) : Directory.EnumerateFiles(selectedFolder.SelectedPath, "*", SearchOption.AllDirectories);

            foreach (string file in allFiles)
            {
                //Make sure we aren't capturing the extension
                string fileName = Path.GetFileNameWithoutExtension(file);
                if (fileName.Contains("."))
                {
                    //Build the absolute path with the modified filename
                    string parentDirectory = Directory.GetParent(file).FullName;
                    string destinationFile = fileName.Replace(".", " ");
                    destinationFile = Path.Combine(parentDirectory, destinationFile).Trim() + Path.GetExtension(file);

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
            Stack<FileInfo> files = new Stack<FileInfo>();

            string[] items;
            if (!this.recursiveProcessingEnabled)
            {
                items = Directory.GetFiles(selectedFolder.SelectedPath);
            }
            else
            {
                items = Directory.GetFiles(selectedFolder.SelectedPath, "*", SearchOption.AllDirectories);
            }

            foreach (string file in items)
            {
                files.Push(new FileInfo(file));
            }

            while (files.Count > 0)
            {
                FileInfo file = files.Pop();

                //Get the parent of each directory and the actual directory name that we'll be working with
                string parentDirectory = Directory.GetParent(file.FullName).FullName;
                string currentFile = Path.GetFileNameWithoutExtension(file.Name);

                if (currentFile.IndexOf(variable, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    //Make sure we're not removing the entire folder name!
                    if (currentFile.IndexOf(variable, StringComparison.OrdinalIgnoreCase) >= 0 && currentFile.Substring(0, currentFile.IndexOf(variable, StringComparison.OrdinalIgnoreCase)) != "")
                    {
                        //Get the index based on the lowercase versions at which to start removing text
                        int idx = currentFile.IndexOf(variable, StringComparison.OrdinalIgnoreCase);
                        string sourceFile = Path.Combine(parentDirectory, currentFile + file.Extension);
                        string destinationFile = Path.Combine(parentDirectory, currentFile.Substring(0, idx)).Trim() + file.Extension;

                        //Does the directory already exist?
                        if (!Directory.Exists(destinationFile))
                        {
                            try
                            {
                                File.Move(sourceFile, destinationFile);
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
                            string[] duplicate = { "Folder", sourceFile, destinationFile, destinationFile };
                            this.duplicates.Add(duplicate);
                        }
                    }
                }
            }
        }

    }
}
