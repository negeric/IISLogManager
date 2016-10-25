namespace IISLogManager
{
    partial class IISLogCleanup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.gridSitesToClean = new MetroFramework.Controls.MetroGrid();
            this.loadingSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.lblLoading = new MetroFramework.Controls.MetroLabel();
            this.btnCleanLogs = new MetroFramework.Controls.MetroButton();
            this.lblSitesSelectedCount = new MetroFramework.Controls.MetroLabel();
            this.txtZipDaysKeep = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtLogDaysToKeep = new MetroFramework.Controls.MetroTextBox();
            this.tipDaysToKeepLogFiles = new MetroFramework.Components.MetroToolTip();
            this.spinnerCleanup = new MetroFramework.Controls.MetroProgressSpinner();
            this.lblCleanupStatusTitle = new MetroFramework.Controls.MetroLabel();
            this.lblCleanupStatusSite = new MetroFramework.Controls.MetroLabel();
            this.lblCleanupStatusText = new MetroFramework.Controls.MetroLabel();
            this.pictureCheck = new System.Windows.Forms.PictureBox();
            this.lblDryRunBottom = new MetroFramework.Controls.MetroLabel();
            this.lblDryRunTop = new MetroFramework.Controls.MetroLabel();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.lblCancelled = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridSitesToClean)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 64);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(149, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Select Site(s) to Cleanup";
            // 
            // gridSitesToClean
            // 
            this.gridSitesToClean.AllowUserToAddRows = false;
            this.gridSitesToClean.AllowUserToDeleteRows = false;
            this.gridSitesToClean.AllowUserToResizeRows = false;
            this.gridSitesToClean.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSitesToClean.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridSitesToClean.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSitesToClean.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridSitesToClean.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSitesToClean.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSitesToClean.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSitesToClean.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridSitesToClean.EnableHeadersVisualStyles = false;
            this.gridSitesToClean.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridSitesToClean.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridSitesToClean.Location = new System.Drawing.Point(24, 87);
            this.gridSitesToClean.Name = "gridSitesToClean";
            this.gridSitesToClean.ReadOnly = true;
            this.gridSitesToClean.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSitesToClean.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSitesToClean.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSitesToClean.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSitesToClean.Size = new System.Drawing.Size(853, 228);
            this.gridSitesToClean.TabIndex = 1;
            this.gridSitesToClean.SelectionChanged += new System.EventHandler(this.gridSitesToClean_SelectionChanged);
            // 
            // loadingSpinner
            // 
            this.loadingSpinner.Location = new System.Drawing.Point(372, 123);
            this.loadingSpinner.Maximum = 100;
            this.loadingSpinner.Name = "loadingSpinner";
            this.loadingSpinner.Size = new System.Drawing.Size(128, 128);
            this.loadingSpinner.TabIndex = 2;
            this.loadingSpinner.UseSelectable = true;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Location = new System.Drawing.Point(390, 254);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(95, 19);
            this.lblLoading.TabIndex = 3;
            this.lblLoading.Text = "Loading Sites...";
            // 
            // btnCleanLogs
            // 
            this.btnCleanLogs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCleanLogs.Location = new System.Drawing.Point(24, 324);
            this.btnCleanLogs.Name = "btnCleanLogs";
            this.btnCleanLogs.Size = new System.Drawing.Size(75, 23);
            this.btnCleanLogs.TabIndex = 4;
            this.btnCleanLogs.Text = "Clean Logs";
            this.btnCleanLogs.UseSelectable = true;
            this.btnCleanLogs.Click += new System.EventHandler(this.btnCleanLogs_Click);
            // 
            // lblSitesSelectedCount
            // 
            this.lblSitesSelectedCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSitesSelectedCount.AutoSize = true;
            this.lblSitesSelectedCount.Location = new System.Drawing.Point(105, 324);
            this.lblSitesSelectedCount.Name = "lblSitesSelectedCount";
            this.lblSitesSelectedCount.Size = new System.Drawing.Size(65, 19);
            this.lblSitesSelectedCount.TabIndex = 5;
            this.lblSitesSelectedCount.Text = "Loading...";
            // 
            // txtZipDaysKeep
            // 
            this.txtZipDaysKeep.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtZipDaysKeep.Lines = new string[0];
            this.txtZipDaysKeep.Location = new System.Drawing.Point(829, 320);
            this.txtZipDaysKeep.MaxLength = 3;
            this.txtZipDaysKeep.Name = "txtZipDaysKeep";
            this.txtZipDaysKeep.PasswordChar = '\0';
            this.txtZipDaysKeep.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtZipDaysKeep.SelectedText = "";
            this.txtZipDaysKeep.Size = new System.Drawing.Size(48, 23);
            this.txtZipDaysKeep.TabIndex = 6;
            this.txtZipDaysKeep.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(695, 322);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(133, 19);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "Days to keep Zip files";
            this.tipDaysToKeepLogFiles.SetToolTip(this.metroLabel2, " Zip files older than this value will be deleted");
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(503, 322);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(133, 19);
            this.metroLabel3.TabIndex = 9;
            this.metroLabel3.Text = "Days to keep log files";
            this.tipDaysToKeepLogFiles.SetToolTip(this.metroLabel3, "Logs older than this value will be compressed");
            // 
            // txtLogDaysToKeep
            // 
            this.txtLogDaysToKeep.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtLogDaysToKeep.Lines = new string[0];
            this.txtLogDaysToKeep.Location = new System.Drawing.Point(637, 320);
            this.txtLogDaysToKeep.MaxLength = 3;
            this.txtLogDaysToKeep.Name = "txtLogDaysToKeep";
            this.txtLogDaysToKeep.PasswordChar = '\0';
            this.txtLogDaysToKeep.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLogDaysToKeep.SelectedText = "";
            this.txtLogDaysToKeep.Size = new System.Drawing.Size(48, 23);
            this.txtLogDaysToKeep.TabIndex = 8;
            this.txtLogDaysToKeep.UseSelectable = true;
            // 
            // tipDaysToKeepLogFiles
            // 
            this.tipDaysToKeepLogFiles.Style = MetroFramework.MetroColorStyle.Blue;
            this.tipDaysToKeepLogFiles.StyleManager = null;
            this.tipDaysToKeepLogFiles.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // spinnerCleanup
            // 
            this.spinnerCleanup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinnerCleanup.Location = new System.Drawing.Point(24, 363);
            this.spinnerCleanup.Maximum = 100;
            this.spinnerCleanup.Name = "spinnerCleanup";
            this.spinnerCleanup.Size = new System.Drawing.Size(128, 128);
            this.spinnerCleanup.TabIndex = 10;
            this.spinnerCleanup.UseSelectable = true;
            this.spinnerCleanup.Visible = false;
            // 
            // lblCleanupStatusTitle
            // 
            this.lblCleanupStatusTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCleanupStatusTitle.AutoSize = true;
            this.lblCleanupStatusTitle.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblCleanupStatusTitle.Location = new System.Drawing.Point(175, 363);
            this.lblCleanupStatusTitle.Name = "lblCleanupStatusTitle";
            this.lblCleanupStatusTitle.Size = new System.Drawing.Size(107, 19);
            this.lblCleanupStatusTitle.TabIndex = 11;
            this.lblCleanupStatusTitle.Text = "Cleanup Status";
            this.lblCleanupStatusTitle.Visible = false;
            // 
            // lblCleanupStatusSite
            // 
            this.lblCleanupStatusSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCleanupStatusSite.AutoSize = true;
            this.lblCleanupStatusSite.Location = new System.Drawing.Point(175, 386);
            this.lblCleanupStatusSite.Name = "lblCleanupStatusSite";
            this.lblCleanupStatusSite.Size = new System.Drawing.Size(94, 19);
            this.lblCleanupStatusSite.TabIndex = 12;
            this.lblCleanupStatusSite.Text = "Site: Initializing";
            this.lblCleanupStatusSite.Visible = false;
            // 
            // lblCleanupStatusText
            // 
            this.lblCleanupStatusText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCleanupStatusText.AutoSize = true;
            this.lblCleanupStatusText.Location = new System.Drawing.Point(175, 409);
            this.lblCleanupStatusText.Name = "lblCleanupStatusText";
            this.lblCleanupStatusText.Size = new System.Drawing.Size(154, 19);
            this.lblCleanupStatusText.TabIndex = 13;
            this.lblCleanupStatusText.Text = "Initializing Cleanup Utility";
            this.lblCleanupStatusText.Visible = false;
            // 
            // pictureCheck
            // 
            this.pictureCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureCheck.Image = global::IISLogManager.Properties.Resources.Checkmark128x128;
            this.pictureCheck.Location = new System.Drawing.Point(23, 353);
            this.pictureCheck.Name = "pictureCheck";
            this.pictureCheck.Size = new System.Drawing.Size(128, 128);
            this.pictureCheck.TabIndex = 14;
            this.pictureCheck.TabStop = false;
            this.pictureCheck.Visible = false;
            // 
            // lblDryRunBottom
            // 
            this.lblDryRunBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDryRunBottom.AutoSize = true;
            this.lblDryRunBottom.Location = new System.Drawing.Point(175, 432);
            this.lblDryRunBottom.Name = "lblDryRunBottom";
            this.lblDryRunBottom.Size = new System.Drawing.Size(297, 19);
            this.lblDryRunBottom.TabIndex = 15;
            this.lblDryRunBottom.Text = "Dry Run Only.  Files will not be deleted or Zipped";
            this.lblDryRunBottom.Visible = false;
            // 
            // lblDryRunTop
            // 
            this.lblDryRunTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDryRunTop.AutoSize = true;
            this.lblDryRunTop.Location = new System.Drawing.Point(580, 64);
            this.lblDryRunTop.Name = "lblDryRunTop";
            this.lblDryRunTop.Size = new System.Drawing.Size(297, 19);
            this.lblDryRunTop.TabIndex = 16;
            this.lblDryRunTop.Text = "Dry Run Only.  Files will not be deleted or Zipped";
            this.lblDryRunTop.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(175, 458);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblCancelled
            // 
            this.lblCancelled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCancelled.AutoSize = true;
            this.lblCancelled.Location = new System.Drawing.Point(256, 462);
            this.lblCancelled.Name = "lblCancelled";
            this.lblCancelled.Size = new System.Drawing.Size(118, 19);
            this.lblCancelled.TabIndex = 18;
            this.lblCancelled.Text = "Cleanup Cancelled";
            this.lblCancelled.Visible = false;
            // 
            // IISLogCleanup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.lblCancelled);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDryRunTop);
            this.Controls.Add(this.lblDryRunBottom);
            this.Controls.Add(this.pictureCheck);
            this.Controls.Add(this.lblCleanupStatusText);
            this.Controls.Add(this.lblCleanupStatusSite);
            this.Controls.Add(this.lblCleanupStatusTitle);
            this.Controls.Add(this.spinnerCleanup);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.txtLogDaysToKeep);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.txtZipDaysKeep);
            this.Controls.Add(this.lblSitesSelectedCount);
            this.Controls.Add(this.btnCleanLogs);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.loadingSpinner);
            this.Controls.Add(this.gridSitesToClean);
            this.Controls.Add(this.metroLabel1);
            this.Name = "IISLogCleanup";
            this.Text = "IIS Log Cleanup";
            this.Load += new System.EventHandler(this.IISLogCleanup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSitesToClean)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroGrid gridSitesToClean;
        private MetroFramework.Controls.MetroProgressSpinner loadingSpinner;
        private MetroFramework.Controls.MetroLabel lblLoading;
        private MetroFramework.Controls.MetroButton btnCleanLogs;
        private MetroFramework.Controls.MetroLabel lblSitesSelectedCount;
        private MetroFramework.Controls.MetroTextBox txtZipDaysKeep;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Components.MetroToolTip tipDaysToKeepLogFiles;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtLogDaysToKeep;
        private MetroFramework.Controls.MetroProgressSpinner spinnerCleanup;
        private MetroFramework.Controls.MetroLabel lblCleanupStatusTitle;
        private MetroFramework.Controls.MetroLabel lblCleanupStatusSite;
        private MetroFramework.Controls.MetroLabel lblCleanupStatusText;
        private System.Windows.Forms.PictureBox pictureCheck;
        private MetroFramework.Controls.MetroLabel lblDryRunBottom;
        private MetroFramework.Controls.MetroLabel lblDryRunTop;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroLabel lblCancelled;
    }
}