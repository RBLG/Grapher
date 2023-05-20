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

        public double Detune { get; set; } = 0;

        public List<Graduation> GetMilestones() {
            throw new NotImplementedException();
        }

        public Control GetControl() => new PhaseModuloGui(this);


        public double Scale(double notscaled) => (int)(notscaled / CycleCount);

        public double PickValueTo(Wave wave, Spectrum spectrum, uint size) {
            double rtn;
            rtn = PhaseInputScale.GetAbsPhase(wave, spectrum, Detune, 1);
            rtn = (int)(rtn / CycleCount);
            if (IsLooping) { rtn %= size; }
            if (IsRandom) {
                double seed = (Seed == 0) ? spectrum.NoteSeed : Seed;

                rtn = (Math.Sin(rtn * seed * 13.531) + 1) * (size * 100_000 - 1) % size;
            }
            return rtn;
        }

        public (uint, uint, double) PickValueTo2(Wave wave, Spectrum spectrum, uint size) {
            double phase = PhaseInputScale.GetAbsPhase(wave, spectrum, Detune, 1);
            uint val1 = (uint)(phase / CycleCount);
            uint val2 = val1 + 1;
            double mix = phase / CycleCount - val1;

            val1 = ComputeIndex(spectrum, size, val1);
            val2 = ComputeIndex(spectrum, size, val2);
            return (val1, val2, mix);
        }

        public uint ComputeIndex(Spectrum spectrum, uint size, double rtn) {
            if (IsLooping) { rtn %= size; }
            if (IsRandom) {
                double seed = (Seed == 0) ? spectrum.NoteSeed : Seed; //TODO document
                rtn = (Math.Sin(rtn * seed * 13.531) + 1) * (size * 100_000 - 1) % size;
            }
            return (uint)rtn;
        }


    }
}
