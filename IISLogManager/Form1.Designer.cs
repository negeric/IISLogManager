namespace IISLogManager
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.lnkAbout = new MetroFramework.Controls.MetroLink();
            this.lnkSettings = new MetroFramework.Controls.MetroLink();
            this.metroLink1 = new MetroFramework.Controls.MetroLink();
            this.metroLink2 = new MetroFramework.Controls.MetroLink();
            this.contextMenuTools = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.logCleanupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customLogLocationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSettings = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.emailManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDatabase = new MetroFramework.Controls.MetroLabel();
            this.applicationSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuTools.SuspendLayout();
            this.contextMenuSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnkAbout
            // 
            this.lnkAbout.Location = new System.Drawing.Point(579, 29);
            this.lnkAbout.Name = "lnkAbout";
            this.lnkAbout.Size = new System.Drawing.Size(75, 23);
            this.lnkAbout.TabIndex = 0;
            this.lnkAbout.Text = "About";
            this.lnkAbout.UseSelectable = true;
            this.lnkAbout.UseStyleColors = true;
            this.lnkAbout.Click += new System.EventHandler(this.lnkAbout_Click);
            // 
            // lnkSettings
            // 
            this.lnkSettings.Location = new System.Drawing.Point(498, 29);
            this.lnkSettings.Name = "lnkSettings";
            this.lnkSettings.Size = new System.Drawing.Size(75, 23);
            this.lnkSettings.TabIndex = 1;
            this.lnkSettings.Text = "Settings";
            this.lnkSettings.UseSelectable = true;
            this.lnkSettings.UseStyleColors = true;
            this.lnkSettings.Click += new System.EventHandler(this.lnkSettings_Click);
            // 
            // metroLink1
            // 
            this.metroLink1.Location = new System.Drawing.Point(405, 29);
            this.metroLink1.Name = "metroLink1";
            this.metroLink1.Size = new System.Drawing.Size(87, 23);
            this.metroLink1.TabIndex = 2;
            this.metroLink1.Text = "Site Manager";
            this.metroLink1.UseSelectable = true;
            this.metroLink1.UseStyleColors = true;
            this.metroLink1.Click += new System.EventHandler(this.metroLink1_Click);
            // 
            // metroLink2
            // 
            this.metroLink2.Location = new System.Drawing.Point(324, 29);
            this.metroLink2.Name = "metroLink2";
            this.metroLink2.Size = new System.Drawing.Size(75, 23);
            this.metroLink2.TabIndex = 3;
            this.metroLink2.Text = "Tools";
            this.metroLink2.UseSelectable = true;
            this.metroLink2.UseStyleColors = true;
            this.metroLink2.Click += new System.EventHandler(this.metroLink2_Click);
            // 
            // contextMenuTools
            // 
            this.contextMenuTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logCleanupToolStripMenuItem,
            this.customLogLocationsToolStripMenuItem});
            this.contextMenuTools.Name = "contextMenuTools";
            this.contextMenuTools.Size = new System.Drawing.Size(194, 48);
            // 
            // logCleanupToolStripMenuItem
            // 
            this.logCleanupToolStripMenuItem.Name = "logCleanupToolStripMenuItem";
            this.logCleanupToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.logCleanupToolStripMenuItem.Text = "Log Cleanup";
            this.logCleanupToolStripMenuItem.Click += new System.EventHandler(this.logCleanupToolStripMenuItem_Click);
            // 
            // customLogLocationsToolStripMenuItem
            // 
            this.customLogLocationsToolStripMenuItem.Name = "customLogLocationsToolStripMenuItem";
            this.customLogLocationsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.customLogLocationsToolStripMenuItem.Text = "Custom Log Locations";
            this.customLogLocationsToolStripMenuItem.Click += new System.EventHandler(this.customLogLocationsToolStripMenuItem_Click);
            // 
            // contextMenuSettings
            // 
            this.contextMenuSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationSettingsToolStripMenuItem,
            this.emailManagerToolStripMenuItem});
            this.contextMenuSettings.Name = "contextMenuSettings";
            this.contextMenuSettings.Size = new System.Drawing.Size(181, 70);
            // 
            // emailManagerToolStripMenuItem
            // 
            this.emailManagerToolStripMenuItem.Name = "emailManagerToolStripMenuItem";
            this.emailManagerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.emailManagerToolStripMenuItem.Text = "Email Manager";
            this.emailManagerToolStripMenuItem.Click += new System.EventHandler(this.emailManagerToolStripMenuItem_Click);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatabase.Location = new System.Drawing.Point(405, 453);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(237, 23);
            this.lblDatabase.TabIndex = 4;
            this.lblDatabase.Text = "Loading Database...";
            this.lblDatabase.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // applicationSettingsToolStripMenuItem
            // 
            this.applicationSettingsToolStripMenuItem.Name = "applicationSettingsToolStripMenuItem";
            this.applicationSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.applicationSettingsToolStripMenuItem.Text = "Application Settings";
            this.applicationSettingsToolStripMenuItem.Click += new System.EventHandler(this.applicationSettingsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 477);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.metroLink2);
            this.Controls.Add(this.metroLink1);
            this.Controls.Add(this.lnkSettings);
            this.Controls.Add(this.lnkAbout);
            this.Name = "Form1";
            this.Text = "IIS Log Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuTools.ResumeLayout(false);
            this.contextMenuSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLink lnkAbout;
        private MetroFramework.Controls.MetroLink lnkSettings;
        private MetroFramework.Controls.MetroLink metroLink1;
        private MetroFramework.Controls.MetroLink metroLink2;
        private MetroFramework.Controls.MetroContextMenu contextMenuTools;
        private System.Windows.Forms.ToolStripMenuItem logCleanupToolStripMenuItem;
        private MetroFramework.Controls.MetroContextMenu contextMenuSettings;
        private System.Windows.Forms.ToolStripMenuItem emailManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customLogLocationsToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel lblDatabase;
        private System.Windows.Forms.ToolStripMenuItem applicationSettingsToolStripMenuItem;
    }
}

