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
    public partial class EditSetting : MetroForm
    {
        private static int settingId;
        private static bool newSetting;
        public EditSetting()
        {
            InitializeComponent();
        }
        private void start()
        {
            getSetting();
            if (settingId > -1)
            {
                newSetting = false;       
                DataTable setting = DB.getSettingDetails(settingId);
                this.Text = "Edit Setting";
                if (Settings.isSettingLocked(setting.Rows[0].Field<string>("name")))
                {
                    //Private/locked setting
                    txtName.Enabled = false;
                    txtValue.Enabled = false;
                    txtDesc.Enabled = false;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    this.Text = "Edit Setting - Protected";
                }
                txtName.Text = setting.Rows[0].Field<string>("name");
                txtValue.Text = setting.Rows[0].Field<string>("value");
                txtDesc.Text = setting.Rows[0].Field<string>("description");
                
            } else
            {
                newSetting = true;
                this.Text = "Add Setting";
            }
        }
        private static void getSetting()
        {
            if (SettingsManager.editSettingPassValue > -1)
            {
                int val = SettingsManager.editSettingPassValue;
                SettingsManager.editSettingPassValue = -1;
                settingId = val;
            }
            else
            {
                settingId = -1;
            }
        }

        private void EditSetting_Load(object sender, EventArgs e)
        {
            start();
        }        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!newSetting)
            { //This is an update
                bool updated = DB.updateSetting(settingId, txtName.Text, txtValue.Text, txtDesc.Text);
                if (updated)
                    this.Close();
                else
                    MetroFramework.MetroMessageBox.Show(this, "There was an error while updating the selected setting.  Please see the error-log for further details", "Error Updating Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                bool created = DB.newSetting(txtName.Text, txtValue.Text, txtDesc.Text);
                if (created)
                    this.Close();
                else
                    MetroFramework.MetroMessageBox.Show(this, "There was an error while creating this setting.  Please see the error-log for further details", "Error Creating Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MetroFramework.MetroMessageBox.Show(this, "Are you sure you wish to delete this setting? There is no way to recover this", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dlg.ToString() == "Yes")
            {
                if (DB.deleteSetting(settingId))
                    this.Close();
                else
                    MetroFramework.MetroMessageBox.Show(this, "There was an error while deleting this setting.  Please see the error-log for further details", "Error Deleting Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
