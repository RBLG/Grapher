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
        //private MidiNoteScale midi=new MidiNoteScale();

        private Spectrum spec = new Spectrum();

        public DefaultPitchModule()
        {
            spec.Waves.Add(new Wave(WaveType.Sinus, 0, 0));
        }

        public UserControl GetControl()
        {
            return null;
        }

        private static int count = 0;

        //no pitch editor yet but who knows
        private String name = "Pitch Editor " + count++;

        public string GetName()
        {
            return name;
        }

        public Spectrum GetSpectrum(double time, double bpitch)
        {
            spec.Waves[0].Frequency = bpitch;
            spec.Waves[0].Amplitude = 0.2;
            return spec;
        }

        public IModule GetInput()
        {
            return null;
        }

        public void SetInput(IModule input)
        {
            return;
        }
    }
}
