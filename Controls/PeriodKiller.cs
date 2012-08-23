using System;
using System.Windows.Forms;
using System.IO;

namespace PeriodKiller
{
    public partial class PeriodKiller : Form
    {
        private FolderBrowserDialog folderDialog = new FolderBrowserDialog();
        private FolderCleaner folderCleaner = new FolderCleaner();
        private FilenameCleaner filenameCleaner = new FilenameCleaner();
        private string selectedPath;

        public PeriodKiller()
        {
            InitializeComponent();
            duplicatesLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            duplicatesLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(duplicatesLabel_LinkClicked);
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            //When a folder is selected, set the path in the appropriate label
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                this.selectedPath = folderDialog.SelectedPath;
                folderPathLabel.Text = this.selectedPath;
                selectFolderLbl.Text = "";
                mainContainer.Visible = true;
                fixFolders.Visible = true;
            }
        }

        private void fixFolders_Click(object sender, EventArgs e)
        {
            duplicatesLabel.Hide();
            //Has the user selected a folder yet?
            if (this.selectedPath!= "")
            {
                //Make sure that the directory hasn't been deleted outside of the program
                if (!Directory.Exists(this.selectedPath))
                {
                    duplicatesLabel.Text = "";
                    selectFolderLbl.Text = "Folder no longer exists!";
                    this.selectedPath = null;
                    folderPathLabel.Text = this.selectedPath;
                    mainContainer.Visible = false;
                    fixFolders.Visible = false;
                    return;
                }
                selectFolderLbl.Text = "";

                //Reset counts from previous run (if any)
                folderCleaner.resetCounts();
                filenameCleaner.resetCounts();

                //Remove the periods
                folderCleaner.removePeriods(folderDialog);

                //Remove a string from each folder if option is checked and the text box isn't empty
                if (enableFolderVariableRemoval.Checked && folderVariableRemoval.Text != "")
                {
                    folderCleaner.removeText(folderDialog, folderVariableRemoval.Text);
                }

                //Remove periods from filename if option is checked
                if (enableFilenameProcessing.Checked)
                {
                    filenameCleaner.removePeriods(folderDialog);
                }

                //If there are duplicates 
                if (folderCleaner.Duplicates.Count > 0)
                {
                    duplicatesLabel.Show();
                    duplicatesLabel.Text = folderCleaner.Duplicates.Count + " collision(s) found when restructuring folders. Click here to view them.";
                }

                //Display message about processed folders/files
                Messages cleanerMessages = new Messages(folderCleaner.numPeriods, folderCleaner.numRenames, filenameCleaner.numPeriods);
                if (cleanerMessages.hasMessage())
                {
                    MessageBox.Show(cleanerMessages.getMessage());
                }
            }
            else
            {
                selectFolderLbl.Text = "Please select a folder first";
            }
        }

        private void duplicatesLabel_LinkClicked(object sender, EventArgs e)
        {
            //Open up the duplicates window and display any outstanding duplicates
            //TODO allow duplicate resolution here. Create options for each duplicate
            Collisions duplicatesForm = new Collisions();
            duplicatesForm.Owner = this;
            foreach (string folder in folderCleaner.Duplicates)
            {
                duplicatesForm.addItem = folder;
            }
            duplicatesForm.ShowDialog();
        }

        private void enableFilenameProcessing_CheckedChanged(object sender, EventArgs e)
        {
            if (enableFilenameProcessing.Checked)
            {
                fixFolders.Text = "Clean File and Folder Names";
            }
            else
            {
                fixFolders.Text = "Clean Folder Names";
            }
        }

        private void enableFolderVariableRemoval_CheckedChanged(object sender, EventArgs e)
        {
            if (enableFolderVariableRemoval.Checked)
            {
                cleanFolderTextPanel.Visible = true;
                cleanTextPanel.Visible = true;
            }
            else
            {
                cleanFolderTextPanel.Visible = false;
                if (cleanFilenameTextPanel.Visible == false)
                {
                    cleanTextPanel.Visible = false;
                }
            }
        }

        private void enableFilenameVariableRemoval_CheckedChanged(object sender, EventArgs e)
        {
            if (enableFilenameVariableRemoval.Checked)
            {
                cleanFilenameTextPanel.Visible = true;
                cleanTextPanel.Visible = true;
            }
            else
            {
                cleanFilenameTextPanel.Visible = false;
                if (cleanFolderTextPanel.Visible == false)
                {
                    cleanTextPanel.Visible = false;
                }
            }
        }
    }
}
