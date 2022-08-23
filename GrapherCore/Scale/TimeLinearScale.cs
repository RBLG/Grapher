using Grapher.GuiElement.ScaleSettings;
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
    /// default time scale in milliseconds
    /// </summary>
    public class TimeLinearScale : IInputScale, ITimeScale
    {
        public double Min => 0;
        public double Max { get; set; } = 1000; //represent the duration of the table (in millis)

        public List<Graduation> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public Control GetControl() => new TimeLinearGui(this);

        public string Label => "t(ms)";

        public bool Continuous => true;

        public bool IsLooping { get; set; } = true;

        public int GetCumulativeStackNumber(Wave wave, Spectrum spectrum, double size)
        {
            if (IsLooping)
            {
                return (int)(spectrum.Time /= Max);
            }
            else
            { return 0; }
        }

        public double Hold { get; set; } = 500;

        public double Scale(double notscaled) => ScaleTo01(notscaled) * 1000;
        public double ScaleTo01(double notscaled)
        {
            double rtn = notscaled / Max;
            if (IsLooping) { rtn %= 1; }//loop //TODO optimize modulus
            return rtn;
        }

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        {
            double rtn = spectrum.Time;
            if (IsLooping)
            {
                rtn /= Max;
                rtn -= (int)rtn;//%= 1;//another faster modulo
            }
            else
            {
                if (double.IsNaN(spectrum.TimeOff))
                { rtn = Math.Min(rtn, Hold); }
                else
                { rtn = GetTrueTimeOff(spectrum.Time, spectrum.TimeOff); }
                rtn /= Max;
            }
            return rtn * size;
        }

        public EnvStatus GetEnvStatus(double time, double timeoff)
        {
            return IsLooping ?
                EnvStatus.NotHandled :
                ((!double.IsNaN(timeoff)) && GetTrueTimeOff(time, timeoff) > Max ?
                    EnvStatus.Done :
                    EnvStatus.Handled);
        }

        private double GetTrueTimeOff(double time, double timeoff)
        {
            return Math.Min(time, timeoff + Hold);
        }
    }
}
