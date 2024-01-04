using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSlicer
{
    public partial class frmExportOptions : Form
    {
        public frmExportOptions()
        {
            InitializeComponent();
        }

        public string ImageSourceFolder { get; set; }
        public int PanelStartNumber => (int)panelNumStart.Value;
        public string ImageName { get; private set; }

        private void btnExport_Click(object sender, EventArgs e)
        {

            if (txtOutputName.Text.Trim() == "")
            {
                MessageBox.Show("Must select an output name");
                txtOutputName.Focus();
                return;
            }
            else if (!Directory.Exists(txtPath.Text.Trim()))
            {
                MessageBox.Show("Must select an output directory");
                txtPath.Focus();
                return;
            }

            DialogResult = DialogResult.OK;

        }

        /// <summary>
        /// Select an export forlder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog popupForm = new FolderBrowserDialog();
            popupForm.InitialDirectory = ImageSourceFolder;
            if (popupForm.ShowDialog() == DialogResult.OK)
            {
                ImageSourceFolder = txtPath.Text = popupForm.SelectedPath;
            }
        }

        private void frmExportOptions_Shown(object sender, EventArgs e)
        {
            txtPath.Text = ImageSourceFolder; ;
            ImageName = txtOutputName.Text.Trim();
        }

        private void txtOutputName_TextChanged(object sender, EventArgs e)
        {
            ImageName = txtOutputName.Text.Trim();
        }
    }
}
