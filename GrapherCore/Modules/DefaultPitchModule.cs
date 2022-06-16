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

        public DefaultPitchModule()
        {
            spec.Waves.Add(new Wave(WaveType.Sinus, 0, 0));
        }

        public UserControl? GetControl()
        { return null; }

        //no pitch editor yet but who knows
        public string Name { get; set; } = "Pitch Module" + count++;
        private static int count = 0;

        public Spectrum GetSpectrum(double time, double timeoff, double bpitch, double seed)
        {
            spec.Waves[0].Frequency = bpitch;
            spec.Waves[0].Amplitude = 0.2;
            spec.Time = time;
            spec.TimeOff = timeoff;
            spec.BasePitch = bpitch;
            spec.NoteSeed = seed;
            return spec;
        }

        public IModule? Input { get; }
        public void SetInput(IModule input)
        { return; }

        public EnvStatus IsOver(double time, double timeoff)
        { return EnvStatus.NotHandled; }
    }
}
