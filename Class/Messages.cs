using System.Windows.Forms;

namespace PeriodKiller
{
    class Messages
    {
        int periodRemovals;
        int folderRenames;

        public Messages(int periodRemovals, int folderRenames)
        {
            this.periodRemovals = periodRemovals;
            this.folderRenames = folderRenames;
        }

        public string getProcessedMessage()
        {
            if (periodRemovals == 0)
            {
                if (folderRenames == 0)
                {
                    return "There were no folders with periods replaced or that had variable removals";
                }
                else
                {
                    return "There were no periods to be replaced but there were " + folderRenames + " variable removals performed";
                }
            }
            else
            {
                if(folderRenames == 0)
                {
                    return periodRemovals + " folders had their periods successfully replaced with spaces";
                }
                else
                {
                    return periodRemovals + " folders had their periods successfully replaced with spaces and " + folderRenames + " variable removals were performed";
                }
            }
        }
    }
}
