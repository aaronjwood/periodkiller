using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace PeriodKiller
{
    class FilenameCleaner
    {
        private int numPeriods = 0;
        private int numRenames = 0;
        private List<String> duplicates = new List<string>();

        public void removePeriods(FolderBrowserDialog selectedFolder)
        {
            //Start removing the periods from file names
            string[] files = Directory.GetFiles(selectedFolder.SelectedPath);
            foreach (string file in files)
            {
                string filename = Path.GetFileNameWithoutExtension(file);
                if(filename.Contains("."))
                {
                    
                }
            }
        }
    }
}
