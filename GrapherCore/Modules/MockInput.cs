using Grapher.GuiElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Modules
{
    public class MockInput : IModule
    {
        private readonly Spectrum main = new();
        private readonly Spectrum buffer = new();

        public MockInput()
        {
            buffer.Waves.Add(new(Spectrum.WaveType.Sinus, 0, 0));
            buffer.Waves.Add(new(Spectrum.WaveType.Sinus, 0, 0));
            buffer.Waves.Add(new(Spectrum.WaveType.Sinus, 0, 0));
            buffer.Waves.Add(new(Spectrum.WaveType.Sinus, 0, 0));
            buffer.Waves.Add(new(Spectrum.WaveType.Sinus, 0, 0));
            buffer.Waves.Add(new(Spectrum.WaveType.Sinus, 0, 0));
        }

        public UserControl? GetControl()
        { return null; }

        public string Name { get; set; } = "Mock Input";

        public Spectrum GetSpectrum(double time, double timeoff, double bpitch)
        {
            for (int it = 0; it < main.Waves.Count; it++)
            {
                Wave bw = buffer.Waves[it];
                bw.Frequency = bpitch * (it * 2 + 1);//mw.Frequency;
                bw.Amplitude = 0.3 / Math.Pow(3, it);//mw.Amplitude;
            }
            return buffer;
        }

        public IModule? Input { get; }

        public void SetInput(IModule input)
        { return; }

        public EnvStatus IsOver(double time, double timeoff)
        { return EnvStatus.NotHandled; }
    }
}
