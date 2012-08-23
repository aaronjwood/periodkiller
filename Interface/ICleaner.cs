using System.Windows.Forms;

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
        void removePeriods(FolderBrowserDialog selectedFolder);
        void removeText(FolderBrowserDialog selectedFolder, string text);
    }
}
