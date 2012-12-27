namespace PeriodKiller
{
    class Messages
    {
        private int folderPeriodRemovals;
        private int folderRenames;
        private int filePeriodRemovals;
        private int fileRenames;
        private string message;

        public Messages(int folderPeriodRemovals, int folderRenames, int filePeriodRemovals, int fileRenames)
        {
            this.folderPeriodRemovals = folderPeriodRemovals;
            this.folderRenames = folderRenames;
            this.filePeriodRemovals = filePeriodRemovals;
            this.fileRenames = fileRenames;
            this.generateMessage();
        }

        private void generateMessage()
        {
            string generatedMessage = null;
            if (this.folderPeriodRemovals > 0)
            {
                generatedMessage += "Number of periods removed from folders: " + this.folderPeriodRemovals + "\n";
            }
            if (this.folderRenames > 0)
            {
                generatedMessage += "Number of folders renamed: " + this.folderRenames + "\n";
            }
            if (this.filePeriodRemovals > 0)
            {
                generatedMessage += "Number of periods removed from files: " + this.filePeriodRemovals + "\n";
            }
            if (this.fileRenames > 0)
            {
                generatedMessage += "Number of files renamed: " + this.fileRenames + "\n";
            }
            this.message = generatedMessage;
        }

        public bool hasMessage()
        {
            if (this.message != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getMessage()
        {
            return this.message;
        }
    }
}
