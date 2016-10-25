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
    public partial class EmailManager : MetroForm
    {
        public EmailManager()
        {
            InitializeComponent();
        }

        private void EmailManager_Load(object sender, EventArgs e)
        {
            //LoadValues();
        }
        private void LoadValues()
        {
            try {
                string to = Settings.GetAppSetting("SMTPToAddress", "");
                string from = Settings.GetAppSetting("SMTPFromAddress", "");
                string server = Settings.GetAppSetting("SMTPServer", "");
                bool auth = (Settings.GetAppSetting("SMTPUseAuth") == "true") ? true : false;
                string user = Settings.GetAppSetting("SMTPUser", "");
                string password = Settings.GetAppSetting("SMTPPass", "");
                txtTo.Text = to;
                txtFrom.Text = from;
                txtServer.Text = server;
                txtUser.Text = user;
                txtPass.Text = password;
                toggleAuth.Checked = auth;
            } 
            catch (Exception ex)
            {
                ErrorHandler.logError("Error Loading Values", "See exception for details", "error", true, ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            Settings.SetAppSetting("SMTPToAddress", txtTo.Text);
            Settings.SetAppSetting("SMTPFromAddress", txtFrom.Text);
            Settings.SetAppSetting("SMTPServer", txtServer.Text);
            Settings.SetAppSetting("SMTPUseAuth", toggleAuth.Checked.ToString());
            Settings.SetAppSetting("SMTPUser", txtUser.Text);
            Settings.SetAppSetting("SMTPPass", txtPass.Text);
            MetroFramework.MetroMessageBox.Show(this, "Email Manager Settings have been saved to the application configuration file", "Email Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //Toggle(true);
            //MetroFramework.MetroMessageBox.Show(this, "Toggle Value - " + toggleAuth.Checked.ToString(), "Email Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Check for unsaved changed
            if (SettingsChanged())
            {                
                DialogResult dlg = MetroFramework.MetroMessageBox.Show(this, "There are unsaved changes to the email manager values. Do you wish to save them now?", "Email Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlg.ToString() == "Yes")
                {
                    SaveChanges();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Changes NOT Saved", "Email Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            int sendValue = SendTest();
            if (sendValue == -2)
                MetroFramework.MetroMessageBox.Show(this, "Error: SMTP Test Message failed with error code -2.  Please see the application error log for further details", "Email Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (sendValue == -1)
                MetroFramework.MetroMessageBox.Show(this, "Error: SMTP Test Message failed due to invalid recipient", "Email Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MetroFramework.MetroMessageBox.Show(this, "Message sent with return value of " + sendValue.ToString(), "Email Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Toggle(false);
        }

        private int SendTest()
        {
            int ret = Mailer.SendMail("Test SMTP Message", "This is a test SMTP Message, if you're readin this, It WORKED!!!!");
            return ret;
        }
        private bool SettingsChanged()
        {
            string to = Settings.GetAppSetting("SMTPToAddress", "");
            string from = Settings.GetAppSetting("SMTPFromAddress", "");
            string server = Settings.GetAppSetting("SMTPServer", "");
            bool auth = (Settings.GetAppSetting("SMTPUseAuth") == "true") ? true : false;
            string user = Settings.GetAppSetting("SMTPUser", "");
            string password = Settings.GetAppSetting("SMTPPass", "");
            bool changed = false;
            if (to != txtTo.Text)
                changed = true;
            if (from != txtFrom.Text)
                changed = true;
            if (server != txtServer.Text)
                changed = true;
            if (auth && !toggleAuth.Checked)
                changed = true;
            if (user != txtUser.Text)
                changed = true;
            if (password != txtPass.Text)
                changed = true;
            return changed;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (SettingsChanged())
            {
                DialogResult dlg = MetroFramework.MetroMessageBox.Show(this, "There are unsaved changes to the email manager values. Do you wish to save them now?", "Email Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlg.ToString() == "Yes")
                {
                    SaveChanges();
                }                
            }
            LoadValues();
        }
        private void Toggle(bool hide)
        {
            bool main = (hide) ? false : true;
            bool spinner = (hide) ? true : false;
            txtFrom.Enabled = main;
            txtPass.Enabled = main;
            txtServer.Enabled = main;
            txtTo.Enabled = main;
            txtUser.Enabled = main;
            btnCancel.Enabled = main;
            btnSave.Enabled = main;
            btnTest.Enabled = main;
            
            
        }
    }
}
