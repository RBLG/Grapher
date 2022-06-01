using Grapher.GuiElement;
using Grapher.Modes;
using Grapher.Modules;
using Grapher.Scale;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher
{
    public class ProtoModule : IModule
    {
        public Table table { get; set; }
        public IProcesser Proc { get; set; }
        public IScale Fscale { get; set; }
        public IScale Tscale { get; set; }
        public IModule Input { get; set; }

        public ProtoModule()
        {
            table = new Table();
            Proc = new MultiplyProcesser();
            Fscale = new ExponantialFrequencyScale();
            Tscale = new DynamicToWholeTimeScale();
            Input = new DefaultPitchModule();
        }

        public Spectrum GetSpectrum(double time, double bpitch)
        {
            Spectrum buffer = Input.GetSpectrum(time, bpitch);
            foreach (Wave w in buffer.Waves)
            {
                double freq = Fscale.To01(w.Frequency);
                double time2 = Tscale.To01(time);
                //till i add output scales
                double val = table.GetOn1Value(freq, time2) * 0.01;//min=0 max=100;
                Proc.Process(w, val);
            }
            return buffer;
        }

        public UserControl GetControl()
        {
            return new Graph3DEditor(this);
        }

        private static int count = 0;

        private String name = "3D Editor " + count++;

        public string GetName()
        {
            return name;
        }
    }
}
