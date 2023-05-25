using Grapher.GuiElement;
using Grapher.Scale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Modules
{
    public class DefaultPitchModule : IModule
    {
        private readonly Spectrum spec = new();

        public DefaultPitchModule() {
            spec.Waves.Add(new());
        }

        public UserControl? GetControl() { return null; }

        public string Name { get; set; } = "Pitch Module";

        public Spectrum GetSpectrum(double time, double timeoff, double bpitch, double seed) {
            spec.Reset(time, timeoff, bpitch, seed);
            spec.Waves[0].Reset(bpitch, 0.2, 0, 0.5);
            return spec;
        }

        public IModule? Input { get; }
        public void SetInput(IModule input) { return; }
    }
}
