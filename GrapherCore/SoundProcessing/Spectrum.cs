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

        public double SourceTime { get; private set; }//time since the the beginning of the note event
        public double TimeOff { get; private set; }//time since the end of the note event
        public double BasePitch { get; private set; }//frequency post conversion from midi to Hz and detune
        public double NoteSeed { get; private set; }// a seed for random values


        public Spectrum() { }

        public void Reset(
            double time,
            double timeoff,
            double bpitch,
            double nseed
            ) {
            SourceTime = time;
            TimeOff = timeoff; //TODO remove?
            BasePitch = bpitch;
            NoteSeed = nseed;
            foreach (Wave wave in Waves) {
                wave.Time = time;
            }
        }
    }

    public class Wave
    {
        public double Frequency { get; set; } //see LinearFrequencyScale
        public double Amplitude { get; set; } //see LinearAmplitudeScale
        public double Phase { get; set; } //see PhaseScale
        public double Padding { get; set; } //see PadddingScale
        public double Time { get; set; }//TODO

        //values not changed by modules
        //sourcetime in spectrum
        //public double SourceFrequency { get; set; } = 20;

        public void Reset(double nfreq, double namp, double nphase, double npad) {
            Frequency = nfreq;
            Amplitude = namp;
            Phase = nphase;
            Padding = npad;
        }

        public void Copy(Wave nwave) {
            Frequency = nwave.Frequency;
            Amplitude = nwave.Amplitude;
            Phase = nwave.Phase;
            Padding = nwave.Padding;
            Time = nwave.Time;
        }

        public Wave Copy() {
            Wave nwave = new();
            nwave.Copy(this);
            return nwave;
        }
    }
}
