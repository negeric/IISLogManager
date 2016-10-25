namespace IISLogManager
{
    partial class IISSiteViewer
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
            this.loadingSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.txtLoading = new MetroFramework.Controls.MetroLabel();
            this.txtTitle = new MetroFramework.Controls.MetroLabel();
            this.panelSiteInfo = new MetroFramework.Controls.MetroPanel();
            this.gridSites = new MetroFramework.Controls.MetroGrid();
            this.lnkRefresh = new MetroFramework.Controls.MetroLink();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.panelSiteInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSites)).BeginInit();
            this.SuspendLayout();
            // 
            // loadingSpinner
            // 
            this.loadingSpinner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadingSpinner.Location = new System.Drawing.Point(365, 189);
            this.loadingSpinner.Maximum = 100;
            this.loadingSpinner.Name = "loadingSpinner";
            this.loadingSpinner.Size = new System.Drawing.Size(128, 128);
            this.loadingSpinner.TabIndex = 1;
            this.loadingSpinner.UseSelectable = true;
            this.loadingSpinner.Visible = false;
            // 
            // txtLoading
            // 
            this.txtLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtLoading.AutoSize = true;
            this.txtLoading.Location = new System.Drawing.Point(382, 320);
            this.txtLoading.Name = "txtLoading";
            this.txtLoading.Size = new System.Drawing.Size(95, 19);
            this.txtLoading.TabIndex = 2;
            this.txtLoading.Text = "Loading Sites...";
            this.txtLoading.Visible = false;
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Location = new System.Drawing.Point(23, 74);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(95, 19);
            this.txtTitle.TabIndex = 3;
            this.txtTitle.Text = "Loading Sites...";
            // 
            // panelSiteInfo
            // 
            this.panelSiteInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSiteInfo.AutoScroll = true;
            this.panelSiteInfo.Controls.Add(this.gridSites);
            this.panelSiteInfo.HorizontalScrollbar = true;
            this.panelSiteInfo.HorizontalScrollbarBarColor = true;
            this.panelSiteInfo.HorizontalScrollbarHighlightOnWheel = false;
            this.panelSiteInfo.HorizontalScrollbarSize = 10;
            this.panelSiteInfo.Location = new System.Drawing.Point(23, 108);
            this.panelSiteInfo.Name = "panelSiteInfo";
            this.panelSiteInfo.Size = new System.Drawing.Size(854, 369);
            this.panelSiteInfo.TabIndex = 4;
            this.panelSiteInfo.VerticalScrollbar = true;
            this.panelSiteInfo.VerticalScrollbarBarColor = true;
            this.panelSiteInfo.VerticalScrollbarHighlightOnWheel = false;
            this.panelSiteInfo.VerticalScrollbarSize = 10;
            // 
            // gridSites
            // 
            this.gridSites.AllowUserToAddRows = false;
            this.gridSites.AllowUserToDeleteRows = false;
            this.gridSites.AllowUserToResizeRows = false;
            this.gridSites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSites.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridSites.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSites.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridSites.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSites.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSites.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridSites.EnableHeadersVisualStyles = false;
            this.gridSites.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridSites.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridSites.Location = new System.Drawing.Point(3, 3);
            this.gridSites.Name = "gridSites";
            this.gridSites.ReadOnly = true;
            this.gridSites.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSites.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSites.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSites.Size = new System.Drawing.Size(851, 366);
            this.gridSites.TabIndex = 2;
            // 
            // lnkRefresh
            // 
            this.lnkRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkRefresh.Location = new System.Drawing.Point(802, 74);
            this.lnkRefresh.Name = "lnkRefresh";
            this.lnkRefresh.Size = new System.Drawing.Size(75, 23);
            this.lnkRefresh.TabIndex = 5;
            this.lnkRefresh.Text = "Refresh";
            this.lnkRefresh.UseSelectable = true;
            this.lnkRefresh.UseStyleColors = true;
            this.lnkRefresh.Click += new System.EventHandler(this.lnkRefresh_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 478);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(217, 19);
            this.metroLabel1.TabIndex = 6;
            this.metroLabel1.Text = "* Site is using IIS Advanced Logging";
            // 
            // metroLabel2
            // 
            this.metroLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(632, 478);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(245, 19);
            this.metroLabel2.TabIndex = 7;
            this.metroLabel2.Text = "! Advanced Logging Directory not found";
            // 
            // IISSiteViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.lnkRefresh);
            this.Controls.Add(this.panelSiteInfo);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtLoading);
            this.Controls.Add(this.loadingSpinner);
            this.Name = "IISSiteViewer";
            this.ShowInTaskbar = false;
            this.Text = "IIS Site Viewer";
            this.Load += new System.EventHandler(this.IISSiteViewer_Load);
            this.panelSiteInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSites)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroProgressSpinner loadingSpinner;
        private MetroFramework.Controls.MetroLabel txtLoading;
        private MetroFramework.Controls.MetroLabel txtTitle;
        private MetroFramework.Controls.MetroPanel panelSiteInfo;
        private MetroFramework.Controls.MetroGrid gridSites;
        private MetroFramework.Controls.MetroLink lnkRefresh;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}