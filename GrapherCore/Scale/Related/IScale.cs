using Grapher.Modes;
using Grapher.Modules;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
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

        double ScaleTo(double notscaled, double size);
        double UnscaleFrom(double scaled, double size);

        double ScaleTo01(double notscaled);
        double UnscaleFrom01(double scaled);

        //uncomment if ever needed
        //double PickValue(Wave wave, Spectrum spectrum);
        //void SetValue(Wave wave, Spectrum spectrum, double value);

        double PickValueTo(Wave wave, Spectrum spectrum, double size);

        /// <summary>
        /// pick the value, scale it to 01, process it with mode then unscale it from 01 and set it back
        /// </summary>
        /// <param name="wave"></param>
        /// <param name="spectrum"></param>
        /// <param name="size">Height size(tval is normalized on 0-1 anyway)</param>
        /// <param name="mode"></param>
        /// <param name="tval">the value from the table</param>
        void ProcessValue(Wave wave, Spectrum spectrum, double size, IMode mode, double tval);

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
        Boolean Continuous { get; }

        Control GetControl();
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
