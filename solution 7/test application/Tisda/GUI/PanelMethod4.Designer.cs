namespace Tisda
{
    partial class Method4Panel
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
            this.labelTreshold = new System.Windows.Forms.Label();
            this.numericUpDownTreshold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBins = new System.Windows.Forms.NumericUpDown();
            this.labelBins = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBins)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTreshold
            // 
            this.labelTreshold.AutoSize = true;
            this.labelTreshold.Location = new System.Drawing.Point(1, 5);
            this.labelTreshold.Name = "labelTreshold";
            this.labelTreshold.Size = new System.Drawing.Size(48, 13);
            this.labelTreshold.TabIndex = 0;
            this.labelTreshold.Text = "Treshold";
            // 
            // numericUpDownTreshold
            // 
            this.numericUpDownTreshold.Location = new System.Drawing.Point(100, 5);
            this.numericUpDownTreshold.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownTreshold.Name = "numericUpDownTreshold";
            this.numericUpDownTreshold.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownTreshold.TabIndex = 1;
            // 
            // numericUpDownBins
            // 
            this.numericUpDownBins.Location = new System.Drawing.Point(100, 35);
            this.numericUpDownBins.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownBins.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBins.Name = "numericUpDownBins";
            this.numericUpDownBins.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownBins.TabIndex = 2;
            this.numericUpDownBins.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelBins
            // 
            this.labelBins.AutoSize = true;
            this.labelBins.Location = new System.Drawing.Point(1, 35);
            this.labelBins.Name = "labelBins";
            this.labelBins.Size = new System.Drawing.Size(27, 13);
            this.labelBins.TabIndex = 3;
            this.labelBins.Text = "Bins";
            // 
            // Method4Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelBins);
            this.Controls.Add(this.numericUpDownBins);
            this.Controls.Add(this.numericUpDownTreshold);
            this.Controls.Add(this.labelTreshold);
            this.Name = "Method4Panel";
            this.Size = new System.Drawing.Size(200, 100);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTreshold;
        private System.Windows.Forms.NumericUpDown numericUpDownTreshold;
        private System.Windows.Forms.NumericUpDown numericUpDownBins;
        private System.Windows.Forms.Label labelBins;
    }
}
