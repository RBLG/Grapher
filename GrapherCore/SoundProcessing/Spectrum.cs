using Grapher.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher
{
    public class Spectrum
    {
        public List<Wave> Waves { get; private set; } = new();

        public Spectrum() { }

        public class Wave
        {
            public WaveType Type { get; private set; }
            //public Func<Wave, double> WaveGenerator { get; private set; } = (w) => 0; //todo
            public double Frequency { get; set; } //see LinearFrequencyScale
            public double Amplitude { get; set; } //see LinearAmplitudeScale
            public double Phase { get; set; } = 0.5; //see PhaseScale
            public double Padding { get; set; } = 0.5; //see PadddingScale
            public Wave(WaveType ntype, double nfreq, double namp)
            {
                Type = ntype;
                Frequency = nfreq;
                Amplitude = namp;
            }
        }

        public enum WaveType
        { // to replace by self generation of the wave
            Sinus, Complex
        }
    }
}
