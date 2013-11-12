using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tisda
{
    public partial class KeywordsForm : Form
    {
        //The keywords that will be edited in this form in one string
        private String keywords;

        //Constructor
        public KeywordsForm(List<String> initialkeywords)
        {
            InitializeComponent();
            //Create a string where the keywords are put together with ';'
            foreach (String keyword in initialkeywords)
            {
                this.textBoxKeywords.Text += keyword + ";";
            }
            //Remove last ';'
            this.textBoxKeywords.Text.Remove(this.textBoxKeywords.Text.Length - 1);
        }

        //Getter for the list of keywords in the form
        public String Keywords {
            get
            {
                return keywords;
            }
        }

        //Save button was clicked
        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Extract keywords from from
            keywords = textBoxKeywords.Text;
            this.DialogResult = DialogResult.OK;
        }

        //Cancel button was clicked, close dialog
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
