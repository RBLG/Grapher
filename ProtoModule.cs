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
        private IProcesser proc;
        private IScale fscale;
        private IScale tscale;
        private ISpectrumInput input;

        public ProtoModule(List<List<Table3DDot>> ndots)
        {
            table = new Table(ndots);
            proc = new MultiplyProcesser();
            fscale = new LinearFrequencyScale();
            tscale = new DynamicMillisTimeScale();
            input = new MockInput();
        }

        public Spectrum GetSpectrum(double time)
        {
            Spectrum buffer = input.GetSpectrum(time);
            foreach (Wave w in buffer.Waves)
            {
                double freq = fscale.To01(w.Frequency);
                double time2 = tscale.To01(time);
                proc.Process(w, table.GetOn1Value(freq, time2));
            }
            return buffer;
        }
    }
}
