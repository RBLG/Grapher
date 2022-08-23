using Grapher.GuiElement.ScaleSettings;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    public class PhaseModuloScale : IInputScale
    {
        public double Seed { get; set; } = 13; //customizable number to change the randomness of the random pattern
        public double CycleCount { get; set; } = 1; //size of a chunk in phase multiplier
        public bool IsLooping { get; set; } = false;//if true, the sequence of chunks will loop every table.Width*Modulo ms

        public bool IsRandom { get; set; } = true;// if false, chunk will follow in order from the lowest Width value to the highest

        public string Label => "p(%)";

        public bool Continuous => false;

        public int GetCumulativeStackNumber(Wave wave, Spectrum spectrum, double size)
        {
            if (IsRandom || !IsLooping)
            {
                return 0;
            }
            else
            {
                double rtn = PhaseInputScale.GetAbsPhase(wave, spectrum, Detune, 1);
                rtn = (int)(rtn / CycleCount);
                rtn /= size;
                return (int)rtn;
            }
        }

        public double Detune { get; set; } = 0;

        public List<Graduation> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public Control GetControl() => new PhaseModuloGui(this);


        public double Scale(double notscaled) => (int)(notscaled / CycleCount);

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        {
            double rtn;
            rtn = PhaseInputScale.GetAbsPhase(wave, spectrum, Detune, 1);
            rtn = (int)(rtn / CycleCount);
            if (IsLooping)
            { rtn %= size; }
            if (IsRandom)
            {
                rtn = (Math.Sin(rtn * spectrum.NoteSeed / Seed) + 1) * (size * 100_000 - 1) % size;
            }
            return rtn;
        }


    }
}
