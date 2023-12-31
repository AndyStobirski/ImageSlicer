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
            pictureBox1 = new PictureBox();
            propertyGrid1 = new PropertyGrid();
            panel1 = new Panel();
            selectionWidth = new NumericUpDown();
            selectionHeight = new NumericUpDown();
            label2 = new Label();
            txtOutputName = new TextBox();
            llClearSelection = new LinkLabel();
            llLoadImage = new LinkLabel();
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
            groupBox2 = new GroupBox();
            label7 = new Label();
            panelNumStart = new NumericUpDown();
            groupBox3 = new GroupBox();
            label8 = new Label();
            label9 = new Label();
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
            propertyGrid1.Location = new Point(23, 675);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(341, 346);
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
            groupBox1.Location = new Point(24, 250);
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
            // groupBox2
            // 
            groupBox2.Controls.Add(panelNumStart);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(txtOutputName);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(23, 72);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(341, 172);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Panel Export Options";
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
            // panelNumStart
            // 
            panelNumStart.Location = new Point(14, 124);
            panelNumStart.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            panelNumStart.Name = "panelNumStart";
            panelNumStart.Size = new Size(217, 31);
            panelNumStart.TabIndex = 11;
            panelNumStart.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(selectionWidth);
            groupBox3.Controls.Add(selectionHeight);
            groupBox3.Location = new Point(23, 471);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(341, 198);
            groupBox3.TabIndex = 20;
            groupBox3.TabStop = false;
            groupBox3.Text = "Panel Settings";
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
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 116);
            label9.Name = "label9";
            label9.Size = new Size(146, 25);
            label9.TabIndex = 7;
            label9.Text = "Minimum Height";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1681, 1108);
            Controls.Add(groupBox3);
            Controls.Add(propertyGrid1);
            Controls.Add(groupBox2);
            Controls.Add(llDeleteSelectedPanel);
            Controls.Add(groupBox1);
            Controls.Add(llExportSelected);
            Controls.Add(llClear);
            Controls.Add(llLoadImage);
            Controls.Add(llClearSelection);
            Controls.Add(panel1);
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
        private LinkLabel llClearSelection;
        private LinkLabel llLoadImage;
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
        private GroupBox groupBox2;
        private NumericUpDown panelNumStart;
        private Label label7;
        private GroupBox groupBox3;
        private Label label9;
        private Label label8;
    }
}
