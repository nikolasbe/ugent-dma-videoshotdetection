using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tisda
{
    public partial class Method5Panel : UserControl, ParameterPanel
    {
        private String[] region_sizes = { "2x2", "4x4", "8x8", "16x16" };
        private int[] region_values = { 4, 16, 64, 256 };

        public Method5Panel()
        {
            InitializeComponent();
            comboBoxRegionSize.DataSource = region_sizes;
        }

        private double getTreshold() {
            return (double)numericUpDownTreshold.Value;
        }

        private int getBins() {
            return (int)numericUpDownBins.Value;
        }

        private int getRegionSize(){
            return region_values[comboBoxRegionSize.SelectedIndex];
        }

        public object[] getParams(){
            object[] pars = {getTreshold(), getBins(), getRegionSize() };
            return pars;
        }

        private void numericUpDownTreshold_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
