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
    public partial class Method2Panel : UserControl, ParameterPanel
    {
        private String[] region_sizes = { "2x2", "4x4", "8x8", "16x16" };
        private int[] region_values = { 2, 4, 8, 16};

        public Method2Panel()
        {
            InitializeComponent();
            comboBoxBlockSize.DataSource = region_sizes;
        }

        public double getTreshold()
        {
            return (double)numericUpDownTreshold.Value;
        }

        public int getBlockSize()
        {
            return region_values[comboBoxBlockSize.SelectedIndex];
        }

        public int getWindowSize()
        {
            return (int)numericUpDownWindowSize.Value;
        }

        public object[] getParams()
        {
            object[] pars = { getTreshold(), getBlockSize(), getWindowSize() };
            return pars;
        }
    }
}
