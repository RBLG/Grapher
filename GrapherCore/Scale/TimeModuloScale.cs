﻿using Grapher.GuiElement.ScaleSettings;
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

        public double PickValueTo(Wave wave, Spectrum spectrum, uint size)
        {
            double rtn = spectrum.SourceTime;
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
                double seed = (Seed == 0) ? spectrum.NoteSeed : Seed;

                rtn = (Math.Sin(rtn * seed * 13.531) + 1) * (size * 100_000 - 1) % size;
            }
            return rtn;
        }

        public (uint, uint, double) PickValueTo2(Wave wave, Spectrum spectrum, uint size)
        {
            uint val1 = (uint)(spectrum.SourceTime / Modulo);
            uint val2 = val1 + 1;
            double mix = spectrum.SourceTime / Modulo - val1;

            val1 = ComputeIndex(spectrum, size, val1);
            val2 = ComputeIndex(spectrum, size, val2);

            return (val1, val2, mix);
        }


        public uint ComputeIndex(Spectrum spectrum, uint size, double rtn)
        {
            if (IsLooping)
            { rtn %= size; }
            if (IsRandom)// randomizing through modulo, shader noise style
            {
                double seed = (Seed == 0) ? spectrum.NoteSeed : Seed;

                rtn = (Math.Sin(rtn * seed * 13.531) + 1) * (size * 100_000 - 1) % size;
            }
            return (uint)rtn;
        }
    }
}
