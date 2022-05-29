using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Units
{
    public class MidiNote : IFrequencyUnit
    {
        public enum Note
        {
            C1, D1, E1, F1, A1,
        }
        public static readonly double STANDARD_PITCH = 440;



        private int note;
        private double tuner;

        public MidiNote(int nmidi, double ntuner)
        {
            note = nmidi;
            tuner = ntuner;
        }

        public double GetValue()
        {
            return tuner * Math.Pow(((note - 69) / 12), 2);
        }

        public LinearFrequency ToLinearFrequency()
        {
            return new LinearFrequency(GetValue());
        }

        public IFrequencyUnit ModulateBy(double factor, double min, double max)
        {
            throw new NotImplementedException();
        }
    }



}
