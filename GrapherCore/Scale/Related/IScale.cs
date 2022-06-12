using Grapher.Modules;
using System;
using System.Collections.Generic;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    /// <summary>
    /// handle conversion from default scales (linear frequency, milliseconds,etc) to table scale
    /// </summary>
    public interface IScale
    {
        double Min { get; }
        double Max { get; }

        double Scale(double notscaled);
        double Unscale(double scaled);

        double ScaleTo(double notscaled, double max);
        double UnscaleFrom(double scaled, double max);

        double ScaleTo01(double notscaled);
        double UnscaleFrom01(double scaled);

        double PickValue(Wave wave, double time, Spectrum spectrum);
        void SetValue(double value, Wave wave, double time, Spectrum spectrum);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Graduations> GetMilestones();

        /// <summary>
        /// Axis label for the GUI
        /// </summary>
        string Label { get; }

        /// <summary>
        /// return if the scale accept values inbetween
        /// </summary>
        /// <returns></returns>
        Boolean IsContinuous();
    }

    /// <summary>
    /// visual marks on the side of the axis 
    /// </summary>
    public class Graduations
    {
        public string Label { get; private set; }
        public double Position { get; private set; }

        public Graduations(string nlabel, double npos)
        {
            Label = nlabel;
            Position = npos;
        }
    }
}
