using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace Tisda
{
    public partial class XMLComparatorForm : Form
    {
        private XmlDocument xml_truth;
        private XmlDocument xml_video;
        private XMLComparator xml_comparator;
        private OpenFileDialog openFileDialog;
        //If both these booleans are true, the calculate button will be enabled
        private Boolean xml_truth_loaded;
        private Boolean xml_video_loaded;

        public XMLComparatorForm()
        {
            InitializeComponent();
            //Initialize member variables
            xml_truth = new XmlDocument();
            xml_video = new XmlDocument();
            xml_comparator = new XMLComparator();
            xml_truth_loaded = false;
            xml_video_loaded = false;
        }

        //Load button for the truth XML was clicked
        private void buttonLoadTruthXML_Click(object sender, EventArgs e)
        {
            //Initialize the open file dialog and continue if the user selected a file
            initOpenFileDialog();
            if (openFileDialog.ShowDialog(this) == DialogResult.OK && openFileDialog.FileName != "")
            {
                try
                {
                    xml_truth.Load(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something is wrong with this file. Are you sure it is an XML file?", "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                xml_truth_loaded = true;
                //Loading the XML into the XmlDocument succeeded, update the GUI
                labelTruthXMLPath.Text = openFileDialog.SafeFileName;
                if (xml_truth_loaded && xml_video_loaded)
                {
                    buttonCalculate.Enabled = true;
                }
            }
        }

        //Load button for the own XML was clicked
        private void buttonLoadFileXML_Click(object sender, EventArgs e)
        {
            //Initialize the open file dialog and continue if the user selected a file
            initOpenFileDialog();
            if (openFileDialog.ShowDialog(this) == DialogResult.OK && openFileDialog.FileName != "")
            {
                try
                {
                    xml_video.Load(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something is wrong with this file. Are you sure it is a valid XML file?", "Open Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                xml_video_loaded = true;
                //Loading the XML into the XmlDocument succeeded, update the GUI
                labelVideoXMLPath.Text = openFileDialog.SafeFileName;
                if (xml_truth_loaded && xml_video_loaded)
                {
                    buttonCalculate.Enabled = true;
                }
            }
        }

        //Calculation button for  was clicked
        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                //If neither of the files is null, try to execute calculation
                if (xml_truth != null && xml_video != null)
                {
                    double[] results = xml_comparator.performanceMeasures(xml_truth, xml_video);
                    labelRecallValue.Text = results[0].ToString();
                    labelPrecisionValue.Text = results[1].ToString();
                }
                //One of the xml file is null - we shouldn't ever get here because of the GUI
                else
                {
                    MessageBox.Show("The XML file(s) is/are not loaded", "Calc Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Calc failed, probably because of invalid XML file(s)
            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong with the XML file(s). Are you sure you selected the right XML files?", "Calc Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Initialize a new openFileDialog
        private void initOpenFileDialog()
        {
            //Dispose of the old one
            if (openFileDialog != null)
            {
                openFileDialog.Dispose();
            }
            //Create dialog, set title and make sure only XML-files can be opened
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML file|*.xml";
            openFileDialog.Title = "Export shot information as XML file";
        }

        //Cancel button was clicked, close form
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
