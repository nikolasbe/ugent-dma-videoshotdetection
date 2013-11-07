using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.VisualBasic;

namespace Tisda
{
    public partial class FormTisda : Form
    {
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private GroupBox groupBoxVideoControls;
        private ToolTip toolTipTisda;
        private OpenFileDialog openFileDialog;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem exitApplicationToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel;
        private StatusStrip statusStrip;
        private GroupBox groupBoxShots;
        private GroupBox groupBoxCanvas;
        private Button btnPlayShot;
        private Button btnExportShotInfo;
        private GroupBox groupBoxShotDetection;
        private Button btnExportFrames;
        private Button btnEditShotInfo;
        private Button btnSearch;
        private TextBox textBoxKeyword;
        private Button btnDetectShots;
        private Label lblShotDetectionMethod;
        private ComboBox comboBoxDetectionMethod;
        private IContainer components;
        private ShotDetector shotdetector;
        private System.DirectoryServices.DirectorySearcher directorySearcher;
        private FolderBrowserDialog folderBrowserDialog;
        private ListBox listBoxShots;
        private SaveFileDialog saveFileDialog;
        private Panel panelParameters;
        private  XMLCreator xml_creator;
        private GroupBox groupBoxExport;
        private Button btnStop;
        private ToolStripMenuItem xMLToolStripMenuItem;
        private ToolStripMenuItem calculateRecallAndPrecisionToolStripMenuItem;
        private int selected_index;
        private VideoManager video_manager;
        private Stopwatch sw;
        public FormTisda()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //Initialize managers
            video_manager = new VideoManager();
            shotdetector = new ShotDetector();
            xml_creator = new XMLCreator();

            //Assign datasources
            listBoxShots.DataSource = video_manager.FilteredShotList;
            comboBoxDetectionMethod.DataSource = shotdetector.DetectionMethods;

            //Initialize stopwatch
            sw = new Stopwatch();

