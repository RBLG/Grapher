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
        public double Modulo { get; set; } = 50; //the size of a chunk (in ms)

        public bool IsLooping { get; set; } = false;//if true, the sequence of chunks will loop every table.Width*Modulo ms

        public bool IsRandom { get; set; } = true;// if false, chunk will follow in order from the lowest Width value to the highest

        public string Label => "p(%)";

        public bool Continuous => false;

        public bool IsCumulative => false;

        public List<Graduation> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public Control GetControl() => new PhaseModuloGui(this);


        public double Scale(double notscaled) => (int)(notscaled / Modulo);

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        {
            double rtn = Scale(spectrum.Time);
            if (IsLooping)
            { rtn %= size; }
            if (IsRandom)// randomizing through modulo, shader noise style
            {
                rtn = (Math.Sin(rtn * spectrum.NoteSeed * Seed) + 1) * (size * 100_000 - 1) % size;
            }
            return rtn;
        }


    }
}
