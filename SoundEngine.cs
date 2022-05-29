using Grapher.Modes;
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
    public class SoundEngine
    {
        private Table table;
        private IProcesser proc;
        private IScale fscale;
        //private IScale tscale;

        public SoundEngine(List<List<Table3DDot>> ndots)
        {
            table = new Table(ndots);
            proc = new MultiplyProcesser();
            fscale = new LinearFrequencyScale();
            //temporary till wave editor
            spec.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, 400, 0.1));
            spec.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, 800, 0.1));
            spec.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, 1600, 0.1));

            //buffer.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, 400, 0.1));
            //buffer.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, 800, 0.1));
            //buffer.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, 2000, 0.1));
        }
        private Spectrum spec = new Spectrum();
       // private Spectrum buffer = new Spectrum();


        public Spectrum GetSpectrum(double time)
        {
            Spectrum buffer = new Spectrum();
            foreach (Wave wave in spec.Waves)
            {
                //Wave w = buffer.Waves[it];
                Wave w = new Wave(wave.Type, wave.Frequency, wave.Amplitude);
                //w.Frequency = spec.Waves[it].Frequency;
                //w.Amplitude = spec.Waves[it].Amplitude;
                buffer.Waves.Add(w);
                /////
                double freq = fscale.To01(w.Frequency);
                double time2 = time; //reminder of doing a time scale
                proc.Process(w, table.GetOn1Value(freq, time2));
            }
            return buffer;
        }
    }
}
