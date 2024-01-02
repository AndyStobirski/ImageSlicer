namespace ImageSlicer
{
    partial class frmExportOptions
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
            btnExport = new Button();
            btnCancel = new Button();
            panelNumStart = new NumericUpDown();
            label7 = new Label();
            txtOutputName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtPath = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)panelNumStart).BeginInit();
            SuspendLayout();
            // 
            // btnExport
            // 
            btnExport.Location = new Point(508, 274);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(112, 34);
            btnExport.TabIndex = 0;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(373, 274);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // panelNumStart
            // 
            panelNumStart.Location = new Point(160, 75);
            panelNumStart.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            panelNumStart.Name = "panelNumStart";
            panelNumStart.Size = new Size(217, 31);
            panelNumStart.TabIndex = 11;
            panelNumStart.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 75);
            label7.Name = "label7";
            label7.Size = new Size(140, 25);
            label7.TabIndex = 10;
            label7.Text = "Starting number";
            // 
            // txtOutputName
            // 
            txtOutputName.Location = new Point(159, 32);
            txtOutputName.Name = "txtOutputName";
            txtOutputName.Size = new Size(218, 31);
            txtOutputName.TabIndex = 9;
            txtOutputName.Text = "Image";
            txtOutputName.TextChanged += txtOutputName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 32);
            label2.Name = "label2";
            label2.Size = new Size(121, 25);
            label2.TabIndex = 8;
            label2.Text = "Output Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 127);
            label1.Name = "label1";
            label1.Size = new Size(102, 25);
            label1.TabIndex = 12;
            label1.Text = "Export Path";
            // 
            // txtPath
            // 
            txtPath.Location = new Point(160, 127);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(410, 31);
            txtPath.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(577, 125);
            button1.Name = "button1";
            button1.Size = new Size(43, 34);
            button1.TabIndex = 14;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmExportOptions
            // 
            AcceptButton = btnExport;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(633, 323);
            Controls.Add(button1);
            Controls.Add(txtPath);
            Controls.Add(label1);
            Controls.Add(panelNumStart);
            Controls.Add(label7);
            Controls.Add(btnCancel);
            Controls.Add(txtOutputName);
            Controls.Add(btnExport);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmExportOptions";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ExportOptions";
            Shown += frmExportOptions_Shown;
            ((System.ComponentModel.ISupportInitialize)panelNumStart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnExport;
        private Button btnCancel;
        private NumericUpDown panelNumStart;
        private Label label7;
        private TextBox txtOutputName;
        private Label label2;
        private Label label1;
        private TextBox txtPath;
        private Button button1;
    }
}