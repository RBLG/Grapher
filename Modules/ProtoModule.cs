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
        public IMode Mode { get; set; }
        public IScale Wscale { get; set; }
        public IScale Lscale { get; set; }
        public IScale Hscale { get; set; }
        public IModule Input { get; set; }

        public ProtoModule()
        {
            table = new Table();
            Mode = new MultiplyProcesser();
            Wscale = new ExponantialFrequencyScale();
            Lscale = new DynamicToWholeTimeScale();
            Hscale = new LinearAmplitudeScale();
            Input = new DefaultPitchModule();
        }

        public Spectrum GetSpectrum(double time, double bpitch)
        {
            Spectrum buffer = Input.GetSpectrum(time, bpitch);
            foreach (Wave w in buffer.Waves)
            {
                double wval = Wscale.To01(Wscale.PickValue(w, time, buffer));
                double lval = Lscale.To01(Lscale.PickValue(w, time, buffer));

                double tval = table.GetOn1Value(wval, lval);

                double hval = Hscale.GetScaled(Hscale.PickValue(w, time, buffer));
                hval = Mode.Process(Hscale.GetUnscaled(hval), tval);
                Hscale.SetValue(hval, w, time, buffer);
                //till i add output scales
                //double val = table.GetOn1Value(wval, lval);
                //Proc.Process(w, val);
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
