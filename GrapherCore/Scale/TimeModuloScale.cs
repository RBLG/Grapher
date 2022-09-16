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

        public bool IsPhased { get; set; } = false;//if true, it will wait that phase is 0 to swap

        public string Label => "t(%)";

        public bool Continuous => false;


        public List<Graduation> GetMilestones()
        {
            return new()
            {

            };
        }

        public Control GetControl() => new TimeModuloGui(this);


        public double Scale(double notscaled) => (int)(notscaled / Modulo);

        public double PickValueTo(Wave wave, Spectrum spectrum, int size)
        {
            double rtn = spectrum.Time;
            if (IsPhased) //clip time to the last end of phase cycle
            {
                rtn = (int)(wave.Frequency * rtn / 1000 + wave.Phase);
                rtn = (rtn - wave.Phase) / wave.Frequency * 1000;
            }
            rtn = Scale(rtn);//get the number of the current chunk
            if (IsLooping)
            { rtn %= size; }
            if (IsRandom)// randomizing through modulo, shader noise style
            {
                rtn = (Math.Sin(rtn * spectrum.NoteSeed / Seed) + 1) * (size * 100_000 - 1) % size;
            }
            return rtn;
        }

        public (int, int, double) PickValueTo2(Wave wave, Spectrum spectrum, int size)
        { return Table.PrepareInterpolation(PickValueTo(wave, spectrum, size), size, IsLooping); }
    }
}
