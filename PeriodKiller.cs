using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace PeriodKiller
{
    public partial class PeriodKiller : Form
    {
        private List<String> duplicates = new List<String>();
        private FolderBrowserDialog folderDialog = new FolderBrowserDialog();
        private int numPeriods = 0;
        private int numRenames = 0;

        public PeriodKiller()
        {
            InitializeComponent();
            duplicatesLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            duplicatesLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(duplicatesLabel_LinkClicked);
        }

        public void incrementPeriods()
        {
            numPeriods++;
        }

        public void incrementRenames()
        {
            numRenames++;
        }

        public void decrementPeriods()
        {
            numPeriods--;
        }

        public void decrementRenames()
        {
            numRenames--;
        }

        public List<String> getDuplicates()
        {
            return duplicates;
        }

        public LinkLabel getDuplicatesLabel()
        {
            return duplicatesLabel;
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
            if (folderDialog.SelectedPath != "")
            {
                //Make sure a directory is selected and that the user hasn't deleted it manually after selecting it
                if (!Directory.Exists(folderDialog.SelectedPath))
                {
                    duplicatesLabel.Text = "";
                    selectFolderLbl.Text = "Folder no longer exists!";
                    pathLbl.Text = "";
                    return;
                }
                selectFolderLbl.Text = "";
                String variable = variableRemoval.Text;
                String[] directories = Directory.GetDirectories(folderDialog.SelectedPath);
                
                DirectoryInfo directoryParent;

                //A variable removal needs to be performed
                if (variableRemoval.Text != "")
                {
                    foreach (String directoryName in directories)
                    {
                        //Get the parent of each directory and the actual directory name that we'll be working with
                        directoryParent = Directory.GetParent(directoryName);
                        String directory = directoryName.Substring(directoryName.LastIndexOf("\\")+1);

                        if (directoryName.ToLower().Contains(variable.ToLower()))
                        {
                            //If there's an occurance of the variable in the directory name, convert the variable and directory name to lowercase
                            String lowerDirectoryName = directoryName.ToLower();
                            String lowerVariableRemoval = variable.ToLower();

                            //Make sure we're not removing the entire folder name!
                            if (directory.LastIndexOf(variable) >= 0 && directory.Substring(0, directory.LastIndexOf(variable)) != "")
                            {
                                try
                                {
                                    //Perform the rename with the variable removal and increment the number of directory renames
                                    numRenames++;
                                    Directory.Move(directoryParent + "\\" + directory, directoryParent + "\\" + directory.Substring(0, directory.LastIndexOf(variable)));
                                }
                                catch (IOException ex)
                                {
                                    //TODO handle duplicates (prompt to overwrite, merge, etc.?)
                                    //TODO more checks are needed here
                                    //The renaming process produced duplicates
                                    numRenames--;
                                    if (!duplicates.Contains(directoryName))
                                    {
                                        duplicates.Add(directoryName);
                                    }
                                    duplicatesLabel.Enabled = true;
                                    duplicatesLabel.Text = duplicates.Count + " collision(s) found when restructuring folders. Click here to view them.";
                                }
                            }
                        }
                    }
                }

                

                //Notifications/error messages
                //TODO consolidate this section a bit more. Maybe store messages in some kind of data structure for better organization/consistency?
                if (numPeriods == 0)
                {
                    if (numRenames == 0)
                    {
                        MessageBox.Show("There were no folders with periods replaced or that had variable removals");
                    }
                    else
                    {
                        MessageBox.Show("There were no periods to be replaced but there were "+numRenames+" variable removals performed");
                    }
                    
                }
                else
                {
                    if(numRenames == 0)
                    {
                        MessageBox.Show(numPeriods.ToString() + " folders had their periods successfully replaced with spaces.");
                    }
                    else
                    {
                        MessageBox.Show(numPeriods.ToString() + " folders had their periods successfully replaced with spaces and "+numRenames+" variable removals were performed");
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
            foreach (String folder in duplicates)
            {
                duplicatesForm.addItem = folder;
            }
            duplicatesForm.ShowDialog();
        }
    }
}
