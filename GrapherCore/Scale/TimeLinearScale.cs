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
    /// default time scale in milliseconds
    /// </summary>
    public class TimeLinearScale : ITimeScale
    {
        public double Min => 0;
        public double Max { get; set; } = 1000; //represent the duration of the table (in millis)

        public TimeLinearScale() { }

        public double Scale(double notscaled) => ScaleTo01(notscaled) * 1000;
        public double ScaleTo01(double notscaled)
        {
            double rtn = notscaled / Max;
            if (IsLooping) { rtn %= 1; }//so that it loop
            return rtn;
        }
        public double ScaleTo(double notscaled, double size) => ScaleTo01(notscaled) * size;

        public double Unscale(double scaled) => scaled * Max / 1000;
        public double UnscaleFrom01(double scaled) => scaled * Max;
        public double UnscaleFrom(double scaled, double size) => UnscaleFrom01(scaled / size);

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        { return ScaleTo(spectrum.Time, size); }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        { return; }

        public List<Graduations> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public System.Windows.Forms.Control GetControl()
        {
            return new GuiElement.ScaleSettings.TimeLinearGui(this);
        }

        public string Label => "t(ms)";

        public bool Continuous => true;
        public EnvStatus GetEnvStatus(double time, double timeoff)
        {
            return IsLooping ? EnvStatus.NotHandled : ((Scale(time) > Max) ? EnvStatus.Done : EnvStatus.Handled);
        }

        public bool IsLooping { get; set; } = false;
    }
}
