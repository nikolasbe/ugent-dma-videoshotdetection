namespace Tisda
{
    partial class Method1Panel
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
            this.labelDelta2 = new System.Windows.Forms.Label();
            this.labelDelta3 = new System.Windows.Forms.Label();
            this.numericUpDownDelta3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDelta2 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelta3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelta2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDelta2
            // 
            this.labelDelta2.AutoSize = true;
            this.labelDelta2.Location = new System.Drawing.Point(1, 5);
            this.labelDelta2.Name = "labelDelta2";
            this.labelDelta2.Size = new System.Drawing.Size(19, 13);
            this.labelDelta2.TabIndex = 0;
            this.labelDelta2.Text = "δ2";
            // 
            // labelDelta3
            // 
            this.labelDelta3.AutoSize = true;
            this.labelDelta3.Location = new System.Drawing.Point(1, 40);
            this.labelDelta3.Name = "labelDelta3";
            this.labelDelta3.Size = new System.Drawing.Size(19, 13);
            this.labelDelta3.TabIndex = 2;
            this.labelDelta3.Text = "δ3";
            // 
            // numericUpDownDelta3
            // 
            this.numericUpDownDelta3.DecimalPlaces = 3;
            this.numericUpDownDelta3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownDelta3.Location = new System.Drawing.Point(100, 35);
            this.numericUpDownDelta3.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDelta3.Name = "numericUpDownDelta3";
            this.numericUpDownDelta3.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownDelta3.TabIndex = 3;
            // 
            // numericUpDownDelta2
            // 
            this.numericUpDownDelta2.Location = new System.Drawing.Point(100, 5);
            this.numericUpDownDelta2.Maximum = new decimal(new int[] {
            768,
            0,
            0,
            0});
            this.numericUpDownDelta2.Name = "numericUpDownDelta2";
            this.numericUpDownDelta2.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownDelta2.TabIndex = 4;
            // 
            // Method1Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownDelta2);
            this.Controls.Add(this.numericUpDownDelta3);
            this.Controls.Add(this.labelDelta3);
            this.Controls.Add(this.labelDelta2);
            this.Name = "Method1Panel";
            this.Size = new System.Drawing.Size(200, 100);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelta3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDelta2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDelta2;
        private System.Windows.Forms.Label labelDelta3;
        private System.Windows.Forms.NumericUpDown numericUpDownDelta3;
        private System.Windows.Forms.NumericUpDown numericUpDownDelta2;
    }
}
