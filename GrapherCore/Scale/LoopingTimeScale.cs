using Grapher.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    //default time is in millisecond
    public class LoopingTimeScale : ITimeScale
    {
        public double Min { get; } = 0;
        public double Max { get; set; } = 1000; //represent the duration of the table (in millis)

        public LoopingTimeScale() { }

        public double Scale(double notscaled) //in millis
        {
            return notscaled * 1000 / Max;
        }
        public double Unscale(double scaled)
        {
            return scaled * Max / 1000;
        }

        public double ScaleTo01(double notscaled) //in millis
        {
            double rtn = notscaled / Max;
            if (IsLooping)
            { rtn %= 1; }
            return rtn;//so that it loop
        }
        public double UnscaleFrom01(double scaled)
        {
            return scaled * Max;
        }

        public double ScaleTo(double notscaled, double max)
        {
            return ScaleTo01(notscaled) * max;
        }
        public double UnscaleFrom(double scaled, double max)
        {
            return UnscaleFrom01(scaled / max);
        }

        public double PickValue(Spectrum.Wave wave, double time, Spectrum spectrum)
        {
            return time;
        }

        public void SetValue(double value, Spectrum.Wave wave, double time, Spectrum spectrum)
        {
            return;//cant set time
        }

        public List<Graduations> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public string Label { get; } = "t(ms)";

        public bool IsContinuous()
        { return true; }

        public EnvStatus GetEnvStatus(double time, double timeoff)
        {
            return IsLooping ? EnvStatus.NotHandled : ((Scale(time) > Max) ? EnvStatus.Done : EnvStatus.Handled);
        }

        public bool IsLooping { get; set; } = false;
    }
}
