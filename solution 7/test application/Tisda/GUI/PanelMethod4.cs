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
    public partial class Method4Panel : UserControl, ParameterPanel
    {
        public Method4Panel()
        {
            InitializeComponent();
        }

        public double getTreshold()
        {
            return (double)numericUpDownTreshold.Value;
        }

        public int getBins()
        {
            return (int)numericUpDownBins.Value;
        }

        public object[] getParams()
        {
            object[] pars = { getTreshold(), getBins()};
            return pars;
        }
    }
}
