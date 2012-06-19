namespace PeriodKiller
{
    partial class PeriodKiller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PeriodKiller));
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.selectFolder = new System.Windows.Forms.Button();
            this.folderPathLabel = new System.Windows.Forms.Label();
            this.fixFolders = new System.Windows.Forms.Button();
            this.programName = new System.Windows.Forms.Label();
            this.duplicatesLabel = new System.Windows.Forms.LinkLabel();
            this.selectFolderLbl = new System.Windows.Forms.Label();
            this.enableFolderVariableRemoval = new System.Windows.Forms.CheckBox();
            this.enableFilenameVariableRemoval = new System.Windows.Forms.CheckBox();
            this.enableFilenameProcessing = new System.Windows.Forms.CheckBox();
            this.mainContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.cleanTextPanel = new System.Windows.Forms.Panel();
            this.cleanFilenameTextPanel = new System.Windows.Forms.Panel();
            this.cleanFilenamesHeader = new System.Windows.Forms.Label();
            this.cleanFilenameTextLabel = new System.Windows.Forms.Label();
            this.filenameVariableRemoval = new System.Windows.Forms.TextBox();
            this.cleanFolderTextPanel = new System.Windows.Forms.Panel();
            this.cleanFolderTextLabel = new System.Windows.Forms.Label();
            this.folderVariableRemoval = new System.Windows.Forms.TextBox();
            this.variableRemovalHeader = new System.Windows.Forms.Label();
            this.mainContainer.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.cleanTextPanel.SuspendLayout();
            this.cleanFilenameTextPanel.SuspendLayout();
            this.cleanFolderTextPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectFolder
            // 
            this.selectFolder.BackColor = System.Drawing.Color.Black;
            this.selectFolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.selectFolder.FlatAppearance.BorderSize = 2;
            this.selectFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.selectFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.selectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFolder.ForeColor = System.Drawing.Color.White;
            this.selectFolder.Location = new System.Drawing.Point(15, 49);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(479, 28);
            this.selectFolder.TabIndex = 0;
            this.selectFolder.Text = "Select A Folder";
            this.selectFolder.UseVisualStyleBackColor = false;
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // folderPathLabel
            // 
            this.folderPathLabel.AutoEllipsis = true;
            this.folderPathLabel.AutoSize = true;
            this.folderPathLabel.ForeColor = System.Drawing.Color.Orange;
            this.folderPathLabel.Location = new System.Drawing.Point(12, 82);
            this.folderPathLabel.Name = "folderPathLabel";
            this.folderPathLabel.Size = new System.Drawing.Size(0, 13);
            this.folderPathLabel.TabIndex = 1;
            // 
            // fixFolders
            // 
            this.fixFolders.BackColor = System.Drawing.Color.Black;
            this.fixFolders.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.fixFolders.FlatAppearance.BorderSize = 2;
            this.fixFolders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.fixFolders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fixFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fixFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixFolders.Location = new System.Drawing.Point(15, 320);
            this.fixFolders.Name = "fixFolders";
            this.fixFolders.Size = new System.Drawing.Size(479, 38);
            this.fixFolders.TabIndex = 2;
            this.fixFolders.Text = "Clean Folder Names";
            this.fixFolders.UseVisualStyleBackColor = false;
            this.fixFolders.Click += new System.EventHandler(this.fixFolders_Click);
            // 
            // programName
            // 
            this.programName.AutoSize = true;
            this.programName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.programName.Location = new System.Drawing.Point(172, 9);
            this.programName.Name = "programName";
            this.programName.Size = new System.Drawing.Size(160, 29);
            this.programName.TabIndex = 4;
            this.programName.Text = "Period Killer";
            // 
            // duplicatesLabel
            // 
            this.duplicatesLabel.AutoSize = true;
            this.duplicatesLabel.LinkColor = System.Drawing.Color.Yellow;
            this.duplicatesLabel.Location = new System.Drawing.Point(12, 268);
            this.duplicatesLabel.Name = "duplicatesLabel";
            this.duplicatesLabel.Size = new System.Drawing.Size(0, 13);
            this.duplicatesLabel.TabIndex = 9;
            this.duplicatesLabel.Visible = false;
            this.duplicatesLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // selectFolderLbl
            // 
            this.selectFolderLbl.AutoSize = true;
            this.selectFolderLbl.ForeColor = System.Drawing.Color.Red;
            this.selectFolderLbl.Location = new System.Drawing.Point(12, 300);
            this.selectFolderLbl.Name = "selectFolderLbl";
            this.selectFolderLbl.Size = new System.Drawing.Size(0, 13);
            this.selectFolderLbl.TabIndex = 10;
            // 
            // enableFolderVariableRemoval
            // 
            this.enableFolderVariableRemoval.AutoSize = true;
            this.enableFolderVariableRemoval.Location = new System.Drawing.Point(3, 20);
            this.enableFolderVariableRemoval.Name = "enableFolderVariableRemoval";
            this.enableFolderVariableRemoval.Size = new System.Drawing.Size(109, 17);
            this.enableFolderVariableRemoval.TabIndex = 14;
            this.enableFolderVariableRemoval.Text = "Clean Folder Text";
            this.enableFolderVariableRemoval.UseVisualStyleBackColor = true;
            this.enableFolderVariableRemoval.CheckedChanged += new System.EventHandler(this.enableFolderVariableRemoval_CheckedChanged);
            // 
            // enableFilenameVariableRemoval
            // 
            this.enableFilenameVariableRemoval.AutoSize = true;
            this.enableFilenameVariableRemoval.Location = new System.Drawing.Point(3, 70);
            this.enableFilenameVariableRemoval.Name = "enableFilenameVariableRemoval";
            this.enableFilenameVariableRemoval.Size = new System.Drawing.Size(122, 17);
            this.enableFilenameVariableRemoval.TabIndex = 15;
            this.enableFilenameVariableRemoval.Text = "Clean Filename Text";
            this.enableFilenameVariableRemoval.UseVisualStyleBackColor = true;
            this.enableFilenameVariableRemoval.CheckedChanged += new System.EventHandler(this.enableFilenameVariableRemoval_CheckedChanged);
            // 
            // enableFilenameProcessing
            // 
            this.enableFilenameProcessing.AutoSize = true;
            this.enableFilenameProcessing.Location = new System.Drawing.Point(3, 46);
            this.enableFilenameProcessing.Name = "enableFilenameProcessing";
            this.enableFilenameProcessing.Size = new System.Drawing.Size(114, 17);
            this.enableFilenameProcessing.TabIndex = 16;
            this.enableFilenameProcessing.Text = "Process Filenames";
            this.enableFilenameProcessing.UseVisualStyleBackColor = true;
            this.enableFilenameProcessing.CheckedChanged += new System.EventHandler(this.enableFilenameProcessing_CheckedChanged);
            // 
            // mainContainer
            // 
            this.mainContainer.Controls.Add(this.optionsPanel);
            this.mainContainer.Controls.Add(this.cleanTextPanel);
            this.mainContainer.Location = new System.Drawing.Point(15, 114);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(479, 121);
            this.mainContainer.TabIndex = 17;
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.enableFolderVariableRemoval);
            this.optionsPanel.Controls.Add(this.enableFilenameVariableRemoval);
            this.optionsPanel.Controls.Add(this.enableFilenameProcessing);
            this.optionsPanel.Location = new System.Drawing.Point(3, 3);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Padding = new System.Windows.Forms.Padding(0, 17, 0, 0);
            this.optionsPanel.Size = new System.Drawing.Size(132, 113);
            this.optionsPanel.TabIndex = 18;
            // 
            // cleanTextPanel
            // 
            this.cleanTextPanel.Controls.Add(this.cleanFilenameTextPanel);
            this.cleanTextPanel.Controls.Add(this.cleanFolderTextPanel);
            this.cleanTextPanel.Location = new System.Drawing.Point(141, 3);
            this.cleanTextPanel.Name = "cleanTextPanel";
            this.cleanTextPanel.Size = new System.Drawing.Size(332, 113);
            this.cleanTextPanel.TabIndex = 18;
            this.cleanTextPanel.Visible = false;
            // 
            // cleanFilenameTextPanel
            // 
            this.cleanFilenameTextPanel.Controls.Add(this.cleanFilenamesHeader);
            this.cleanFilenameTextPanel.Controls.Add(this.cleanFilenameTextLabel);
            this.cleanFilenameTextPanel.Controls.Add(this.filenameVariableRemoval);
            this.cleanFilenameTextPanel.Location = new System.Drawing.Point(3, 58);
            this.cleanFilenameTextPanel.Name = "cleanFilenameTextPanel";
            this.cleanFilenameTextPanel.Size = new System.Drawing.Size(329, 55);
            this.cleanFilenameTextPanel.TabIndex = 21;
            this.cleanFilenameTextPanel.Visible = false;
            // 
            // cleanFilenamesHeader
            // 
            this.cleanFilenamesHeader.AutoSize = true;
            this.cleanFilenamesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cleanFilenamesHeader.Location = new System.Drawing.Point(3, 7);
            this.cleanFilenamesHeader.Name = "cleanFilenamesHeader";
            this.cleanFilenamesHeader.Size = new System.Drawing.Size(166, 18);
            this.cleanFilenamesHeader.TabIndex = 12;
            this.cleanFilenamesHeader.Text = "Clean Filename Text:";
            // 
            // cleanFilenameTextLabel
            // 
            this.cleanFilenameTextLabel.AutoSize = true;
            this.cleanFilenameTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cleanFilenameTextLabel.Location = new System.Drawing.Point(3, 30);
            this.cleanFilenameTextLabel.Name = "cleanFilenameTextLabel";
            this.cleanFilenameTextLabel.Size = new System.Drawing.Size(218, 15);
            this.cleanFilenameTextLabel.TabIndex = 13;
            this.cleanFilenameTextLabel.Text = "Remove everything after and including:";
            // 
            // filenameVariableRemoval
            // 
            this.filenameVariableRemoval.Location = new System.Drawing.Point(223, 29);
            this.filenameVariableRemoval.Name = "filenameVariableRemoval";
            this.filenameVariableRemoval.Size = new System.Drawing.Size(100, 20);
            this.filenameVariableRemoval.TabIndex = 11;
            // 
            // cleanFolderTextPanel
            // 
            this.cleanFolderTextPanel.Controls.Add(this.cleanFolderTextLabel);
            this.cleanFolderTextPanel.Controls.Add(this.folderVariableRemoval);
            this.cleanFolderTextPanel.Controls.Add(this.variableRemovalHeader);
            this.cleanFolderTextPanel.Location = new System.Drawing.Point(3, 3);
            this.cleanFolderTextPanel.Name = "cleanFolderTextPanel";
            this.cleanFolderTextPanel.Size = new System.Drawing.Size(327, 54);
            this.cleanFolderTextPanel.TabIndex = 20;
            this.cleanFolderTextPanel.Visible = false;
            // 
            // cleanFolderTextLabel
            // 
            this.cleanFolderTextLabel.AutoSize = true;
            this.cleanFolderTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cleanFolderTextLabel.Location = new System.Drawing.Point(3, 30);
            this.cleanFolderTextLabel.Name = "cleanFolderTextLabel";
            this.cleanFolderTextLabel.Size = new System.Drawing.Size(218, 15);
            this.cleanFolderTextLabel.TabIndex = 6;
            this.cleanFolderTextLabel.Text = "Remove everything after and including:";
            // 
            // folderVariableRemoval
            // 
            this.folderVariableRemoval.Location = new System.Drawing.Point(226, 29);
            this.folderVariableRemoval.Name = "folderVariableRemoval";
            this.folderVariableRemoval.Size = new System.Drawing.Size(97, 20);
            this.folderVariableRemoval.TabIndex = 5;
            // 
            // variableRemovalHeader
            // 
            this.variableRemovalHeader.AutoSize = true;
            this.variableRemovalHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variableRemovalHeader.Location = new System.Drawing.Point(3, 8);
            this.variableRemovalHeader.Name = "variableRemovalHeader";
            this.variableRemovalHeader.Size = new System.Drawing.Size(146, 18);
            this.variableRemovalHeader.TabIndex = 7;
            this.variableRemovalHeader.Text = "Clean Folder Text:";
            // 
            // PeriodKiller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(510, 370);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.selectFolderLbl);
            this.Controls.Add(this.duplicatesLabel);
            this.Controls.Add(this.programName);
            this.Controls.Add(this.fixFolders);
            this.Controls.Add(this.folderPathLabel);
            this.Controls.Add(this.selectFolder);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PeriodKiller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Period Killer";
            this.mainContainer.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.cleanTextPanel.ResumeLayout(false);
            this.cleanFilenameTextPanel.ResumeLayout(false);
            this.cleanFilenameTextPanel.PerformLayout();
            this.cleanFolderTextPanel.ResumeLayout(false);
            this.cleanFolderTextPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button selectFolder;
        private System.Windows.Forms.Label folderPathLabel;
        private System.Windows.Forms.Button fixFolders;
        private System.Windows.Forms.Label programName;
        private System.Windows.Forms.LinkLabel duplicatesLabel;
        private System.Windows.Forms.Label selectFolderLbl;
        private System.Windows.Forms.CheckBox enableFolderVariableRemoval;
        private System.Windows.Forms.CheckBox enableFilenameVariableRemoval;
        private System.Windows.Forms.CheckBox enableFilenameProcessing;
        private System.Windows.Forms.FlowLayoutPanel mainContainer;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Panel cleanTextPanel;
        private System.Windows.Forms.Panel cleanFilenameTextPanel;
        private System.Windows.Forms.Label cleanFilenamesHeader;
        private System.Windows.Forms.Label cleanFilenameTextLabel;
        private System.Windows.Forms.TextBox filenameVariableRemoval;
        private System.Windows.Forms.Panel cleanFolderTextPanel;
        private System.Windows.Forms.Label cleanFolderTextLabel;
        private System.Windows.Forms.TextBox folderVariableRemoval;
        private System.Windows.Forms.Label variableRemovalHeader;

    }
}

