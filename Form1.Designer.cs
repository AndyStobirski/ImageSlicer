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
            components = new System.ComponentModel.Container();
            pictureBox1 = new PictureBox();
            propertyGrid1 = new PropertyGrid();
            panel1 = new Panel();
            label1 = new Label();
            selectionWidth = new NumericUpDown();
            selectionHeight = new NumericUpDown();
            label2 = new Label();
            txtOutputName = new TextBox();
            llClearSelection = new LinkLabel();
            llLoadImage = new LinkLabel();
            imageList1 = new ImageList(components);
            llClear = new LinkLabel();
            llExportSelected = new LinkLabel();
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
            llDeleteSelectedPanel = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)selectionWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)selectionHeight).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)padH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)padV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCols).BeginInit();
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
            pictureBox1.MouseDoubleClick += Form1_MouseDoubleClick;
            pictureBox1.MouseDown += Form1_MouseDown;
            pictureBox1.MouseMove += Form1_MouseMove;
            pictureBox1.MouseUp += Form1_MouseUp;
            // 
            // propertyGrid1
            // 
            propertyGrid1.Location = new Point(14, 287);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(341, 406);
            propertyGrid1.TabIndex = 2;
            propertyGrid1.PropertyValueChanged += propertyGrid1_PropertyValueChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(377, 69);
            panel1.Name = "panel1";
            panel1.Size = new Size(1292, 1026);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 75);
            label1.Name = "label1";
            label1.Size = new Size(119, 25);
            label1.TabIndex = 5;
            label1.Text = "Selection Size";
            // 
            // selectionWidth
            // 
            selectionWidth.Location = new Point(139, 75);
            selectionWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            selectionWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            selectionWidth.Name = "selectionWidth";
            selectionWidth.Size = new Size(103, 31);
            selectionWidth.TabIndex = 7;
            selectionWidth.Value = new decimal(new int[] { 64, 0, 0, 0 });
            // 
            // selectionHeight
            // 
            selectionHeight.Location = new Point(248, 75);
            selectionHeight.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            selectionHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            selectionHeight.Name = "selectionHeight";
            selectionHeight.Size = new Size(107, 31);
            selectionHeight.TabIndex = 7;
            selectionHeight.Value = new decimal(new int[] { 128, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 135);
            label2.Name = "label2";
            label2.Size = new Size(116, 25);
            label2.TabIndex = 8;
            label2.Text = "OutputName";
            // 
            // txtOutputName
            // 
            txtOutputName.Location = new Point(137, 132);
            txtOutputName.Name = "txtOutputName";
            txtOutputName.Size = new Size(218, 31);
            txtOutputName.TabIndex = 9;
            txtOutputName.Text = "Image";
            // 
            // llClearSelection
            // 
            llClearSelection.AutoSize = true;
            llClearSelection.Location = new Point(195, 9);
            llClearSelection.Name = "llClearSelection";
            llClearSelection.Size = new Size(130, 25);
            llClearSelection.TabIndex = 10;
            llClearSelection.TabStop = true;
            llClearSelection.Text = "Remove Panels";
            llClearSelection.LinkClicked += llClearSelection_LinkClicked;
            // 
            // llLoadImage
            // 
            llLoadImage.AutoSize = true;
            llLoadImage.Location = new Point(83, 9);
            llLoadImage.Name = "llLoadImage";
            llLoadImage.Size = new Size(106, 25);
            llLoadImage.TabIndex = 11;
            llLoadImage.TabStop = true;
            llLoadImage.Text = "Load Image";
            llLoadImage.LinkClicked += llLoadImage_LinkClicked;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // llClear
            // 
            llClear.AutoSize = true;
            llClear.Location = new Point(14, 9);
            llClear.Name = "llClear";
            llClear.Size = new Size(54, 25);
            llClear.TabIndex = 12;
            llClear.TabStop = true;
            llClear.Text = "Reset";
            llClear.LinkClicked += llClear_LinkClicked;
            // 
            // llExportSelected
            // 
            llExportSelected.AutoSize = true;
            llExportSelected.Location = new Point(331, 9);
            llExportSelected.Name = "llExportSelected";
            llExportSelected.Size = new Size(117, 25);
            llExportSelected.TabIndex = 13;
            llExportSelected.TabStop = true;
            llExportSelected.Text = "Export Panels";
            llExportSelected.LinkClicked += llExportSelected_LinkClicked;
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
            groupBox1.Location = new Point(24, 774);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(331, 215);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Generate Panels";
            // 
            // padH
            // 
            padH.Location = new Point(171, 136);
            padH.Name = "padH";
            padH.Size = new Size(87, 31);
            padH.TabIndex = 24;
            padH.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // padV
            // 
            padV.Location = new Point(6, 136);
            padV.Name = "padV";
            padV.Size = new Size(87, 31);
            padV.TabIndex = 23;
            padV.Value = new decimal(new int[] { 5, 0, 0, 0 });
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
            numRows.Name = "numRows";
            numRows.Size = new Size(87, 31);
            numRows.TabIndex = 18;
            numRows.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // numCols
            // 
            numCols.Location = new Point(6, 61);
            numCols.Name = "numCols";
            numCols.Size = new Size(87, 31);
            numCols.TabIndex = 17;
            numCols.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // llDeleteSelectedPanel
            // 
            llDeleteSelectedPanel.AutoSize = true;
            llDeleteSelectedPanel.Location = new Point(454, 9);
            llDeleteSelectedPanel.Name = "llDeleteSelectedPanel";
            llDeleteSelectedPanel.Size = new Size(179, 25);
            llDeleteSelectedPanel.TabIndex = 18;
            llDeleteSelectedPanel.TabStop = true;
            llDeleteSelectedPanel.Text = "Delete Selected Panel";
            llDeleteSelectedPanel.LinkClicked += llDeleteSelectedPanel_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1681, 1108);
            Controls.Add(llDeleteSelectedPanel);
            Controls.Add(groupBox1);
            Controls.Add(llExportSelected);
            Controls.Add(llClear);
            Controls.Add(llLoadImage);
            Controls.Add(llClearSelection);
            Controls.Add(txtOutputName);
            Controls.Add(label2);
            Controls.Add(selectionHeight);
            Controls.Add(selectionWidth);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(propertyGrid1);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private PropertyGrid propertyGrid1;
        private Panel panel1;
        private Label label1;
        private NumericUpDown selectionWidth;
        private NumericUpDown selectionHeight;
        private Label label2;
        private TextBox txtOutputName;
        private LinkLabel llClearSelection;
        private LinkLabel llLoadImage;
        private ImageList imageList1;
        private LinkLabel llClear;
        private LinkLabel llExportSelected;
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
        private LinkLabel llDeleteSelectedPanel;
    }
}
