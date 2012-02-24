using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PeriodKiller
{
    class CleanFolders
    {
        private static PeriodKiller pk = new PeriodKiller();

        public static void removePeriods(FolderBrowserDialog selectedFolder)
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
                        pk.incrementPeriods();
                        Directory.Move(directory, directory.Replace(".", " "));
                    }
                    catch (IOException ex)
                    {
                        //TODO more checks are needed here
                        //TODO handle duplicates (prompt to overwrite, merge, etc.?)
                        //We encountered a duplicate
                        pk.decrementPeriods();
                        if (!pk.getDuplicates().Contains(directory))
                        {
                            pk.getDuplicates().Add(directory);
                        }
                        pk.getDuplicatesLabel().Enabled = true;
                        pk.getDuplicatesLabel().Text = pk.getDuplicates().Count + " collision(s) found when restructuring folders. Click here to view them.";
                    }
                }
            }
        }
    }
}
