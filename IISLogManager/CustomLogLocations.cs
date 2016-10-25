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
    public partial class CustomLogLocations : MetroForm
    {
        public CustomLogLocations()
        {
            InitializeComponent();
        }

        private void CustomLogLocations_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
            loadList();
        }

        private void loadList()
        {
            gridCustom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            List<CustomLog> logLocations = Shared.AddToCustomLog(CustomLogConfigMapSection.Config.SettingsList.ToList());
            gridCustom.DataSource = logLocations;           
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog();
            DialogResult folderRes = fld.ShowDialog();
            if (folderRes == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(fld.SelectedPath.ToString())) {
                    txtCustomLocation.Text = fld.SelectedPath.ToString();
                }
            }
        }
        private string ParseFilter(string filter)
        {
            //Remove any "."
            string f = System.Text.RegularExpressions.Regex.Replace(filter.Trim(), @"\.", "");
            return f;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string path = txtCustomLocation.Text;
            //Make sure there is a backslash at end of path
            if (path.Substring(path.Length - 1, 1) != "\\")
                path = path + "\\";
            //Remove any "." characters from the log filter
            string filter = ParseFilter(txtFilter.Text);
            if (filter != txtFilter.Text)
                txtFilter.Text = filter;
            CustomLogConfigMapConfigElement elem = new CustomLogConfigMapConfigElement();
            elem.LogExtension = filter;
            elem.LogLocation = path;
            CustomLogConfigMapSection.Config.CurrentConfiguration.Save(System.Configuration.ConfigurationSaveMode.Modified);
            //elem.CurrentConfiguration.Save(System.Configuration.ConfigurationSaveMode.Modified);
            loadList();
        }
    }
}
