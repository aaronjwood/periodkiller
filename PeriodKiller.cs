using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace PeriodKiller
{
    public partial class PeriodKiller : Form
    {
        private FolderBrowserDialog folderDialog = new FolderBrowserDialog();
        private FolderCleaner fCleaner = new FolderCleaner();

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
                //Make sure that the directory we're working with hasn't been deleted outside of the program after selecting it
                if (!Directory.Exists(folderDialog.SelectedPath))
                {
                    duplicatesLabel.Text = "";
                    selectFolderLbl.Text = "Folder no longer exists!";
                    pathLbl.Text = "";
                    return;
                }
                selectFolderLbl.Text = "";

                if (variableRemoval.Text != "")
                {
                    //Remove a string from each folder
                    fCleaner.removeText(folderDialog, variableRemoval.Text);
                }
                
                //Just remove the periods
                fCleaner.removePeriods(folderDialog);

                if (fCleaner.getDuplicates().Count > 0)
                {
                    duplicatesLabel.Enabled = true;
                    duplicatesLabel.Text = fCleaner.getDuplicates().Count + " collision(s) found when restructuring folders. Click here to view them.";
                }

                //Notifications/error messages
                //TODO consolidate this section a bit more. Maybe store messages in some kind of data structure for better organization/consistency?
                if (fCleaner.numPeriodRemovals() == 0)
                {
                    if (fCleaner.numFolderRenames() == 0)
                    {
                        MessageBox.Show("There were no folders with periods replaced or that had variable removals");
                    }
                    else
                    {
                        MessageBox.Show("There were no periods to be replaced but there were " + fCleaner.numFolderRenames() + " variable removals performed");
                    }
                    
                }
                else
                {
                    if (fCleaner.numFolderRenames() == 0)
                    {
                        MessageBox.Show(fCleaner.numPeriodRemovals().ToString() + " folders had their periods successfully replaced with spaces.");
                    }
                    else
                    {
                        MessageBox.Show(fCleaner.numPeriodRemovals().ToString() + " folders had their periods successfully replaced with spaces and " + fCleaner.numFolderRenames() + " variable removals were performed");
                    }
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
            foreach (String folder in fCleaner.getDuplicates())
            {
                duplicatesForm.addItem = folder;
            }
            duplicatesForm.ShowDialog();
        }
    }
}
