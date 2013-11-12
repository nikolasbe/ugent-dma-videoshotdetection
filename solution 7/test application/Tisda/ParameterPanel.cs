using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tisda
{
    //Interface to ensure each panel for the detection method can return its parameters
    public interface ParameterPanel
    {
        object[] getParams();
    }
}
