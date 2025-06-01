using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ProtectionLib;

namespace PaletteConverter
{
    public partial class LicForm : Form
    {
        public LicForm()
        {
            InitializeComponent();
        }
        public void UpdateLicInfo(LicenseInfo License)
        {
            NameLabel.Text = License.Name;
            OrgLabel.Text = License.Organization;
            DateLabel.Text = License.ValidUntil.ToString("dd.MM.yyyy");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
