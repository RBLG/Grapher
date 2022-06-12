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
            public double Frequency { get; set; }
            public double Amplitude { get; set; }
            public Wave(WaveType ntype, double nfreq, double namp)
            {
                Type = ntype;
                Frequency = nfreq;
                Amplitude = namp;
            }
        }

        public enum WaveType
        { // to replace by self generation of the wave
            Sinus, Noise, Triangle, Power
        }
    }
}
