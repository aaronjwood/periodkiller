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
                pathLbl.Text = folderDialog.SelectedPath;
                selectFolderLbl.Text = "";
            }
        }

        private void fixFolders_Click(object sender, EventArgs e)
        {   
            //Has the user selected a folder yet?
            if (folderDialog.SelectedPath != "")
            {
                 folderCleaner = new FolderCleaner();
                //Make sure that the directory we're working with hasn't been deleted outside of the program after selecting it
                if (!Directory.Exists(folderDialog.SelectedPath))
                {
                    duplicatesLabel.Text = "";
                    selectFolderLbl.Text = "Folder no longer exists!";
                    pathLbl.Text = "";
                    return;
                }
                selectFolderLbl.Text = "";

                if (folderVariableRemoval.Text != "")
                {
                    //Remove a string from each folder
                    folderCleaner.removeText(folderDialog, folderVariableRemoval.Text);
                }
                
                //Just remove the periods
                folderCleaner.removePeriods(folderDialog);

                if (folderCleaner.Duplicates.Count > 0)
                {
                    duplicatesLabel.Enabled = true;
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
            //TODO implement removing periods from filename
        }

        private void enableFolderVariableRemoval_CheckedChanged(object sender, EventArgs e)
        {
            if (enableFolderVariableRemoval.Checked)
            {
                panel1.Visible = true;
                panel4.Visible = true;
            }
            else
            {
                panel1.Visible = false;
                if (panel3.Visible == false)
                {
                    panel4.Visible = false;
                }
            }
        }

        private void enableFilenameVariableRemoval_CheckedChanged(object sender, EventArgs e)
        {
            if (enableFilenameVariableRemoval.Checked)
            {
                panel3.Visible = true;
                panel4.Visible = true;
            }
            else
            {
                panel3.Visible = false;
                if (panel1.Visible == false)
                {
                    panel4.Visible = false;
                }
            }
        }
    }
}
