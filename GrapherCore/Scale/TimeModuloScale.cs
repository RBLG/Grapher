using Grapher.Modes;
using Grapher.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class TimeModuloScale : IScale
    //not ITimeScale so it can be used with other time scale & havent impl how multiple time scale interact for TableModule time scale
    {
        public double Min => 0;
        public double Max { get; set; } = 10;

        public double Seed { get; set; } = 13;
        public double Modulo { get; set; } = 50;

        public string Label => "t(%)";

        public bool Continuous => false;


        public List<Graduations> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public System.Windows.Forms.Control GetControl()
        {
            return new GuiElement.ScaleSettings.TimeModuloGui(this);
        }

        public double Scale(double notscaled) /*                    */ => (int)(notscaled / Modulo);
        public double ScaleTo01(double notscaled) /*                */ => Scale(notscaled) / Max;
        public double ScaleTo(double notscaled, double size)
        { //Max is suposed to = size
            double rtn = Scale(notscaled);
            if (IsLooping) { rtn %= size; }
            return rtn;
        }

        public double Unscale(double scaled) /*                     */ => scaled * Modulo;
        public double UnscaleFrom01(double scaled) /*               */ => Unscale(scaled * Max);
        public double UnscaleFrom(double scaled, double size) /*    */ => Unscale(scaled);

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        {
            double rtn = Scale(spectrum.Time);
            // randomizing through modulo, shader noise style
            if (IsRandom)
            {
                rtn = (Math.Sin((rtn * spectrum.NoteSeed) * 13) + 1) * (size * 100_000 - 1);
                rtn %= size;
            }
            else if (IsLooping) { rtn %= size; }
            return rtn;
        }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, IMode mode, double tval)
        { return; }

        public bool IsLooping { get; set; } = false;

        public bool IsRandom { get; set; } = true;


    }
}
