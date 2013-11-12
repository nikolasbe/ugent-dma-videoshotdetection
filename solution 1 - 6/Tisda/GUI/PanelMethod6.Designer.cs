namespace Tisda
{
    partial class Method6Panel
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
            this.labelTreshold = new System.Windows.Forms.Label();
            this.labelVar = new System.Windows.Forms.Label();
            this.labelBins = new System.Windows.Forms.Label();
            this.labelRegionSize = new System.Windows.Forms.Label();
            this.labelBuffer = new System.Windows.Forms.Label();
            this.numericUpDownTreshold = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownVar = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBins = new System.Windows.Forms.NumericUpDown();
            this.comboBoxRegionSize = new System.Windows.Forms.ComboBox();
            this.numericUpDownBuffer = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBuffer)).BeginInit();
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
            // labelVar
            // 
            this.labelVar.AutoSize = true;
            this.labelVar.Location = new System.Drawing.Point(1, 40);
            this.labelVar.Name = "labelVar";
            this.labelVar.Size = new System.Drawing.Size(23, 13);
            this.labelVar.TabIndex = 1;
            this.labelVar.Text = "Var";
            // 
            // labelBins
            // 
            this.labelBins.AutoSize = true;
            this.labelBins.Location = new System.Drawing.Point(1, 70);
            this.labelBins.Name = "labelBins";
            this.labelBins.Size = new System.Drawing.Size(27, 13);
            this.labelBins.TabIndex = 2;
            this.labelBins.Text = "Bins";
            // 
            // labelRegionSize
            // 
            this.labelRegionSize.AutoSize = true;
            this.labelRegionSize.Location = new System.Drawing.Point(1, 100);
            this.labelRegionSize.Name = "labelRegionSize";
            this.labelRegionSize.Size = new System.Drawing.Size(62, 13);
            this.labelRegionSize.TabIndex = 3;
            this.labelRegionSize.Text = "Region size";
            // 
            // labelBuffer
            // 
            this.labelBuffer.AutoSize = true;
            this.labelBuffer.Location = new System.Drawing.Point(1, 130);
            this.labelBuffer.Name = "labelBuffer";
            this.labelBuffer.Size = new System.Drawing.Size(35, 13);
            this.labelBuffer.TabIndex = 4;
            this.labelBuffer.Text = "Buffer";
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
            // 
            // numericUpDownVar
            // 
            this.numericUpDownVar.DecimalPlaces = 3;
            this.numericUpDownVar.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownVar.Location = new System.Drawing.Point(100, 35);
            this.numericUpDownVar.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownVar.Name = "numericUpDownVar";
            this.numericUpDownVar.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownVar.TabIndex = 6;
            this.toolTip1.SetToolTip(this.numericUpDownVar, "0 to 1 (double)");
            // 
            // numericUpDownBins
            // 
            this.numericUpDownBins.Location = new System.Drawing.Point(100, 65);
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
            this.numericUpDownBins.TabIndex = 7;
            this.toolTip1.SetToolTip(this.numericUpDownBins, "1 to 255 (integer)");
            this.numericUpDownBins.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBins.ValueChanged += new System.EventHandler(this.numericUpDownBins_ValueChanged);
            // 
            // comboBoxRegionSize
            // 
            this.comboBoxRegionSize.FormattingEnabled = true;
            this.comboBoxRegionSize.Location = new System.Drawing.Point(100, 95);
            this.comboBoxRegionSize.Name = "comboBoxRegionSize";
            this.comboBoxRegionSize.Size = new System.Drawing.Size(90, 21);
            this.comboBoxRegionSize.TabIndex = 8;
            // 
            // numericUpDownBuffer
            // 
            this.numericUpDownBuffer.Location = new System.Drawing.Point(100, 125);
            this.numericUpDownBuffer.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownBuffer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBuffer.Name = "numericUpDownBuffer";
            this.numericUpDownBuffer.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownBuffer.TabIndex = 9;
            this.toolTip1.SetToolTip(this.numericUpDownBuffer, ">0 (integer) [also equals to minimum detectable shot length]");
            this.numericUpDownBuffer.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownBuffer.ValueChanged += new System.EventHandler(this.numericUpDownBuffer_ValueChanged);
            // 
            // Method6Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownBuffer);
            this.Controls.Add(this.comboBoxRegionSize);
            this.Controls.Add(this.numericUpDownBins);
            this.Controls.Add(this.numericUpDownVar);
            this.Controls.Add(this.numericUpDownTreshold);
            this.Controls.Add(this.labelBuffer);
            this.Controls.Add(this.labelRegionSize);
            this.Controls.Add(this.labelBins);
            this.Controls.Add(this.labelVar);
            this.Controls.Add(this.labelTreshold);
            this.Name = "Method6Panel";
            this.Size = new System.Drawing.Size(200, 150);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBuffer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTreshold;
        private System.Windows.Forms.Label labelVar;
        private System.Windows.Forms.Label labelBins;
        private System.Windows.Forms.Label labelRegionSize;
        private System.Windows.Forms.Label labelBuffer;
        private System.Windows.Forms.NumericUpDown numericUpDownTreshold;
        private System.Windows.Forms.NumericUpDown numericUpDownVar;
        private System.Windows.Forms.NumericUpDown numericUpDownBins;
        private System.Windows.Forms.ComboBox comboBoxRegionSize;
        private System.Windows.Forms.NumericUpDown numericUpDownBuffer;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
