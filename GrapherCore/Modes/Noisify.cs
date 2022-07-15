using Grapher.GuiElement.ScaleSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Modes
{
    public class NoisifyMode : IMode
    {
        public Control GetControl() => new NoisifyModeGui(this);

        public double Seed { set; get; } = 13;
        public double Intensity { set; get; } = 1;

        public double Process(double value, double tab)
        {
            double noise;//need a better random function
            noise = GetNoise();//Math.Sin(time * Seed * 1.1111111) * 100_0001;
            //double premod = noise;
            noise -= (int)noise;
            //double postmod = noise;
            noise = noise * tab * Intensity;
            return value + noise;
        }

        private static UInt64 state = 1;

        public static double GetNoise()
        {
            UInt64 x = state;
            x ^= x << 13;
            x ^= x >> 7;
            x ^= x << 17;
            state = x;
            return x / (double)(UInt64.MaxValue);
        }
    }
}
