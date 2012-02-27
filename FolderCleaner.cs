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
        private List<String> duplicates = new List<String>();

        public void removePeriods(FolderBrowserDialog selectedFolder)
        {
            //Start removing the periods from folder names
            string[] newdirectories = Directory.GetDirectories(selectedFolder.SelectedPath);
            foreach (String directory in newdirectories)
            {
                if (directory.Contains("."))
                {
                    try
                    {
                        //Remove period and increment the count of number of periods replaced
                        numPeriods++;
                        Directory.Move(directory, directory.Replace(".", " "));
                    }
                    catch (IOException)
                    {
                        //TODO more checks are needed here
                        //TODO handle duplicates (prompt to overwrite, merge, etc.?)
                        //We encountered a duplicate
                        numPeriods--;
                        if (!duplicates.Contains(directory))
                        {
                            duplicates.Add(directory);
                        }
                    }
                }
            }
        }

        public void removeText(FolderBrowserDialog selectedFolder, String variable)
        {
            String[] directories = Directory.GetDirectories(selectedFolder.SelectedPath);
            foreach (String directoryName in directories)
            {
                //Get the parent of each directory and the actual directory name that we'll be working with
                DirectoryInfo directoryParent = Directory.GetParent(directoryName);
                String directory = directoryName.Substring(directoryName.LastIndexOf("\\") + 1);

                if (directoryName.ToLower().Contains(variable.ToLower()))
                {
                    //If there's an occurance of the string in the directory name, convert the string and directory name to lowercase
                    String lowerDirectoryName = directoryName.ToLower();
                    String lowerVariableRemoval = variable.ToLower();

                    //Make sure we're not removing the entire folder name!
                    if (directory.LastIndexOf(variable) >= 0 && directory.Substring(0, directory.LastIndexOf(variable)) != "")
                    {
                        try
                        {
                            //Perform the rename with the variable removal and increment the number of directory renames
                            numRenames++;
                            Directory.Move(directoryParent + "\\" + directory, directoryParent + "\\" + directory.Substring(0, directory.LastIndexOf(variable)));
                        }
                        catch (IOException)
                        {
                            //TODO handle duplicates (prompt to overwrite, merge, etc.?)
                            //TODO more checks are needed here
                            //The renaming process produced duplicates
                            numRenames--;
                            if (!duplicates.Contains(directoryName))
                            {
                                duplicates.Add(directoryName);
                            }
                        }
                    }
                }
            }
        }

        public int numPeriodRemovals()
        {
            return numPeriods;
        }

        public int numFolderRenames()
        {
            return this.numRenames;
        }

        public List<String> getDuplicates()
        {
            return duplicates;
        }
    }
}
