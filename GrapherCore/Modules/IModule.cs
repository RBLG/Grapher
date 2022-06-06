using Grapher.GuiElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher
{
    public interface IModule
    {
        Spectrum GetSpectrum(double time, double bpitch);

        UserControl GetControl();

        String GetName();

        IModule GetInput();
        void SetInput(IModule input);
    }
}
