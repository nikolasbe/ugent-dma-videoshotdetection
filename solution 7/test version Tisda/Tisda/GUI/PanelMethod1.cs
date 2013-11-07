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
    public partial class Method1Panel : UserControl, ParameterPanel
    {
        public Method1Panel()
        {
            InitializeComponent();
        }

        public object[] getParams()
        {
            object[] pars = { (int)numericUpDownDelta2.Value, (double)numericUpDownDelta3.Value };
            return pars;
        }
    }
}
