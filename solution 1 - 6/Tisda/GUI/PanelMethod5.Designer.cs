namespace Tisda
{
    partial class Method5Panel
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
            this.components = new System.ComponentModel.Container();
            this.labelTresHold = new System.Windows.Forms.Label();
            this.labelBins = new System.Windows.Forms.Label();
            this.labelRegionSize = new System.Windows.Forms.Label();
            this.comboBoxRegionSize = new System.Windows.Forms.ComboBox();
            this.numericUpDownBins = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTreshold = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTresHold
            // 
            this.labelTresHold.AutoSize = true;
            this.labelTresHold.Location = new System.Drawing.Point(1, 5);
            this.labelTresHold.Name = "labelTresHold";
            this.labelTresHold.Size = new System.Drawing.Size(48, 13);
            this.labelTresHold.TabIndex = 0;
            this.labelTresHold.Text = "Treshold";
            // 
            // labelBins
            // 
            this.labelBins.AutoSize = true;
            this.labelBins.Location = new System.Drawing.Point(1, 40);
            this.labelBins.Name = "labelBins";
            this.labelBins.Size = new System.Drawing.Size(27, 13);
            this.labelBins.TabIndex = 1;
            this.labelBins.Text = "Bins";
            // 
            // labelRegionSize
            // 
            this.labelRegionSize.AutoSize = true;
            this.labelRegionSize.Location = new System.Drawing.Point(1, 70);
            this.labelRegionSize.Name = "labelRegionSize";
            this.labelRegionSize.Size = new System.Drawing.Size(62, 13);
            this.labelRegionSize.TabIndex = 2;
            this.labelRegionSize.Text = "Region size";
            // 
            // comboBoxRegionSize
            // 
            this.comboBoxRegionSize.FormattingEnabled = true;
            this.comboBoxRegionSize.Location = new System.Drawing.Point(100, 65);
            this.comboBoxRegionSize.Name = "comboBoxRegionSize";
            this.comboBoxRegionSize.Size = new System.Drawing.Size(90, 21);
            this.comboBoxRegionSize.TabIndex = 3;
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
            this.numericUpDownBins.TabIndex = 4;
            this.toolTip1.SetToolTip(this.numericUpDownBins, "1 to 255 (integer)");
            this.numericUpDownBins.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.numericUpDownTreshold.TabIndex = 5;
            this.toolTip1.SetToolTip(this.numericUpDownTreshold, "0 to 1 (double)");
            this.numericUpDownTreshold.ValueChanged += new System.EventHandler(this.numericUpDownTreshold_ValueChanged);
            // 
            // Method5Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownTreshold);
            this.Controls.Add(this.numericUpDownBins);
            this.Controls.Add(this.comboBoxRegionSize);
            this.Controls.Add(this.labelRegionSize);
            this.Controls.Add(this.labelBins);
            this.Controls.Add(this.labelTresHold);
            this.Name = "Method5Panel";
            this.Size = new System.Drawing.Size(200, 100);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTresHold;
        private System.Windows.Forms.Label labelBins;
        private System.Windows.Forms.Label labelRegionSize;
        private System.Windows.Forms.ComboBox comboBoxRegionSize;
        private System.Windows.Forms.NumericUpDown numericUpDownBins;
        private System.Windows.Forms.NumericUpDown numericUpDownTreshold;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
