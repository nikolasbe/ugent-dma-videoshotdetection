namespace Tisda
{
    partial class Method3Panel
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
            this.comboBoxBlockSize = new System.Windows.Forms.ComboBox();
            this.labelStep = new System.Windows.Forms.Label();
            this.labelBlockSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownTreshold = new System.Windows.Forms.NumericUpDown();
            this.comboBoxStep = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxBlockSize
            // 
            this.comboBoxBlockSize.FormattingEnabled = true;
            this.comboBoxBlockSize.Location = new System.Drawing.Point(100, 35);
            this.comboBoxBlockSize.Name = "comboBoxBlockSize";
            this.comboBoxBlockSize.Size = new System.Drawing.Size(90, 21);
            this.comboBoxBlockSize.TabIndex = 12;
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(1, 70);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(29, 13);
            this.labelStep.TabIndex = 11;
            this.labelStep.Text = "Step";
            // 
            // labelBlockSize
            // 
            this.labelBlockSize.AutoSize = true;
            this.labelBlockSize.Location = new System.Drawing.Point(1, 40);
            this.labelBlockSize.Name = "labelBlockSize";
            this.labelBlockSize.Size = new System.Drawing.Size(55, 13);
            this.labelBlockSize.TabIndex = 10;
            this.labelBlockSize.Text = "Block size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Treshold";
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
            this.numericUpDownTreshold.TabIndex = 7;
            this.toolTip1.SetToolTip(this.numericUpDownTreshold, "0 to 1 (double)");
            // 
            // comboBoxStep
            // 
            this.comboBoxStep.FormattingEnabled = true;
            this.comboBoxStep.Location = new System.Drawing.Point(100, 65);
            this.comboBoxStep.Name = "comboBoxStep";
            this.comboBoxStep.Size = new System.Drawing.Size(90, 21);
            this.comboBoxStep.TabIndex = 13;
            // 
            // Method3Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxStep);
            this.Controls.Add(this.comboBoxBlockSize);
            this.Controls.Add(this.labelStep);
            this.Controls.Add(this.labelBlockSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownTreshold);
            this.Name = "Method3Panel";
            this.Size = new System.Drawing.Size(200, 100);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxBlockSize;
        private System.Windows.Forms.Label labelStep;
        private System.Windows.Forms.Label labelBlockSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownTreshold;
        private System.Windows.Forms.ComboBox comboBoxStep;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}
