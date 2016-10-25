using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace IISLogManager
{
    public partial class IISLogCleanup : MetroForm
    {
        private static String daysToKeepBeforeZip;
        private static String daysToKeepZipBeforeDelete;
        private static bool hasErrors;
        private static bool dryRun;
        private static int LogsZipped;
        private static int ZipsDeleted;
        private static int SitesCleaned;
        private static long ExecutionTime; 
        BackgroundWorker bw = new BackgroundWorker();        
        public IISLogCleanup()
        {
            InitializeComponent();
        }

        private void IISLogCleanup_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
            Start();
        }
        private void Start()
        {

            gridSitesToClean.Visible = false;
            lblLoading.Visible = true;
            loadingSpinner.Visible = true;
            btnCleanLogs.Enabled = false;            
            dryRun = (Settings.GetAppSetting("DryRun") == "true") ? true : false;
            if (dryRun)
                ToggleLabel(lblDryRunTop, true);
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.WorkerReportsProgress = true;
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            List<SiteInfo> sites = GetSiteInfo();
            AddSitesToGrid(sites);
            checkForErrors(sites);
            gridSitesToClean.Visible = true;
            lblLoading.Visible = false;
            loadingSpinner.Visible = false;
            //btnCleanLogs.Enabled = true;
            updateSelectedSitesLabel();
            getDaysToKeepFiles();
            updateDaysToKeep();

        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Unock Everything else
            TogglePicture(pictureCheck, true);
            ToggleGrid(gridSitesToClean, true, "disable");
            ToggleButton(btnCleanLogs, true, "disable");
            ToggleTextbox(txtLogDaysToKeep, true, "disable");
            ToggleTextbox(txtZipDaysKeep, true, "disable");
            if (Shared.CancelLogCleanup)
            {
                ToggleLabel(lblCancelled, true);
                UpdateLabelBW(lblCancelled, "Operation Canceled");
            }
            
            //Disable status
            ToggleSpinner(spinnerCleanup, false);
            string TotalRunTime = Shared.MillisecondsToHuma(ExecutionTime);
            //UpdateLabelBW(lblCleanupStatusText, "Total files zipped " + LogsZipped + ".  Total zips deleted " + ZipsDeleted + " zips");
            UpdateLabelBW(lblCleanupStatusSite, "Log Cleanup Finished in " + TotalRunTime);
            ErrorHandler.logIISCleanupInfo("Finished IIS Log Cleanup", "Zipped up " + LogsZipped + " files and removed " + ZipsDeleted + " ZIP archives on " + SitesCleaned + " sites.  Total execution time was - " + TotalRunTime);
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            CleanLogs();
            watch.Stop();
            ExecutionTime = watch.ElapsedMilliseconds;
        }
        private void checkForErrors(List<SiteInfo> tmpSites)
        {
            int errors = 0;
            foreach(SiteInfo site in tmpSites)
            {
                if (site.Status == "Error")
                    errors++;
            }
            if (errors > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "There was an error loading one ore more sites.  Please check for errors in the output grid and report any to IT", "Error Loading Sites", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCleanLogs.Enabled = false;
                hasErrors = true;
            } else
            {
                btnCleanLogs.Enabled = true;
                hasErrors = false;
            }
        }
        private void getDaysToKeepFiles()
        {
            daysToKeepBeforeZip = (Settings.GetAppSetting("DaysToKeepBeforeZip") == "error") ? Settings.defaultDaysToKeepBeforeZip : Settings.GetAppSetting("DaysToKeepBeforeZip");
            daysToKeepZipBeforeDelete = (Settings.GetAppSetting("DaysToKeepZipBeforeDelete") == "error") ? Settings.defaultDaysToKeepZipBeforeDelete : Settings.GetAppSetting("DaysToKeepZipBeforeDelete");
        }
        private List<SiteInfo> GetSiteInfo()
        {
            return IISManager.GetSiteInfo();
        }
        private void AddSitesToGrid(List<SiteInfo> sites)
        {
            gridSitesToClean.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridSitesToClean.DataSource = sites;
        }
        private void updateSelectedSitesLabel()
        {
            int selectedRows = gridSitesToClean.SelectedRows.Count;
            String txt = (selectedRows == 1) ? "1 site selected" : selectedRows.ToString() + " sites selected";
            lblSitesSelectedCount.Text = txt;
        }

        private void gridSitesToClean_SelectionChanged(object sender, EventArgs e)
        {
            updateSelectedSitesLabel();
        }
        private void updateDaysToKeep()
        {
            txtLogDaysToKeep.Text = daysToKeepBeforeZip;
            txtZipDaysKeep.Text = daysToKeepZipBeforeDelete;
        }
        private bool validateNumber(MetroFramework.Controls.MetroTextBox txt, int min, int max)
        {
            int result;
            bool ret = false;
            if (int.TryParse(txt.Text, out result))
            {
                if (result >= min && result <= max)
                    ret = true;
                else
                    ret = false;
            }
            else
                ret = false;
            return ret;
        }

        private void btnCleanLogs_Click(object sender, EventArgs e)
        {
            //Validate textboxes are integers
            if (!validateNumber(txtLogDaysToKeep, 1, 720))
                MetroFramework.MetroMessageBox.Show(this, "Days to Keep log files must be a numeric number between 1 and 720", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!validateNumber(txtZipDaysKeep, 1, 720))
                MetroFramework.MetroMessageBox.Show(this, "Days to Keep Zip files must be a numeric number between 1 and 720", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                daysToKeepBeforeZip = txtLogDaysToKeep.Text;
                daysToKeepZipBeforeDelete = txtZipDaysKeep.Text;
                bw.RunWorkerAsync();
            }
        }
        private void CleanLogs()
        {
            if (!hasErrors)
            {
                //Set CancelLogCleanup to false
                Shared.CancelLogCleanup = false;
                //Log that we're starting up the cleanup
                ErrorHandler.logIISCleanupInfo("Starting IIS Log Cleanup", "Performing cleanup on " + gridSitesToClean.SelectedRows.Count + " sites.  Days to keep logs - " + txtLogDaysToKeep.Text + " | Days to keep Zip - " + txtZipDaysKeep.Text);                
                //Lock Everything else
                TogglePicture(pictureCheck, false);
                ToggleGrid(gridSitesToClean, false, "disable");
                ToggleButton(btnCleanLogs, false, "disable");
                ToggleTextbox(txtLogDaysToKeep, false, "disable");
                ToggleTextbox(txtZipDaysKeep, false, "disable");
                ToggleButton(btnCancel, true);
                ToggleLabel(lblCancelled, false);
                //Enable status
                ToggleSpinner(spinnerCleanup, true);
                ToggleLabel(lblCleanupStatusTitle, true);
                ToggleLabel(lblCleanupStatusSite, true);
                ToggleLabel(lblCleanupStatusText, true);
                if (dryRun)
                    ToggleLabel(lblDryRunBottom, true);
                //Loop through selected sites
                int tmpSites = 0;
                int tmpTotalFilesZipped = 0;
                int tmpTotalZipsDeleted = 0;
                string DryRunText = (dryRun) ? " dry run " : "";
                foreach (DataGridViewRow r in gridSitesToClean.SelectedRows)
                {
                    //Single site isn't adding the logs zipped and deleted values to the global LogsZipped and ZipsDeleted numbers
                    int tmpSiteFilesZipped = 0;
                    int tmpSiteZipsDeleted = 0;
                    tmpSites++;                    
                    string siteName = r.Cells[1].Value.ToString();
                    string logPath = r.Cells[3].Value.ToString();
                    //Log the current site and directory
                    ErrorHandler.logIISCleanupInfo("Starting Cleanup on " + siteName, "Cleanup started on site " + siteName + " within directory " + logPath);
                    UpdateLabelBW(lblCleanupStatusSite, "Site: " + siteName);
                    UpdateLabelBW(lblCleanupStatusText, "Compressing logs... this may take a while");
                    //Do Zip
                    //UpdateLabelBW(lblCleanupStatusText, "Zipping log files older than " + daysToKeepBeforeZip);
                    tmpSiteFilesZipped = Shared.ZipFiles(siteName, @logPath.Trim(new Char[] { ' ', '*', '.', '!' }), Convert.ToInt32(daysToKeepBeforeZip), dryRun);
                    UpdateLabelBW(lblCleanupStatusText, "Deleting old archives... this may take a while");
                    tmpSiteZipsDeleted = Shared.DeleteZip(@logPath.Trim(new Char[] { ' ', '*', '.', '!' }), Convert.ToInt32(daysToKeepZipBeforeDelete), dryRun);                   
                    tmpTotalFilesZipped = tmpTotalFilesZipped + tmpSiteFilesZipped;
                    tmpTotalZipsDeleted = tmpTotalZipsDeleted + tmpSiteZipsDeleted;
                    UpdateLabelBW(lblCleanupStatusText, "Total logs zipped " + string.Format("{0:n0}", tmpTotalFilesZipped) + ".  Total zips deleted " + string.Format("{0:n0}", tmpTotalZipsDeleted) + " zips");
                    //End foreach                    
                    ErrorHandler.logIISCleanupInfo("Finished" + DryRunText + " Cleanup on " + siteName, "Cleanup finished on site " + siteName + " within directory " + logPath + ".  Total files zipped - " + tmpSiteFilesZipped + ", Total ZIPs deleted - " + tmpSiteZipsDeleted);

                }
                SitesCleaned = tmpSites;
                LogsZipped = tmpTotalFilesZipped;
                ZipsDeleted = tmpTotalZipsDeleted;                
            }

        }
        private void ToggleSpinner(MetroFramework.Controls.MetroProgressSpinner obj, bool status, String type = "hide")
        {
            try
            {
                if (obj.InvokeRequired)
                {                    
                    this.Invoke((MethodInvoker)delegate {
                        if (type == "hide")
                            obj.Visible = status;
                        else
                            obj.Enabled = status;
                    });
                }
                else
                {
                    if (type == "hide")
                        obj.Visible = status;
                    else
                        obj.Enabled = status;
                }
            } catch (Exception e)
            {
                ErrorHandler.logError("Error Hiding Spinner", "Error while hiding the spinner " + obj.Name.ToString(), "error", false);
            }
        }
        private void ToggleLabel(Label obj, bool status, String type = "hide")
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate {
                        if (type == "hide")
                            obj.Visible = status;
                        else
                            obj.Enabled = status;
                    });
                }
                else
                {
                    if (type == "hide")
                        obj.Visible = status;
                    else
                        obj.Enabled = status;
                }
            }
            catch (Exception e)
            {
                ErrorHandler.logError("Error Hiding Label", "Error while hiding the label " + obj.Name.ToString(), "error", false);
            }
        }
        private void ToggleGrid(MetroFramework.Controls.MetroGrid obj, bool status, String type = "hide")
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate {
                        if (type == "hide")
                            obj.Visible = status;
                        else
                            obj.Enabled = status;
                    });
                }
                else
                {
                    if (type == "hide")
                        obj.Visible = status;
                    else
                        obj.Enabled = status;
                }
            }
            catch (Exception e)
            {
                ErrorHandler.logError("Error Hiding Grid", "Error while hiding the grid " + obj.Name.ToString(), "error", false);
            }
        }
        private void ToggleButton(Button obj, bool status, String type = "hide")
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate {
                        if (type == "hide")
                            obj.Visible = status;
                        else
                            obj.Enabled = status;
                    });
                }
                else
                {
                    if (type == "hide")
                        obj.Visible = status;
                    else
                        obj.Enabled = status;
                }
            }
            catch (Exception e)
            {
                ErrorHandler.logError("Error Hiding Button", "Error while hiding the button " + obj.Name.ToString(), "error", false);
            }
        }
        private void ToggleTextbox(MetroFramework.Controls.MetroTextBox obj, bool status, String type = "hide")
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate {
                        if (type == "hide")
                            obj.Visible = status;
                        else
                            obj.Enabled = status;
                    });
                }
                else
                {
                    if (type == "hide")
                        obj.Visible = status;
                    else
                        obj.Enabled = status;
                }
            }
            catch (Exception e)
            {
                ErrorHandler.logError("Error Hiding Textbox", "Error while hiding the textbox " + obj.Name.ToString(), "error", false);
            }
        }
        private void TogglePicture(PictureBox obj, bool status, String type = "hide")
        {
            try
            {
                if (obj.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate {
                        if (type == "hide")
                            obj.Visible = status;
                        else
                            obj.Enabled = status;
                    });
                }
                else
                {
                    if (type == "hide")
                        obj.Visible = status;
                    else
                        obj.Enabled = status;
                }
            }
            catch (Exception e)
            {
                ErrorHandler.logError("Error Hiding PictureBox", "Error while hiding the picturebox " + obj.Name.ToString(), "error", false);
            }
        }
        private void UpdateLabelBW(Label lbl, String txt)
        {
            if (lbl.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { lbl.Text = txt; });
            } else
            {
                lbl.Text = txt;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bw.IsBusy)
            {
                Shared.CancelLogCleanup = true;
                lblCancelled.Enabled = true;
                lblCancelled.Text = "Canceling Operation...";
            }
        }
    }
}
