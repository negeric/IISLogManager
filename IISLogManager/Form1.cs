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
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace IISLogManager
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
            DBCheck();
        }

        private void DBCheck()
        {
            if (!DB.Exists())
            {
                //Database needs to be created and filled with defaults
                lblDatabase.Text = "Creating Database...";
                DB.Create();
                lblDatabase.Text = "Database Created";
            }
            else
            {
                string AppVersion = DB.getSetting("AppVer", "1.2");
                lblDatabase.Text = "Database Loaded.  App Version: " + AppVersion;
                //lblDatabase.Text = DateTime.Now.ToString();
            }
        }

        private void lnkAbout_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            IISSiteViewer frm = new IISSiteViewer();
            frm.ShowDialog();
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            contextMenuTools.Show(metroLink2, new Point(0, metroLink2.Height));
        }

        private void logCleanupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IISLogCleanup frm = new IISLogCleanup();
            frm.ShowDialog();
        }

        private void emailManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmailManager frm = new EmailManager();
            frm.ShowDialog();
        }

        private void lnkSettings_Click(object sender, EventArgs e)
        {
            contextMenuSettings.Show(lnkSettings, new Point(0, lnkSettings.Height));
        }

        private void customLogLocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomLogLocations frm = new CustomLogLocations();
            frm.ShowDialog();
        }

        private void applicationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsManager frm = new SettingsManager();
            frm.ShowDialog();
        }
    }
}
