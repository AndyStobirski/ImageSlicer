namespace Cropper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            propertyGrid1 = new PropertyGrid();
            panel1 = new Panel();
            selectionWidth = new NumericUpDown();
            selectionHeight = new NumericUpDown();
            label2 = new Label();
            txtOutputName = new TextBox();
            llGenerate = new LinkLabel();
            groupBox1 = new GroupBox();
            padH = new NumericUpDown();
            padV = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            numRows = new NumericUpDown();
            numCols = new NumericUpDown();
            groupBox2 = new GroupBox();
            panelNumStart = new NumericUpDown();
            label7 = new Label();
            groupBox3 = new GroupBox();
            label9 = new Label();
            label8 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            treeView1 = new TreeView();
            tabPage2 = new TabPage();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            removeAllPanelsToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            exportImagesToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)selectionWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)selectionHeight).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)padH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)padV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCols).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelNumStart).BeginInit();
            groupBox3.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(910, 759);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += Form1_Paint;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.MouseDoubleClick += Form1_MouseDoubleClick;
            pictureBox1.MouseDown += Form1_MouseDown;
            pictureBox1.MouseMove += Form1_MouseMove;
            pictureBox1.MouseUp += Form1_MouseUp;
            // 
            // propertyGrid1
            // 
            propertyGrid1.HelpVisible = false;
            propertyGrid1.Location = new Point(3, 6);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(351, 179);
            propertyGrid1.TabIndex = 2;
            propertyGrid1.ToolbarVisible = false;
            propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(376, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(1292, 1054);
            panel1.TabIndex = 3;
            // 
            // selectionWidth
            // 
            selectionWidth.Location = new Point(15, 64);
            selectionWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            selectionWidth.Minimum = new decimal(new int[] { 32, 0, 0, 0 });
            selectionWidth.Name = "selectionWidth";
            selectionWidth.Size = new Size(103, 31);
            selectionWidth.TabIndex = 7;
            selectionWidth.Value = new decimal(new int[] { 64, 0, 0, 0 });
            // 
            // selectionHeight
            // 
            selectionHeight.Location = new Point(15, 144);
            selectionHeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            selectionHeight.Minimum = new decimal(new int[] { 32, 0, 0, 0 });
            selectionHeight.Name = "selectionHeight";
            selectionHeight.Size = new Size(107, 31);
            selectionHeight.TabIndex = 7;
            selectionHeight.Value = new decimal(new int[] { 128, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 28);
            label2.Name = "label2";
            label2.Size = new Size(121, 25);
            label2.TabIndex = 8;
            label2.Text = "Output Name";
            // 
            // txtOutputName
            // 
            txtOutputName.Location = new Point(13, 56);
            txtOutputName.Name = "txtOutputName";
            txtOutputName.Size = new Size(218, 31);
            txtOutputName.TabIndex = 9;
            txtOutputName.Text = "Image";
            // 
            // llGenerate
            // 
            llGenerate.AutoSize = true;
            llGenerate.Location = new Point(243, 170);
            llGenerate.Name = "llGenerate";
            llGenerate.Size = new Size(82, 25);
            llGenerate.TabIndex = 16;
            llGenerate.TabStop = true;
            llGenerate.Text = "Generate";
            llGenerate.LinkClicked += llGenerate_LinkClicked;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(padH);
            groupBox1.Controls.Add(padV);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(numRows);
            groupBox1.Controls.Add(numCols);
            groupBox1.Controls.Add(llGenerate);
            groupBox1.Location = new Point(7, 184);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(340, 215);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generate Panels";
            // 
            // padH
            // 
            padH.Location = new Point(171, 136);
            padH.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            padH.Name = "padH";
            padH.Size = new Size(87, 31);
            padH.TabIndex = 24;
            padH.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // padV
            // 
            padV.Location = new Point(6, 136);
            padV.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            padV.Name = "padV";
            padV.Size = new Size(87, 31);
            padV.TabIndex = 23;
            padV.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(164, 108);
            label6.Name = "label6";
            label6.Size = new Size(73, 25);
            label6.TabIndex = 22;
            label6.Text = "Pad hor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 108);
            label5.Name = "label5";
            label5.Size = new Size(76, 25);
            label5.TabIndex = 21;
            label5.Text = "Pad vert";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(164, 34);
            label4.Name = "label4";
            label4.Size = new Size(46, 25);
            label4.TabIndex = 20;
            label4.Text = "Cols";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 32);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 19;
            label3.Text = "Rows";
            // 
            // numRows
            // 
            numRows.Location = new Point(171, 62);
            numRows.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRows.Name = "numRows";
            numRows.Size = new Size(87, 31);
            numRows.TabIndex = 18;
            numRows.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // numCols
            // 
            numCols.Location = new Point(6, 61);
            numCols.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCols.Name = "numCols";
            numCols.Size = new Size(87, 31);
            numCols.TabIndex = 17;
            numCols.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(panelNumStart);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtOutputName);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(6, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(341, 172);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Panel Export Options";
            // 
            // panelNumStart
            // 
            panelNumStart.Location = new Point(14, 124);
            panelNumStart.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            panelNumStart.Name = "panelNumStart";
            panelNumStart.Size = new Size(217, 31);
            panelNumStart.TabIndex = 11;
            panelNumStart.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 90);
            label7.Name = "label7";
            label7.Size = new Size(140, 25);
            label7.TabIndex = 10;
            label7.Text = "Starting number";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(selectionWidth);
            groupBox3.Controls.Add(selectionHeight);
            groupBox3.Location = new Point(7, 405);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(341, 198);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            groupBox3.Text = "Panel Settings";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 116);
            label9.Name = "label9";
            label9.Size = new Size(146, 25);
            label9.TabIndex = 7;
            label9.Text = "Minimum Height";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 36);
            label8.Name = "label8";
            label8.Size = new Size(141, 25);
            label8.TabIndex = 6;
            label8.Text = "Minimum Width";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 36);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(362, 1055);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(treeView1);
            tabPage1.Controls.Add(propertyGrid1);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(354, 1017);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Panels";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(4, 190);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(344, 793);
            treeView1.TabIndex = 3;
            treeView1.MouseDown += treeView1_MouseDown;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox3);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(354, 1017);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Settings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, toolsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1681, 33);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Image = (Image)resources.GetObject("newToolStripMenuItem.Image");
            newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newToolStripMenuItem.Size = new Size(223, 34);
            newToolStripMenuItem.Text = "&New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = (Image)resources.GetObject("openToolStripMenuItem.Image");
            openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(223, 34);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(220, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = (Image)resources.GetObject("saveToolStripMenuItem.Image");
            saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveToolStripMenuItem.Size = new Size(223, 34);
            saveToolStripMenuItem.Text = "&Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(223, 34);
            saveAsToolStripMenuItem.Text = "Save &As";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(220, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(223, 34);
            exitToolStripMenuItem.Text = "E&xit";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripSeparator3, removeAllPanelsToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(58, 29);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(253, 6);
            // 
            // removeAllPanelsToolStripMenuItem
            // 
            removeAllPanelsToolStripMenuItem.Name = "removeAllPanelsToolStripMenuItem";
            removeAllPanelsToolStripMenuItem.Size = new Size(256, 34);
            removeAllPanelsToolStripMenuItem.Text = "Remove all panels";
            removeAllPanelsToolStripMenuItem.Click += removeAllPanelsToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportImagesToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(69, 29);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // exportImagesToolStripMenuItem
            // 
            exportImagesToolStripMenuItem.Name = "exportImagesToolStripMenuItem";
            exportImagesToolStripMenuItem.Size = new Size(228, 34);
            exportImagesToolStripMenuItem.Text = "Export Images";
            exportImagesToolStripMenuItem.Click += exportImagesToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1681, 1103);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)selectionWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)selectionHeight).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)padH).EndInit();
            ((System.ComponentModel.ISupportInitialize)padV).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRows).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCols).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)panelNumStart).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private PropertyGrid propertyGrid1;
        private Panel panel1;
        private NumericUpDown selectionWidth;
        private NumericUpDown selectionHeight;
        private Label label2;
        private TextBox txtOutputName;
        private LinkLabel llGenerate;
        private GroupBox groupBox1;
        private NumericUpDown padH;
        private NumericUpDown padV;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private NumericUpDown numRows;
        private NumericUpDown numCols;
        private GroupBox groupBox2;
        private NumericUpDown panelNumStart;
        private Label label7;
        private GroupBox groupBox3;
        private Label label9;
        private Label label8;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TreeView treeView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem removeAllPanelsToolStripMenuItem;
        private ToolStripMenuItem exportImagesToolStripMenuItem;
    }
}
