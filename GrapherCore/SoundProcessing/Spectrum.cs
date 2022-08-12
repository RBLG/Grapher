using Grapher.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher
{
    /// <summary>
    /// a decomposition of the sample value at a time t.
    /// allow for a less mathematicaly complex handling of pretty much everything
    /// </summary>
    public class Spectrum
    {
        public List<Wave> Waves { get; set; } = new();

        public double Time { get; set; }//time since the the beginning of the note event
        public double TimeOff { get; set; }//time since the end of the note event
        public double BasePitch { get; set; }//frequency post conversion from midi to Hz and detune
        public double NoteSeed { get; set; }// a seed for random values


        public Spectrum() { }

        public void Reset(
            double time,
            double timeoff,
            double bpitch,
            double nseed
            )
        {
            Time = time;
            TimeOff = timeoff;
            BasePitch = bpitch;
            NoteSeed = nseed;
            foreach (Wave wave in Waves)
            {
                wave.Time = time;
            }
        }


        public class Wave
        {
            public WaveType Type { get; private set; }
            //public Func<Wave, double> WaveGenerator { get; private set; } = (w) => 0; //todo
            public double Frequency { get; set; } //see LinearFrequencyScale
            public double Amplitude { get; set; } //see LinearAmplitudeScale
            public double Phase { get; set; } = 0.5; //see PhaseScale
            public double Padding { get; set; } = 0.5; //see PadddingScale
            public double Time { get; set; }//TODO

            //values not changed by modules
            //sourcetime in spectrum
            public double SourceFrequency { get; set; }

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
