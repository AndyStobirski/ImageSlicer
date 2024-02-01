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
            toolStripSeparator1 = new ToolStripSeparator();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            DetectEdges = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            generatePanelsToolStripMenuItem = new ToolStripMenuItem();
            exportImagesToolStripMenuItem = new ToolStripMenuItem();
            removeAllPanelsToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            importImageToolStripMenuItem = new ToolStripMenuItem();
            drawToolStripMenuItem = new ToolStripMenuItem();
            polygonToolStripMenuItem = new ToolStripMenuItem();
            rectangleToolStripMenuItem = new ToolStripMenuItem();
            circleToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)selectionWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)selectionHeight).BeginInit();
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
            panel1.Location = new Point(376, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(1292, 1021);
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
            // groupBox3
            // 
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(selectionWidth);
            groupBox3.Controls.Add(selectionHeight);
            groupBox3.Location = new Point(0, 6);
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, drawToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1681, 33);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, toolStripSeparator, saveToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem, toolStripSeparator1 });
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
            saveToolStripMenuItem.Enabled = false;
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
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(220, 6);
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DetectEdges, toolStripSeparator4, generatePanelsToolStripMenuItem, exportImagesToolStripMenuItem, removeAllPanelsToolStripMenuItem1, toolStripSeparator3, importImageToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(69, 29);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // DetectEdges
            // 
            DetectEdges.Name = "DetectEdges";
            DetectEdges.Size = new Size(270, 34);
            DetectEdges.Text = "Detect Edges";
            DetectEdges.Click += DetectEdges_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(267, 6);
            // 
            // generatePanelsToolStripMenuItem
            // 
            generatePanelsToolStripMenuItem.Name = "generatePanelsToolStripMenuItem";
            generatePanelsToolStripMenuItem.Size = new Size(270, 34);
            generatePanelsToolStripMenuItem.Text = "Generate Panels";
            generatePanelsToolStripMenuItem.Click += generatePanelsToolStripMenuItem_Click;
            // 
            // exportImagesToolStripMenuItem
            // 
            exportImagesToolStripMenuItem.Name = "exportImagesToolStripMenuItem";
            exportImagesToolStripMenuItem.Size = new Size(270, 34);
            exportImagesToolStripMenuItem.Text = "Export Panels";
            exportImagesToolStripMenuItem.Click += exportImagesToolStripMenuItem_Click;
            // 
            // removeAllPanelsToolStripMenuItem1
            // 
            removeAllPanelsToolStripMenuItem1.Name = "removeAllPanelsToolStripMenuItem1";
            removeAllPanelsToolStripMenuItem1.Size = new Size(270, 34);
            removeAllPanelsToolStripMenuItem1.Text = "Remove all Panels";
            removeAllPanelsToolStripMenuItem1.Click += removeAllPanelsToolStripMenuItem1_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(267, 6);
            // 
            // importImageToolStripMenuItem
            // 
            importImageToolStripMenuItem.Name = "importImageToolStripMenuItem";
            importImageToolStripMenuItem.Size = new Size(270, 34);
            importImageToolStripMenuItem.Text = "Import Image";
            importImageToolStripMenuItem.Click += importImageToolStripMenuItem_Click;
            // 
            // drawToolStripMenuItem
            // 
            drawToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { polygonToolStripMenuItem, rectangleToolStripMenuItem, circleToolStripMenuItem });
            drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            drawToolStripMenuItem.Size = new Size(85, 29);
            drawToolStripMenuItem.Text = "Shapes";
            // 
            // polygonToolStripMenuItem
            // 
            polygonToolStripMenuItem.CheckOnClick = true;
            polygonToolStripMenuItem.Name = "polygonToolStripMenuItem";
            polygonToolStripMenuItem.Size = new Size(190, 34);
            polygonToolStripMenuItem.Text = "Polygon";
            polygonToolStripMenuItem.Click += polygonToolStripMenuItem_Click;
            // 
            // rectangleToolStripMenuItem
            // 
            rectangleToolStripMenuItem.Checked = true;
            rectangleToolStripMenuItem.CheckOnClick = true;
            rectangleToolStripMenuItem.CheckState = CheckState.Checked;
            rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            rectangleToolStripMenuItem.Size = new Size(190, 34);
            rectangleToolStripMenuItem.Text = "Rectangle";
            rectangleToolStripMenuItem.Click += rectangleToolStripMenuItem_Click;
            // 
            // circleToolStripMenuItem
            // 
            circleToolStripMenuItem.CheckOnClick = true;
            circleToolStripMenuItem.Enabled = false;
            circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            circleToolStripMenuItem.Size = new Size(190, 34);
            circleToolStripMenuItem.Text = "Circle";
            circleToolStripMenuItem.Click += circleToolStripMenuItem_Click;
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
            Text = "Image Slicer";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)selectionWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)selectionHeight).EndInit();
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
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem exportImagesToolStripMenuItem;
        private ToolStripMenuItem drawToolStripMenuItem;
        private ToolStripMenuItem polygonToolStripMenuItem;
        private ToolStripMenuItem rectangleToolStripMenuItem;
        private ToolStripMenuItem circleToolStripMenuItem;
        private ToolStripMenuItem removeAllPanelsToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem importImageToolStripMenuItem;
        private ToolStripMenuItem generatePanelsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem DetectEdges;
    }
}
