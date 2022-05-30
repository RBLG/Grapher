using Grapher.Modes;
using Grapher.Modules;
using Grapher.Scale;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher
{
    public class ProtoModule : ISpectrumInput
    {
        private Table table;
        public IProcesser Proc { get; set; }
        public IScale Fscale { get; set; }
        public IScale Tscale { get; set; }
        public ISpectrumInput Input { get; set; }

        public ProtoModule(Table ntable)
        {
            table = ntable;
            Proc = new MultiplyProcesser();
            Fscale = new ExponantialFrequencyScale();
            Tscale = new DynamicToWholeTimeScale();
            Input = new MockInput();
        }

        public Spectrum GetSpectrum(double time)
        {
            Spectrum buffer = Input.GetSpectrum(time);
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
    }
}
