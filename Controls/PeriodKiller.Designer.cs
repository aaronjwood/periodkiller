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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.selectFolder = new System.Windows.Forms.Button();
            this.pathLbl = new System.Windows.Forms.Label();
            this.fixFolders = new System.Windows.Forms.Button();
            this.programName = new System.Windows.Forms.Label();
            this.variableRemoval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.variableRemovalHeader = new System.Windows.Forms.Label();
            this.duplicatesLabel = new System.Windows.Forms.LinkLabel();
            this.selectFolderLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectFolder
            // 
            this.selectFolder.BackColor = System.Drawing.Color.Black;
            this.selectFolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.selectFolder.FlatAppearance.BorderSize = 2;
            this.selectFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGreen;
            this.selectFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.selectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectFolder.ForeColor = System.Drawing.Color.White;
            this.selectFolder.Location = new System.Drawing.Point(12, 37);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(320, 40);
            this.selectFolder.TabIndex = 0;
            this.selectFolder.Text = "Select A Folder";
            this.selectFolder.UseVisualStyleBackColor = false;
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // pathLbl
            // 
            this.pathLbl.AutoEllipsis = true;
            this.pathLbl.AutoSize = true;
            this.pathLbl.ForeColor = System.Drawing.Color.PaleGreen;
            this.pathLbl.Location = new System.Drawing.Point(12, 82);
            this.pathLbl.Name = "pathLbl";
            this.pathLbl.Size = new System.Drawing.Size(0, 13);
            this.pathLbl.TabIndex = 1;
            // 
            // fixFolders
            // 
            this.fixFolders.BackColor = System.Drawing.Color.Black;
            this.fixFolders.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.fixFolders.FlatAppearance.BorderSize = 2;
            this.fixFolders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.fixFolders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.fixFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fixFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixFolders.Location = new System.Drawing.Point(12, 198);
            this.fixFolders.Name = "fixFolders";
            this.fixFolders.Size = new System.Drawing.Size(320, 52);
            this.fixFolders.TabIndex = 2;
            this.fixFolders.Text = "Clean Folder Names";
            this.fixFolders.UseVisualStyleBackColor = false;
            this.fixFolders.Click += new System.EventHandler(this.fixFolders_Click);
            // 
            // programName
            // 
            this.programName.AutoSize = true;
            this.programName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(3)))), ((int)(((byte)(7)))));
            this.programName.Location = new System.Drawing.Point(95, 5);
            this.programName.Name = "programName";
            this.programName.Size = new System.Drawing.Size(160, 29);
            this.programName.TabIndex = 4;
            this.programName.Text = "Period Killer";
            // 
            // variableRemoval
            // 
            this.variableRemoval.Location = new System.Drawing.Point(232, 137);
            this.variableRemoval.Name = "variableRemoval";
            this.variableRemoval.Size = new System.Drawing.Size(100, 20);
            this.variableRemoval.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Remove everything after and including:";
            // 
            // variableRemovalHeader
            // 
            this.variableRemovalHeader.AutoSize = true;
            this.variableRemovalHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.variableRemovalHeader.Location = new System.Drawing.Point(69, 99);
            this.variableRemovalHeader.Name = "variableRemovalHeader";
            this.variableRemovalHeader.Size = new System.Drawing.Size(207, 18);
            this.variableRemovalHeader.TabIndex = 7;
            this.variableRemovalHeader.Text = "Optional Variable Removal";
            // 
            // duplicatesLabel
            // 
            this.duplicatesLabel.AutoSize = true;
            this.duplicatesLabel.Enabled = false;
            this.duplicatesLabel.LinkColor = System.Drawing.Color.Yellow;
            this.duplicatesLabel.Location = new System.Drawing.Point(0, 168);
            this.duplicatesLabel.Name = "duplicatesLabel";
            this.duplicatesLabel.Size = new System.Drawing.Size(0, 13);
            this.duplicatesLabel.TabIndex = 9;
            this.duplicatesLabel.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            // 
            // selectFolderLbl
            // 
            this.selectFolderLbl.AutoSize = true;
            this.selectFolderLbl.ForeColor = System.Drawing.Color.Red;
            this.selectFolderLbl.Location = new System.Drawing.Point(108, 168);
            this.selectFolderLbl.Name = "selectFolderLbl";
            this.selectFolderLbl.Size = new System.Drawing.Size(0, 13);
            this.selectFolderLbl.TabIndex = 10;
            // 
            // PeriodKiller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(344, 262);
            this.Controls.Add(this.selectFolderLbl);
            this.Controls.Add(this.duplicatesLabel);
            this.Controls.Add(this.variableRemovalHeader);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.variableRemoval);
            this.Controls.Add(this.programName);
            this.Controls.Add(this.fixFolders);
            this.Controls.Add(this.pathLbl);
            this.Controls.Add(this.selectFolder);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PeriodKiller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Period Killer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button selectFolder;
        private System.Windows.Forms.Label pathLbl;
        private System.Windows.Forms.Button fixFolders;
        private System.Windows.Forms.Label programName;
        private System.Windows.Forms.TextBox variableRemoval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label variableRemovalHeader;
        private System.Windows.Forms.LinkLabel duplicatesLabel;
        private System.Windows.Forms.Label selectFolderLbl;

    }
}

