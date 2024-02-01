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
    public partial class AutoGeneratePanels : Form
    {
        public AutoGeneratePanels()
        {
            InitializeComponent();
        }

        public int NumRows => (int)numRows.Value;
        public int NumCols => (int)numCols.Value;
        public int PadVert => (int)padV.Value;
        public int PadHor => (int)padH.Value;

        private void btnGenerate_Click(object sender, EventArgs e)
        {

        }
    }



}
