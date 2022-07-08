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
    /// "trick" to turn a 123456123456123456 table on time into<br/>
    /// 123456<br/>
    /// 123456<br/>
    /// 123456<br/>
    /// for easy repeating patterns
    /// </summary>
    public class TimeModuloScale : IInputScale
    //not ITimeScale so it can be used with other time scale & havent impl how multiple time scale interact for TableModule time scale
    {
        public double Seed { get; set; } = 13; //customizable number to change the randomness of the random pattern
        public double Modulo { get; set; } = 50; //the size of a chunk (in ms)

        public bool IsLooping { get; set; } = false;//if true, the sequence of chunks will loop every table.Width*Modulo ms

        public bool IsRandom { get; set; } = true;// if false, chunk will follow in order from the lowest Width value to the highest

        public string Label => "t(%)";

        public bool Continuous => false;

        public bool IsCumulative => false;

        public List<Graduation> GetMilestones()
        {
            return new()
            {

            };
        }

        public Control GetControl() => new TimeModuloGui(this);


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
