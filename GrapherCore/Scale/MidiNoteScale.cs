using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    //not usable rn, just there to stock what i know so far about midi format
    public class MidiNoteScale : IScale
    {
        public enum Note
        {
            C1, D1, E1, F1, A1, B1,//
            C2, D2, E2, F2, A2, B2,//
            C3, D3, E3, F3, A3, B3,//
            C4, D4, E4, F4, A4, B4,//
            C5, D5, E5, F5, A5, B5,//
            C6, D6, E6, F6, A6, B6,//
            C7, D7, E7, F7, A7, B7,
        }
        public static readonly double STANDARD_PITCH = 440;

        public double BaseFrequency { get; set; }

        public MidiNoteScale(double basefreq)
        {
            BaseFrequency = basefreq;
        }

        public MidiNoteScale() : this(STANDARD_PITCH) { }

        public double GetMax()
        {
            throw new NotImplementedException();
        }

        public double GetMin()
        {
            return 0;
        }

        public double GetScaled(double notscaled)
        {
            return Math.Log(2, notscaled / BaseFrequency) * 12 + 69;
        }

        public double To01(double notscaled)
        {
            return GetScaled(notscaled) / GetMax();
        }

        public double GetUnscaled(double scaled)//?
        {
            return BaseFrequency * Math.Pow(2, ((scaled - 69) / 12d));
        }

        public double From01(double scaled)
        {
            return GetUnscaled(scaled * GetMax());
        }

        public double PickValue(Wave wave, double time, Spectrum spectrum)
        {
            throw new NotImplementedException();
            //return wave.Note;
        }

        public void SetValue(double value, Wave wave, double time, Spectrum spectrum)
        {
            throw new NotImplementedException();
        }

        public List<Milestone> GetMilestones()
        {
            throw new NotImplementedException();
        }

        private readonly string label = "midi";

        public string GetLabel()
        {
            return label;
        }
    }
}
