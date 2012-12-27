using System.Windows.Forms;
using System.Collections.Generic;

namespace PeriodKiller.Interface
{
    interface ICleaner
    {
        int numPeriods
        {
            get;
            set;
        }
        int numRenames
        {
            get;
            set;
        }
        List<string[]> Duplicates
        {
            get;
        }
        void removePeriods(FolderBrowserDialog selectedFolder);
        void removeText(FolderBrowserDialog selectedFolder, string text);
    }
}
