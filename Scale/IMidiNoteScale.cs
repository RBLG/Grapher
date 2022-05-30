using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    public class MidiNoteScale : IScale
    {
        public enum Note
        {
            C1, D1, E1, F1, A1,
        }
        public static readonly double STANDARD_PITCH = 440;

        private double bfreq;

        public MidiNoteScale(double basefreq)
        {
            bfreq = basefreq;
        }

        public double GetMax()
        {
            throw new NotImplementedException();
        }

        public double GetMin()
        {
            throw new NotImplementedException();
        }

        public double GetScaled(double notscaled)
        {
            throw new NotImplementedException();
        }

        public double To01(double notscaled)
        {
            throw new NotImplementedException();
        }

        public double GetUnScaled(double scaled)//?
        {
            return bfreq * Math.Pow(((scaled - 69) / 12), 2);
        }



    }
}
