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
    public partial class IISSiteViewer : MetroForm
    {
        public IISSiteViewer()
        {
            InitializeComponent();
        }

        private void IISSiteViewer_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
            Start();
        }
        private void Start()
        {
            txtTitle.Text = "Loading Sites...";
            loadingSpinner.Visible = true;
            txtLoading.Visible = true;
            panelSiteInfo.Visible = false;
            List<SiteInfo> sites = GetSiteInfo();
            AddSitesToGrid(sites);
            txtTitle.Text = "Loaded " + sites.Count() + " sites";
            panelSiteInfo.Visible = true;
            loadingSpinner.Visible = false;
            txtLoading.Visible = false;
        }
        private List<SiteInfo> GetSiteInfo()
        {
            return IISManager.GetSiteInfo();
        }
        private void AddSitesToGrid(List<SiteInfo> sites)
        {
            gridSites.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridSites.DataSource = sites;
        }

        private void lnkRefresh_Click(object sender, EventArgs e)
        {
            Start();
        }
    }
}
