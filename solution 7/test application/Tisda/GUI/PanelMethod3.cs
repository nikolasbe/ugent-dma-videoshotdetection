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
    public partial class Method3Panel : UserControl, ParameterPanel
    {
        private String[] region_sizes = { "2x2", "4x4", "8x8", "16x16" };
        private int[] region_values = { 2, 4, 8, 16 };
        List<int> powers;

        public Method3Panel()
        {
            InitializeComponent();
            //Initialize data source for comboxStep
            powers = new List<int>();
            for (int i = 1; i < 1000000; i*=2)
            {
                powers.Add(i);
            }
            comboBoxStep.DataSource = powers;
            //Initialize data source for comboboxblocksize
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

        public int getStep()
        {
            return powers.ElementAt(comboBoxStep.SelectedIndex);
        }

        public object[] getParams()
        {
            object[] pars = { getTreshold(), getBlockSize(), getStep()};
            return pars;
        }
    }
}
