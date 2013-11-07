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
    public partial class Method6Panel : UserControl, ParameterPanel
    {
        private String[] region_sizes = { "2x2", "4x4", "8x8", "16x16" };
        private int[] region_values = { 4, 16, 64, 256 };

        public Method6Panel()
        {
            InitializeComponent();
            comboBoxRegionSize.DataSource = region_sizes;
        }

        private double getTreshold()
        {
            return (double)numericUpDownTreshold.Value;
        }

        private double getVar()
        {
            return (double)numericUpDownVar.Value;
        }

        private int getBins()
        {
            return (int)numericUpDownBins.Value;
        }

        private int getRegionSize()
        {
            return region_values[comboBoxRegionSize.SelectedIndex];
        }

        private int getBuffer()
        {
            return (int)numericUpDownBuffer.Value;
        }

        public object[] getParams()
        {
            object[] pars = { getTreshold(), getVar(), getBins(), getRegionSize(), getBuffer() };
            return pars;
        }
    }
}
