namespace Tisda
{
    partial class Method2Panel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownTreshold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWindowSize = new System.Windows.Forms.NumericUpDown();
            this.labelTreshold = new System.Windows.Forms.Label();
            this.labelBlockSize = new System.Windows.Forms.Label();
            this.labelWindowSize = new System.Windows.Forms.Label();
            this.comboBoxBlockSize = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowSize)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownTreshold
            // 
            this.numericUpDownTreshold.DecimalPlaces = 3;
            this.numericUpDownTreshold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownTreshold.Location = new System.Drawing.Point(100, 5);
            this.numericUpDownTreshold.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownTreshold.Name = "numericUpDownTreshold";
            this.numericUpDownTreshold.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownTreshold.TabIndex = 0;
            // 
            // numericUpDownWindowSize
            // 
            this.numericUpDownWindowSize.Location = new System.Drawing.Point(100, 65);
            this.numericUpDownWindowSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownWindowSize.Name = "numericUpDownWindowSize";
            this.numericUpDownWindowSize.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownWindowSize.TabIndex = 2;
            // 
            // labelTreshold
            // 
            this.labelTreshold.AutoSize = true;
            this.labelTreshold.Location = new System.Drawing.Point(1, 5);
            this.labelTreshold.Name = "labelTreshold";
            this.labelTreshold.Size = new System.Drawing.Size(48, 13);
            this.labelTreshold.TabIndex = 3;
            this.labelTreshold.Text = "Treshold";
            // 
            // labelBlockSize
            // 
            this.labelBlockSize.AutoSize = true;
            this.labelBlockSize.Location = new System.Drawing.Point(1, 40);
            this.labelBlockSize.Name = "labelBlockSize";
            this.labelBlockSize.Size = new System.Drawing.Size(55, 13);
            this.labelBlockSize.TabIndex = 4;
            this.labelBlockSize.Text = "Block size";
            // 
            // labelWindowSize
            // 
            this.labelWindowSize.AutoSize = true;
            this.labelWindowSize.Location = new System.Drawing.Point(1, 70);
            this.labelWindowSize.Name = "labelWindowSize";
            this.labelWindowSize.Size = new System.Drawing.Size(67, 13);
            this.labelWindowSize.TabIndex = 5;
            this.labelWindowSize.Text = "Window size";
            // 
            // comboBoxBlockSize
            // 
            this.comboBoxBlockSize.FormattingEnabled = true;
            this.comboBoxBlockSize.Location = new System.Drawing.Point(100, 35);
            this.comboBoxBlockSize.Name = "comboBoxBlockSize";
            this.comboBoxBlockSize.Size = new System.Drawing.Size(90, 21);
            this.comboBoxBlockSize.TabIndex = 6;
            // 
            // Method2Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxBlockSize);
            this.Controls.Add(this.labelWindowSize);
            this.Controls.Add(this.labelBlockSize);
            this.Controls.Add(this.labelTreshold);
            this.Controls.Add(this.numericUpDownWindowSize);
            this.Controls.Add(this.numericUpDownTreshold);
            this.Name = "Method2Panel";
            this.Size = new System.Drawing.Size(200, 100);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWindowSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownTreshold;
        private System.Windows.Forms.NumericUpDown numericUpDownWindowSize;
        private System.Windows.Forms.Label labelTreshold;
        private System.Windows.Forms.Label labelBlockSize;
        private System.Windows.Forms.Label labelWindowSize;
        private System.Windows.Forms.ComboBox comboBoxBlockSize;
    }
}
