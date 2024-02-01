namespace ImageSlicer
{
    partial class AutoGeneratePanels
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            padH = new NumericUpDown();
            padV = new NumericUpDown();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            numRows = new NumericUpDown();
            numCols = new NumericUpDown();
            btnCancel = new Button();
            btnGenerate = new Button();
            ((System.ComponentModel.ISupportInitialize)padH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)padV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCols).BeginInit();
            SuspendLayout();
            // 
            // padH
            // 
            padH.Location = new Point(177, 111);
            padH.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            padH.Name = "padH";
            padH.Size = new Size(87, 31);
            padH.TabIndex = 24;
            padH.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // padV
            // 
            padV.Location = new Point(12, 111);
            padV.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            padV.Name = "padV";
            padV.Size = new Size(87, 31);
            padV.TabIndex = 23;
            padV.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(170, 83);
            label6.Name = "label6";
            label6.Size = new Size(73, 25);
            label6.TabIndex = 22;
            label6.Text = "Pad hor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 83);
            label5.Name = "label5";
            label5.Size = new Size(76, 25);
            label5.TabIndex = 21;
            label5.Text = "Pad vert";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(170, 9);
            label4.Name = "label4";
            label4.Size = new Size(46, 25);
            label4.TabIndex = 20;
            label4.Text = "Cols";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 7);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 19;
            label3.Text = "Rows";
            // 
            // numRows
            // 
            numRows.Location = new Point(177, 37);
            numRows.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numRows.Name = "numRows";
            numRows.Size = new Size(87, 31);
            numRows.TabIndex = 18;
            numRows.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // numCols
            // 
            numCols.Location = new Point(12, 36);
            numCols.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCols.Name = "numCols";
            numCols.Size = new Size(87, 31);
            numCols.TabIndex = 17;
            numCols.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(162, 184);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(297, 184);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(112, 34);
            btnGenerate.TabIndex = 19;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // AutoGeneratePanels
            // 
            AcceptButton = btnGenerate;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(427, 237);
            Controls.Add(padH);
            Controls.Add(btnCancel);
            Controls.Add(padV);
            Controls.Add(btnGenerate);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(numCols);
            Controls.Add(label4);
            Controls.Add(numRows);
            Controls.Add(label3);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AutoGeneratePanels";
            StartPosition = FormStartPosition.CenterParent;
            Text = "AutoGeneratePanels";
            ((System.ComponentModel.ISupportInitialize)padH).EndInit();
            ((System.ComponentModel.ISupportInitialize)padV).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRows).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCols).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown padH;
        private NumericUpDown padV;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private NumericUpDown numRows;
        private NumericUpDown numCols;
        private Button btnCancel;
        private Button btnGenerate;
    }
}