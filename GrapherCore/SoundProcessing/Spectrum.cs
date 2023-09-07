using Grapher.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Grapher
{
    /// <summary>
    /// a decomposition of the sample value at a time t.
    /// </summary>
    public class Spectrum
    {
        public List<Wave> Waves { get; set; } = new(); //TODO prob should change it to array

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
            //foreach (Wave wave in Waves) {
            //    wave.Time = time;
            //}
        }
    }

    public class Wave
    {
        public double Frequency { get; set; } = 1; //see LinearFrequencyScale
        public double Amplitude { get; set; } = 1; //see LinearAmplitudeScale
        public double PhaseOffset { get; set; } = 0; //see PhaseScale
        public double Padding { get; set; } = 0.5; //see PadddingScale
        public double Time { get; set; } = 0;//TODO
        public double ValueFix { get; set; } = 1; //see ValueOutputScale

        //values not changed by modules
        //sourcetime in spectrum
        //public double SourceFrequency { get; set; } = 20;

        public Wave() { }

        public Wave(double nfreq, double namp, double nphase, double npad) {
            this.SetState(nfreq, namp, nphase, npad, 0, 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected void SetState(double nfreq, double namp, double nphase, double npad, double ntime, double nvalf) {
            Frequency = nfreq;
            Amplitude = namp;
            PhaseOffset = nphase;
            Padding = npad;
            Time = ntime;
            ValueFix = nvalf;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Reset(double nfreq, double namp, double nphase, double npad, double ntime) {
            this.SetState(nfreq, namp, nphase, npad, ntime, 1);
        }

        public void Copy(Wave nwave,double ntime) { //TODO rework because rn it role is ambiguous and isnt used
            SetState(nwave.Frequency, nwave.Amplitude, nwave.PhaseOffset, nwave.Padding, ntime, nwave.ValueFix);
        }

        public Wave Copy() {
            Wave nwave = new();
            nwave.Copy(this,this.Time);
            return nwave;
        }
    }
}
