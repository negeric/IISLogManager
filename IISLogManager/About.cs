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
    public partial class About : MetroForm
    {
        public About()
        {
            InitializeComponent();
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://jeff.forsale/apps/IISLogManager/");
        }

        private void metroLink2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/viperneo");
        }

        private void metroLink3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/dennismagno");
        }

        private void About_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.favicon;
        }
    }
}
