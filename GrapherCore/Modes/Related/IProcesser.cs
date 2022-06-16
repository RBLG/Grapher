using Grapher.Scale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Modes
{
    public interface IMode
    {
        double Process(double value,double tab);
        Control GetControl();
    }
}
