using Grapher.Editor3d.Processing;
using Grapher.GuiElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Modules
{
    public class TableModule2 : IModule
    {
        public RawTable Table { get; set; } = new(20, 50);

        public string Name => "table module 2";

        public IModule Input { get; set; } = new DefaultPitchModule();

        public UserControl GetControl() => new TableModule2Editor();

        public Spectrum GetSpectrum(double time, double timeoff, double bpitch, double seed) {
            throw new NotImplementedException();
        }

        public void SetInput(IModule input) {
            throw new NotImplementedException();
        }
    }
}
