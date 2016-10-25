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
    public partial class SettingsManager : MetroForm
    {
        public static int editSettingPassValue;
        public SettingsManager()
        {
            InitializeComponent();
            
            this.Icon = Properties.Resources.favicon;
            
            FillSettings();
        }
        private void FillSettings()
        {
            DataTable ds = DB.getSettings();
            if (ds != null)
            {
                //Data is valid, attach to grid
                try
                {
                    gridSettings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    gridSettings.DataSource = ds;
                } catch (Exception ex)
                {
                    ErrorHandler.logError("Error Loading Settings", "The database did not return proper results, see exception", "db", true, ex);
                    MetroFramework.MetroMessageBox.Show(this, "There was an error querying the settings from the database.  The exception has been logged: " + ex.ToString(), "Error Reading Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridSettings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && gridSettings.Rows[e.RowIndex].Cells[0].Value != null)
            {
                int selectedId = Convert.ToInt32(gridSettings.Rows[e.RowIndex].Cells[0].Value);
                //MetroFramework.MetroMessageBox.Show(this, "Selected Row: " + selectedId.ToString(), "Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                editSettingPassValue = selectedId;
                EditSetting frm = new EditSetting();
                frm.FormClosed += Frm_FormClosed;
                frm.ShowDialog();
            }
        }

        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillSettings();
        }

        private void lnkAddSetting_Click(object sender, EventArgs e)
        {
            editSettingPassValue = -1;
            EditSetting frm = new EditSetting();
            frm.FormClosed += Frm_FormClosed;
            frm.ShowDialog();
        }

        private void SettingsManager_Load(object sender, EventArgs e)
        {

        }

        private void lnkRestoreDefaults_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MetroFramework.MetroMessageBox.Show(this, "Are you sure you wish to restore settings to default values? This cannot be undone!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlg.ToString() == "Yes")
            {
                DB.reloadSettings();
                FillSettings();
            }
        }
    }
}
