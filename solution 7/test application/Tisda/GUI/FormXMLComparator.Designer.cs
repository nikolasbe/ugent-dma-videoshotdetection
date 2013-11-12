namespace Tisda
{
    partial class XMLComparatorForm
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
            this.groupBoxTruthXML = new System.Windows.Forms.GroupBox();
            this.buttonLoadTruthXML = new System.Windows.Forms.Button();
            this.labelTruthXMLPath = new System.Windows.Forms.Label();
            this.labelPathTruthXMLLabel = new System.Windows.Forms.Label();
            this.groupBoxVideoXML = new System.Windows.Forms.GroupBox();
            this.buttonLoadFileXML = new System.Windows.Forms.Button();
            this.labelVideoXMLPath = new System.Windows.Forms.Label();
            this.labelVideoXMLPathLabel = new System.Windows.Forms.Label();
            this.groupBoxRecallValue = new System.Windows.Forms.GroupBox();
            this.labelRecallValue = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelPrecisionValue = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxTruthXML.SuspendLayout();
            this.groupBoxVideoXML.SuspendLayout();
            this.groupBoxRecallValue.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTruthXML
            // 
            this.groupBoxTruthXML.Controls.Add(this.buttonLoadTruthXML);
            this.groupBoxTruthXML.Controls.Add(this.labelTruthXMLPath);
            this.groupBoxTruthXML.Controls.Add(this.labelPathTruthXMLLabel);
            this.groupBoxTruthXML.Location = new System.Drawing.Point(13, 13);
            this.groupBoxTruthXML.Name = "groupBoxTruthXML";
            this.groupBoxTruthXML.Size = new System.Drawing.Size(534, 46);
            this.groupBoxTruthXML.TabIndex = 0;
            this.groupBoxTruthXML.TabStop = false;
            this.groupBoxTruthXML.Text = "Truth XML";
            // 
            // buttonLoadTruthXML
            // 
            this.buttonLoadTruthXML.Location = new System.Drawing.Point(453, 15);
            this.buttonLoadTruthXML.Name = "buttonLoadTruthXML";
            this.buttonLoadTruthXML.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadTruthXML.TabIndex = 2;
            this.buttonLoadTruthXML.Text = "Load...";
            this.buttonLoadTruthXML.UseVisualStyleBackColor = true;
            this.buttonLoadTruthXML.Click += new System.EventHandler(this.buttonLoadTruthXML_Click);
            // 
            // labelTruthXMLPath
            // 
            this.labelTruthXMLPath.AutoSize = true;
            this.labelTruthXMLPath.Location = new System.Drawing.Point(46, 20);
            this.labelTruthXMLPath.Name = "labelTruthXMLPath";
            this.labelTruthXMLPath.Size = new System.Drawing.Size(122, 13);
            this.labelTruthXMLPath.TabIndex = 1;
            this.labelTruthXMLPath.Text = "No truth XML loaded yet";
            // 
            // labelPathTruthXMLLabel
            // 
            this.labelPathTruthXMLLabel.AutoSize = true;
            this.labelPathTruthXMLLabel.Location = new System.Drawing.Point(7, 20);
            this.labelPathTruthXMLLabel.Name = "labelPathTruthXMLLabel";
            this.labelPathTruthXMLLabel.Size = new System.Drawing.Size(32, 13);
            this.labelPathTruthXMLLabel.TabIndex = 0;
            this.labelPathTruthXMLLabel.Text = "Path:";
            // 
            // groupBoxVideoXML
            // 
            this.groupBoxVideoXML.Controls.Add(this.buttonLoadFileXML);
            this.groupBoxVideoXML.Controls.Add(this.labelVideoXMLPath);
            this.groupBoxVideoXML.Controls.Add(this.labelVideoXMLPathLabel);
            this.groupBoxVideoXML.Location = new System.Drawing.Point(13, 65);
            this.groupBoxVideoXML.Name = "groupBoxVideoXML";
            this.groupBoxVideoXML.Size = new System.Drawing.Size(534, 46);
            this.groupBoxVideoXML.TabIndex = 3;
            this.groupBoxVideoXML.TabStop = false;
            this.groupBoxVideoXML.Text = "Video XML";
            // 
            // buttonLoadFileXML
            // 
            this.buttonLoadFileXML.Location = new System.Drawing.Point(453, 15);
            this.buttonLoadFileXML.Name = "buttonLoadFileXML";
            this.buttonLoadFileXML.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadFileXML.TabIndex = 2;
            this.buttonLoadFileXML.Text = "Load...";
            this.buttonLoadFileXML.UseVisualStyleBackColor = true;
            this.buttonLoadFileXML.Click += new System.EventHandler(this.buttonLoadFileXML_Click);
            // 
            // labelVideoXMLPath
            // 
            this.labelVideoXMLPath.AutoSize = true;
            this.labelVideoXMLPath.Location = new System.Drawing.Point(46, 20);
            this.labelVideoXMLPath.Name = "labelVideoXMLPath";
            this.labelVideoXMLPath.Size = new System.Drawing.Size(114, 13);
            this.labelVideoXMLPath.TabIndex = 1;
            this.labelVideoXMLPath.Text = "No file XML loaded yet";
            // 
            // labelVideoXMLPathLabel
            // 
            this.labelVideoXMLPathLabel.AutoSize = true;
            this.labelVideoXMLPathLabel.Location = new System.Drawing.Point(7, 20);
            this.labelVideoXMLPathLabel.Name = "labelVideoXMLPathLabel";
            this.labelVideoXMLPathLabel.Size = new System.Drawing.Size(32, 13);
            this.labelVideoXMLPathLabel.TabIndex = 0;
            this.labelVideoXMLPathLabel.Text = "Path:";
            // 
            // groupBoxRecallValue
            // 
            this.groupBoxRecallValue.Controls.Add(this.labelRecallValue);
            this.groupBoxRecallValue.Location = new System.Drawing.Point(12, 117);
            this.groupBoxRecallValue.Name = "groupBoxRecallValue";
            this.groupBoxRecallValue.Size = new System.Drawing.Size(260, 45);
            this.groupBoxRecallValue.TabIndex = 4;
            this.groupBoxRecallValue.TabStop = false;
            this.groupBoxRecallValue.Text = "Recall value";
            // 
            // labelRecallValue
            // 
            this.labelRecallValue.AutoSize = true;
            this.labelRecallValue.Location = new System.Drawing.Point(11, 20);
            this.labelRecallValue.Name = "labelRecallValue";
            this.labelRecallValue.Size = new System.Drawing.Size(53, 13);
            this.labelRecallValue.TabIndex = 0;
            this.labelRecallValue.Text = "Unknown";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelPrecisionValue);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(287, 117);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 45);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Precision value";
            // 
            // labelPrecisionValue
            // 
            this.labelPrecisionValue.AutoSize = true;
            this.labelPrecisionValue.Location = new System.Drawing.Point(6, 20);
            this.labelPrecisionValue.Name = "labelPrecisionValue";
            this.labelPrecisionValue.Size = new System.Drawing.Size(53, 13);
            this.labelPrecisionValue.TabIndex = 1;
            this.labelPrecisionValue.Text = "Unknown";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(259, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(275, 45);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Enabled = false;
            this.buttonCalculate.Location = new System.Drawing.Point(466, 168);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculate.TabIndex = 7;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(385, 168);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // XMLComparatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 198);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxRecallValue);
            this.Controls.Add(this.groupBoxVideoXML);
            this.Controls.Add(this.groupBoxTruthXML);
            this.Name = "XMLComparatorForm";
            this.Text = "XMLComparatorForm";
            this.groupBoxTruthXML.ResumeLayout(false);
            this.groupBoxTruthXML.PerformLayout();
            this.groupBoxVideoXML.ResumeLayout(false);
            this.groupBoxVideoXML.PerformLayout();
            this.groupBoxRecallValue.ResumeLayout(false);
            this.groupBoxRecallValue.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTruthXML;
        private System.Windows.Forms.Button buttonLoadTruthXML;
        private System.Windows.Forms.Label labelTruthXMLPath;
        private System.Windows.Forms.Label labelPathTruthXMLLabel;
        private System.Windows.Forms.GroupBox groupBoxVideoXML;
        private System.Windows.Forms.Button buttonLoadFileXML;
        private System.Windows.Forms.Label labelVideoXMLPath;
        private System.Windows.Forms.Label labelVideoXMLPathLabel;
        private System.Windows.Forms.GroupBox groupBoxRecallValue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelRecallValue;
        private System.Windows.Forms.Label labelPrecisionValue;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Button buttonCancel;
    }
}