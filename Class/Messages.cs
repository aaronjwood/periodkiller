namespace PeriodKiller
{
    class Messages
    {
        int folderPeriodRemovals;
        int folderRenames;
        int filePeriodRemovals;

        public Messages(int folderPeriodRemovals, int folderRenames, int filePeriodRemovals)
        {
            this.folderPeriodRemovals = folderPeriodRemovals;
            this.folderRenames = folderRenames;
            this.filePeriodRemovals = filePeriodRemovals;
        }

        public string getProcessedCounts()
        {
            string message = null;
            if (this.folderPeriodRemovals != 0)
            {
                message += "Number of periods removed from folders: " + this.folderPeriodRemovals + "\n";
            }
            if (this.folderRenames != 0)
            {
                message += "Number of folders renamed: " + this.folderRenames + "\n";
            }
            if (this.filePeriodRemovals != 0)
            {
                message += "Number of periods removed from files: " + this.filePeriodRemovals + "\n";
            }

            return message;
        }

        public bool hasMessage()
        {
            if (this.folderPeriodRemovals != 0 || this.folderRenames != 0 || this.filePeriodRemovals != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
