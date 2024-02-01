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
    public partial class DetectEdges : Form
    {
        public DetectEdges()
        {
            InitializeComponent();
        }

        public int Sensitivity => (int)numericUpDown1.Value;
        public bool SimplifyRectangleOutput => checkBox1.Checked;
        private void DetectEdges_Load(object sender, EventArgs e)
        {

        }
    }
}
