using Grapher.GuiElement.ScaleSettings;
using Grapher.Modes;
using Grapher.Modules;
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
    /// <summary>
    /// modulo/chunk axis allow for transition between two coordinates over a duration (random if random is selected, otherwise in order)
    /// </summary>
    public class TimeModuloScale : IInputScale
    {
        public double Seed { get; set; } = 13; //customizable number to change the randomness of the random pattern
        public double Modulo { get; set; } = 50; //the size of a chunk (in ms)

        public bool IsLooping { get; set; } = false;//if true, the sequence of chunks will loop back to the first value after Modulo*size ms

        public bool IsRandom { get; set; } = true;// if false, chunk will follow in order from the lowest value to the highest

        public bool IsPhasing { get; set; } = false;//if true, duration is adjusted to the nearest multiple of the phase, to be in sync

        public string Label => "t(%)";

        public bool Continuous => false;


        public List<Graduation> GetMilestones() {
            return new() {

            };
        }

        public Control GetControl() => new TimeModuloGui(this);

        public (uint, uint, double) PickValueTo2(Wave wave, Spectrum spectrum, uint size) {
            double duration = Modulo;

            // duplicate of the regular time scale for handling IsPhasing /////
            if (IsPhasing) {

                double count = duration * 0.001d * wave.Frequency;
                double intcount = (int)count;
                if (count != intcount) {
                    intcount += 1;
                }
                duration = intcount / wave.Frequency * 1000;
            }
            ///////////////
            double tratio = spectrum.SourceTime / duration;
            uint val1 = (uint)tratio;
            uint val2 = val1 + 1;
            double mix = tratio - val1;

            val1 = ComputeIndex(spectrum, size, val1);
            val2 = ComputeIndex(spectrum, size, val2);

            return (val1, val2, mix);
        }


        /// <summary>
        /// applies looping and randomness to the index if enabled
        /// </summary>
        public uint ComputeIndex(Spectrum spectrum, uint size, double index) {
            if (IsLooping) { index %= size; }
            if (IsRandom)// randomizing through modulo, shader noise style
            {
                double seed = (Seed == 0) ? spectrum.NoteSeed : Seed;

                //get a pseudorandom value from the index
                index = (Math.Sin(index * seed * 13.531) + 1) * (size * 100_000 - 1) % size;
            }
            return (uint)index;
        }
    }
}
