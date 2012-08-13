using System;
using System.Windows.Forms;
using System.IO;

namespace PeriodKiller
{
    public partial class PeriodKiller : Form
    {
        private FolderBrowserDialog folderDialog = new FolderBrowserDialog();
        private FolderCleaner folderCleaner;

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
                folderPathLabel.Text = folderDialog.SelectedPath;
                selectFolderLbl.Text = "";
                mainContainer.Visible = true;
                fixFolders.Visible = true;
            }
        }

        private void fixFolders_Click(object sender, EventArgs e)
        {
            //TODO implement removing periods from filename

            duplicatesLabel.Hide();
            //Has the user selected a folder yet?
            if (folderDialog.SelectedPath != "")
            {
                 folderCleaner = new FolderCleaner();
                //Make sure that the directory hasn't been deleted outside of the program
                if (!Directory.Exists(folderDialog.SelectedPath))
                {
                    duplicatesLabel.Text = "";
                    selectFolderLbl.Text = "Folder no longer exists!";
                    folderPathLabel.Text = "";
                    mainContainer.Visible = false;
                    fixFolders.Visible = false;
                    return;
                }
                selectFolderLbl.Text = "";

                //Remove the periods
                folderCleaner.removePeriods(folderDialog);

                if (enableFolderVariableRemoval.Checked && folderVariableRemoval.Text != "")
                {
                    //Remove a string from each folder
                    folderCleaner.removeText(folderDialog, folderVariableRemoval.Text);
                }

                if (folderCleaner.Duplicates.Count > 0)
                {
                    duplicatesLabel.Show();
                    duplicatesLabel.Text = folderCleaner.Duplicates.Count + " collision(s) found when restructuring folders. Click here to view them.";
                }
                //Display message about processed folders/files
                Messages cleanerMessages = new Messages(folderCleaner.PeriodRemovals, folderCleaner.FolderRenames);
                MessageBox.Show(cleanerMessages.getProcessedMessage());
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
