namespace PeriodKiller
{
    class Messages
    {
        int folderPeriodRemovals;
        int folderRenames;
        int filePeriodRemovals;
        string message;

        public Messages(int folderPeriodRemovals, int folderRenames, int filePeriodRemovals)
        {
            this.folderPeriodRemovals = folderPeriodRemovals;
            this.folderRenames = folderRenames;
            this.filePeriodRemovals = filePeriodRemovals;
        }

        public string getProcessedCounts()
        {
            if (this.folderPeriodRemovals != 0)
            {
                this.message += "Number of periods removed from folders: " + this.folderPeriodRemovals + "\n";
            }
            if (this.folderRenames != 0)
            {
                this.message += "Number of folders renamed: " + this.folderRenames + "\n";
            }
            if (this.filePeriodRemovals != 0)
            {
                this.message += "Number of periods removed from files: " + this.filePeriodRemovals + "\n";
            }

            return this.message;
        }
    }
}