            //Initialize
            selected_index = 0;
            comboBoxDetectionMethod.SelectedIndex = selected_index;
            panelParameters.Controls.Add((UserControl)shotdetector.Panels[selected_index]);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.groupBoxVideoControls = new System.Windows.Forms.GroupBox();
            this.toolTipTisda = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateRecallAndPrecisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.groupBoxShots = new System.Windows.Forms.GroupBox();
            this.listBoxShots = new System.Windows.Forms.ListBox();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.groupBoxCanvas = new System.Windows.Forms.GroupBox();
            this.groupBoxShotDetection = new System.Windows.Forms.GroupBox();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.lblShotDetectionMethod = new System.Windows.Forms.Label();
            this.comboBoxDetectionMethod = new System.Windows.Forms.ComboBox();
            this.directorySearcher = new System.DirectoryServices.DirectorySearcher();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBoxExport = new System.Windows.Forms.GroupBox();
            this.btnExportFrames = new System.Windows.Forms.Button();
            this.btnExportShotInfo = new System.Windows.Forms.Button();
            this.btnDetectShots = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnEditShotInfo = new System.Windows.Forms.Button();
            this.btnPlayShot = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.groupBoxVideoControls.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxShots.SuspendLayout();
            this.groupBoxCanvas.SuspendLayout();
            this.groupBoxShotDetection.SuspendLayout();
            this.groupBoxExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCanvas
            // 
            this.panelCanvas.BackColor = System.Drawing.SystemColors.Desktop;
            this.panelCanvas.Location = new System.Drawing.Point(115, 24);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(315, 184);
            this.panelCanvas.TabIndex = 10;
            // 
            // groupBoxVideoControls
            // 
            this.groupBoxVideoControls.Controls.Add(this.btnStop);
            this.groupBoxVideoControls.Controls.Add(this.btnPause);
            this.groupBoxVideoControls.Controls.Add(this.btnPlay);
            this.groupBoxVideoControls.Location = new System.Drawing.Point(12, 254);
            this.groupBoxVideoControls.Name = "groupBoxVideoControls";
            this.groupBoxVideoControls.Size = new System.Drawing.Size(273, 62);
            this.groupBoxVideoControls.TabIndex = 14;
            this.groupBoxVideoControls.TabStop = false;
            this.groupBoxVideoControls.Text = "Video controls";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.xMLToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(569, 24);
            this.menuStrip.TabIndex = 16;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitApplicationToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.openToolStripMenuItem.Text = "Open..";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitApplicationToolStripMenuItem
            // 
            this.exitApplicationToolStripMenuItem.Name = "exitApplicationToolStripMenuItem";
            this.exitApplicationToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.exitApplicationToolStripMenuItem.Text = "Quit";
            this.exitApplicationToolStripMenuItem.Click += new System.EventHandler(this.exitApplicationToolStripMenuItem_Click);
            // 
            // xMLToolStripMenuItem
            // 
            this.xMLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateRecallAndPrecisionToolStripMenuItem});
            this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
            this.xMLToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.xMLToolStripMenuItem.Text = "Performance";
            // 
            // calculateRecallAndPrecisionToolStripMenuItem
            // 
            this.calculateRecallAndPrecisionToolStripMenuItem.Name = "calculateRecallAndPrecisionToolStripMenuItem";
            this.calculateRecallAndPrecisionToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.calculateRecallAndPrecisionToolStripMenuItem.Text = "Recall and precision values";
            this.calculateRecallAndPrecisionToolStripMenuItem.Click += new System.EventHandler(this.calculateRecallAndPrecisionToolStripMenuItem_Click);
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(113, 17);
            this.toolStripStatusLabel.Text = "No video loaded yet";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(569, 22);
            this.statusStrip.TabIndex = 19;
            this.statusStrip.Text = "statusStrip1";
            // 
            // groupBoxShots
            // 
            this.groupBoxShots.Controls.Add(this.listBoxShots);
            this.groupBoxShots.Controls.Add(this.btnSearch);
            this.groupBoxShots.Controls.Add(this.textBoxKeyword);
            this.groupBoxShots.Controls.Add(this.btnEditShotInfo);
            this.groupBoxShots.Controls.Add(this.btnPlayShot);
            this.groupBoxShots.Location = new System.Drawing.Point(291, 322);
            this.groupBoxShots.Name = "groupBoxShots";
            this.groupBoxShots.Size = new System.Drawing.Size(272, 211);
            this.groupBoxShots.TabIndex = 21;
            this.groupBoxShots.TabStop = false;
            this.groupBoxShots.Text = "Shots";
            // 
            // listBoxShots
            // 
            this.listBoxShots.FormattingEnabled = true;
            this.listBoxShots.Location = new System.Drawing.Point(6, 53);
            this.listBoxShots.Name = "listBoxShots";
            this.listBoxShots.Size = new System.Drawing.Size(207, 147);
            this.listBoxShots.TabIndex = 29;
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(6, 22);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(207, 20);
            this.textBoxKeyword.TabIndex = 27;
            // 
            // groupBoxCanvas
            // 
            this.groupBoxCanvas.Controls.Add(this.panelCanvas);
            this.groupBoxCanvas.Location = new System.Drawing.Point(12, 33);
            this.groupBoxCanvas.Name = "groupBoxCanvas";
            this.groupBoxCanvas.Size = new System.Drawing.Size(551, 215);
            this.groupBoxCanvas.TabIndex = 22;
            this.groupBoxCanvas.TabStop = false;
            // 
            // groupBoxShotDetection
            // 
            this.groupBoxShotDetection.Controls.Add(this.panelParameters);
            this.groupBoxShotDetection.Controls.Add(this.lblShotDetectionMethod);
            this.groupBoxShotDetection.Controls.Add(this.btnDetectShots);
            this.groupBoxShotDetection.Controls.Add(this.comboBoxDetectionMethod);
            this.groupBoxShotDetection.Location = new System.Drawing.Point(12, 322);
            this.groupBoxShotDetection.Name = "groupBoxShotDetection";
            this.groupBoxShotDetection.Size = new System.Drawing.Size(273, 211);
            this.groupBoxShotDetection.TabIndex = 23;
            this.groupBoxShotDetection.TabStop = false;
            this.groupBoxShotDetection.Text = "Shot Detection";
            // 
            // panelParameters
            // 
            this.panelParameters.Location = new System.Drawing.Point(9, 53);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(250, 150);
            this.panelParameters.TabIndex = 2;
            // 
            // lblShotDetectionMethod
            // 
            this.lblShotDetectionMethod.AutoSize = true;
            this.lblShotDetectionMethod.Location = new System.Drawing.Point(6, 25);
            this.lblShotDetectionMethod.Name = "lblShotDetectionMethod";
            this.lblShotDetectionMethod.Size = new System.Drawing.Size(92, 13);
            this.lblShotDetectionMethod.TabIndex = 1;
            this.lblShotDetectionMethod.Text = "Detection Method";
            // 
            // comboBoxDetectionMethod
            // 
            this.comboBoxDetectionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDetectionMethod.FormattingEnabled = true;
            this.comboBoxDetectionMethod.Location = new System.Drawing.Point(104, 21);
            this.comboBoxDetectionMethod.Name = "comboBoxDetectionMethod";
            this.comboBoxDetectionMethod.Size = new System.Drawing.Size(112, 21);
            this.comboBoxDetectionMethod.TabIndex = 0;
            this.comboBoxDetectionMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxDetectionMethod_SelectedIndexChanged);
            // 
            // directorySearcher
            // 
            this.directorySearcher.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // groupBoxExport
            // 
            this.groupBoxExport.Controls.Add(this.btnExportFrames);
            this.groupBoxExport.Controls.Add(this.btnExportShotInfo);
            this.groupBoxExport.Location = new System.Drawing.Point(291, 255);
            this.groupBoxExport.Name = "groupBoxExport";
            this.groupBoxExport.Size = new System.Drawing.Size(272, 61);
            this.groupBoxExport.TabIndex = 24;
            this.groupBoxExport.TabStop = false;
            this.groupBoxExport.Text = "Export controls";
            // 
            // btnExportFrames
            // 
            this.btnExportFrames.Enabled = false;
            this.btnExportFrames.Image = global::Tisda.Properties.Resources.ExportFrames;
            this.btnExportFrames.Location = new System.Drawing.Point(50, 15);
            this.btnExportFrames.Name = "btnExportFrames";
            this.btnExportFrames.Size = new System.Drawing.Size(40, 40);
            this.btnExportFrames.TabIndex = 25;
            this.toolTipTisda.SetToolTip(this.btnExportFrames, "Export frames");
            this.btnExportFrames.UseVisualStyleBackColor = true;
            this.btnExportFrames.Click += new System.EventHandler(this.btnExportFrames_Click);
            // 
            // btnExportShotInfo
            // 
            this.btnExportShotInfo.Enabled = false;
            this.btnExportShotInfo.Image = global::Tisda.Properties.Resources.ExportShotInfo;
            this.btnExportShotInfo.Location = new System.Drawing.Point(5, 15);
            this.btnExportShotInfo.Name = "btnExportShotInfo";
            this.btnExportShotInfo.Size = new System.Drawing.Size(40, 40);
            this.btnExportShotInfo.TabIndex = 24;
            this.toolTipTisda.SetToolTip(this.btnExportShotInfo, "Export shot info");
            this.btnExportShotInfo.UseVisualStyleBackColor = true;
            this.btnExportShotInfo.Click += new System.EventHandler(this.btnExportShotInfo_Click);
            // 
            // btnDetectShots
            // 
            this.btnDetectShots.Enabled = false;
            this.btnDetectShots.Image = global::Tisda.Properties.Resources.DetectShots;
            this.btnDetectShots.Location = new System.Drawing.Point(222, 19);
            this.btnDetectShots.Name = "btnDetectShots";
            this.btnDetectShots.Size = new System.Drawing.Size(40, 25);
            this.btnDetectShots.TabIndex = 0;
            this.btnDetectShots.UseVisualStyleBackColor = true;
            this.btnDetectShots.Click += new System.EventHandler(this.buttonDetectShots_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.Image = global::Tisda.Properties.Resources.Search;
            this.btnSearch.Location = new System.Drawing.Point(219, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 25);
            this.btnSearch.TabIndex = 28;
            this.toolTipTisda.SetToolTip(this.btnSearch, "Retrieve shots with keyword");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnEditShotInfo
            // 
            this.btnEditShotInfo.Enabled = false;
            this.btnEditShotInfo.Image = global::Tisda.Properties.Resources.Edit;
            this.btnEditShotInfo.Location = new System.Drawing.Point(219, 99);
            this.btnEditShotInfo.Name = "btnEditShotInfo";
            this.btnEditShotInfo.Size = new System.Drawing.Size(40, 40);
            this.btnEditShotInfo.TabIndex = 26;
            this.toolTipTisda.SetToolTip(this.btnEditShotInfo, "Edit shot info");
            this.btnEditShotInfo.UseVisualStyleBackColor = true;
            this.btnEditShotInfo.Click += new System.EventHandler(this.btnEditShotInfo_Click);
            // 
            // btnPlayShot
            // 
            this.btnPlayShot.Enabled = false;
            this.btnPlayShot.Image = global::Tisda.Properties.Resources.Play;
            this.btnPlayShot.Location = new System.Drawing.Point(219, 53);
            this.btnPlayShot.Name = "btnPlayShot";
            this.btnPlayShot.Size = new System.Drawing.Size(40, 40);
            this.btnPlayShot.TabIndex = 23;
            this.toolTipTisda.SetToolTip(this.btnPlayShot, "Play shot");
            this.btnPlayShot.UseVisualStyleBackColor = true;
            this.btnPlayShot.Click += new System.EventHandler(this.btnPlayShot_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Image = global::Tisda.Properties.Resources.Stop;
            this.btnStop.Location = new System.Drawing.Point(95, 15);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(40, 40);
            this.btnStop.TabIndex = 12;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Image = global::Tisda.Properties.Resources.Pause;
            this.btnPause.Location = new System.Drawing.Point(50, 15);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(40, 40);
            this.btnPause.TabIndex = 11;
            this.toolTipTisda.SetToolTip(this.btnPause, "Pause video");
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Image = global::Tisda.Properties.Resources.Play;
            this.btnPlay.Location = new System.Drawing.Point(5, 15);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(40, 40);
            this.btnPlay.TabIndex = 1;
            this.toolTipTisda.SetToolTip(this.btnPlay, "Play video");
            this.btnPlay.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FormTisda
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(569, 561);
            this.Controls.Add(this.groupBoxExport);
            this.Controls.Add(this.groupBoxShotDetection);
            this.Controls.Add(this.groupBoxCanvas);
            this.Controls.Add(this.groupBoxShots);
            this.Controls.Add(this.groupBoxVideoControls);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormTisda";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Tisda! The Intense Shot Detection Application";
            this.groupBoxVideoControls.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxShots.ResumeLayout(false);
            this.groupBoxShots.PerformLayout();
            this.groupBoxCanvas.ResumeLayout(false);
            this.groupBoxShotDetection.ResumeLayout(false);
            this.groupBoxShotDetection.PerformLayout();
            this.groupBoxExport.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        //Start button was clicked
        private void btnStart_Click(object sender, System.EventArgs e)
        {
            //Indicate that we'll be playing a file
            toolStripStatusLabel.Text = "Playing";
            //Play the file
            video_manager.play(panelCanvas);
            //Enable/disable appropriate buttons
            btnPlay.Enabled = false;
            btnStop.Enabled = true;
            btnPause.Enabled = true;
        }

        //Pause button was clicked
        private void btnPause_Click(object sender, System.EventArgs e)
        {
            //Pause the video (allows video to be started again from this point) and indicate this in the status bar
            video_manager.pause();
            toolStripStatusLabel.Text = "Paused";
            //Enable/disable appropriate buttons
            btnPlay.Enabled = true;
            btnPause.Enabled = false;
        }

        //Stop button was clicked
        private void btnStop_Click(object sender, EventArgs e)
        {
            //Indicate that the file was stopped and stop the file - this resets it to the beginning
            toolStripStatusLabel.Text = "Stopped";
            video_manager.stop();
            //Enable/disable appropriate buttons
            btnPlay.Enabled = true;
            btnStop.Enabled = false;
            btnPause.Enabled = false;
        }

        //Load menu-option was clicked
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Only continue if user clicked 'Open'
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                //Try to load the selected file
                String fileName = openFileDialog.FileName;
                listBoxShots.DataSource = null;
                if (video_manager.load(fileName, panelCanvas))
                    {
                        //File was loaded, indicate this and enable/disable appropriate buttons
                        toolStripStatusLabel.Text = "File loaded. Click play to start the video.";
                        groupBoxCanvas.Text = openFileDialog.SafeFileName;
                        btnPlay.Enabled = true;
                        btnDetectShots.Enabled = true;
                        updateShotList();
                    }
                //Loading of the file failed - indicate this to user
                else
                {
                    MessageBox.Show("Failed to open file", "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel.Text = "Can't load file!";
                }
            }
            
        }

        //Exit menu-option was clicked
        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        //Export shot info button was clicked
        private void btnExportShotInfo_Click(object sender, EventArgs e)
        {
            int shot_index = listBoxShots.SelectedIndex;
            if (shot_index >= 0)
            {
                //Savedialog is only allowed to save as XML
                saveFileDialog.Filter = "XML file|*.xml";
                saveFileDialog.Title = "Export shot information as XML file";

                // If the user opted to save and the filename is not an empty string
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK && saveFileDialog.FileName != "")
                {
                    //Create the XML-document and save it
                    XmlDocument xml_doc = xml_creator.createShotsXML(shotdetector.DetectionMethod, shotdetector.DetectionArgs, video_manager.ShotList, saveFileDialog.FileName);
                    String filename = saveFileDialog.FileName;
                    try
                    {
                        xml_doc.Save(saveFileDialog.FileName);
                    }
                    //Saving the XML document failed, indicate this to user
                    catch (XmlException ex)
                    {
                        MessageBox.Show("Failed to save file: " + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Export frames button was clicked
        private void btnExportFrames_Click(object sender, EventArgs e)
        {
            //Only continue if there's a shotlist
            if (video_manager.FilteredShotList.Count > 0)
            {
                int i = 0;
                //If user picked a location, save each shot as 'Shot<x>.png' in the appropriate folder
                if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK && folderBrowserDialog.SelectedPath != "")
                {
                    foreach (Shot shot in video_manager.ShotList)
                    {
                        String filename = folderBrowserDialog.SelectedPath + "\\Shot" + i + ".Png";
                        shot.Frame.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                        i++;
                    }
                }
            }
            //No shotlist, indicate this to user - this shouldn't happen because GUI shouldn't allow it
            else
            {
                MessageBox.Show("There is no shotlist", "Shotlist Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Search button was clicked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Filter the shotlist and update it afterwards
            video_manager.filter(textBoxKeyword.Text);
            updateShotList();
        }

        //Edit shot button was clicked
        private void btnEditShotInfo_Click(object sender, EventArgs e)
        {
            int shot_index = listBoxShots.SelectedIndex;
            //Only continue if the selected index is 0 or greater
            if (shot_index >= 0)
            {
                //Display a new Keywordsform so the user can edit the keywords
                KeywordsForm form = new KeywordsForm(video_manager.FilteredShotList.ElementAt(shot_index).KeyWords);
                //Apply changes if user opted to save his changes
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    String keywords = form.Keywords;
                    String[] keywords_array = keywords.Split(';');

                    video_manager.editShotInfo(keywords_array, shot_index);
                    //Dispose of the form
                    form.Dispose();
                }
            }
            //SelectedIndex is below zero - this shouldn't happend because the GUI shouldn't allow it
            else
            {
                MessageBox.Show("No shot selected", "Shot Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            updateShotList();
        }
  
        //Play shot button was clicked
        private void btnPlayShot_Click(object sender, EventArgs e)
        {
            //Extract the shot from the shotlist and play it
            Shot shot = video_manager.FilteredShotList[listBoxShots.SelectedIndex];
            video_manager.play(shot.Start, shot.End);
        }

        //A different detection method was chosen
        private void comboBoxDetectionMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Remove old panel
            panelParameters.Controls.Remove((UserControl)shotdetector.Panels[selected_index]);
            //Get appropriate panel from the shotdetector and set it
            selected_index = comboBoxDetectionMethod.SelectedIndex;
            panelParameters.Controls.Add((UserControl)shotdetector.Panels[selected_index]);
        }

        //Detect shots button was clicked
        private void buttonDetectShots_Click(object sender, EventArgs e)
        {
            //Only continue if a video was loaded
            if (video_manager.FileName != "")
            {
                //Let the GUI indicate to the user that this is an timeconsuming process
                toolStripStatusLabel.Text = "Detecting shots. This might take a while.";
                Cursor.Current = Cursors.WaitCursor;
                //Execute detection
                sw.Reset();
                sw.Start();
                video_manager.ShotList = shotdetector.detectShots(comboBoxDetectionMethod.SelectedIndex, video_manager.FileName);
                sw.Stop();
                //We're done, update cursos and enable/disable appropriate buttons
                Cursor.Current = Cursors.Default;
                video_manager.filter("");
                updateShotList();
                btnPlayShot.Enabled = true;
                btnEditShotInfo.Enabled = true;
                btnExportFrames.Enabled = true;
                btnExportShotInfo.Enabled = true;
                btnSearch.Enabled = true;
                //Update statusstrip
                toolStripStatusLabel.Text = "Shots detected! Time elapsed: " + sw.ElapsedMilliseconds + "ms";
            }
            //No video was loaded - we shouldn't ever get here because the GUI shouldn't allow it
            else
            {
                MessageBox.Show("No video loaded to detect shots", "Video Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Re-initialize the shotlist
        private void updateShotList()
        {
            //Reinitialize the shotlist by removing and re-adding the datasource, pretty dirty but setting up the whole DataSource process is overkill for this application
            listBoxShots.DataSource = null;
            listBoxShots.DataSource = video_manager.FilteredShotList;
        }

        //Calculate recall and precision menu-option was clicked
        private void calculateRecallAndPrecisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Create a new form for recall and precision calculation
            XMLComparatorForm xml_cf = new XMLComparatorForm();
            //Display the form in the center of the application
            xml_cf.StartPosition = FormStartPosition.CenterParent;
            xml_cf.ShowDialog(this);
        }
    }
}