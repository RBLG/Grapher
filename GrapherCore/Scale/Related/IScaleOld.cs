using Grapher.Modes;
using Grapher.Modules;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Scale.Related
{
    /// <summary>
    /// handle conversion from default scales (linear frequency, milliseconds,etc) to table scale
    /// </summary>
    public interface IScaleOld //: IInputScale, IOutputScale
    {
        double Min { get; }
        double Max { get; }

        double Scale(double notscaled);// convert a default scale value to it on the scale value
        double Unscale(double scaled);// does the oposite

        double ScaleTo(double notscaled, double size);//same as Scale() but /size
        double UnscaleFrom(double scaled, double size);// does the oposite

        double ScaleTo01(double notscaled);//convert it to this scale and put it in 0 to 1 format
        double UnscaleFrom01(double scaled);//does he oposite

        //uncomment if ever needed
        //double PickValue(Wave wave, Spectrum spectrum);
        //void SetValue(Wave wave, Spectrum spectrum, double value);


        /// <summary>
        /// pick, scale and return the value corresponding to this scale
        /// </summary>
        double PickValueTo(Wave wave, Spectrum spectrum, double size);

        /// <summary>
        /// pick the value, scale it to 01, process it with mode then unscale it from 01 and set it back
        /// </summary>
        void ProcessValue(Wave wave, Spectrum spectrum, double size, IMode mode, double tval);

        /// <summary>
        /// return the list of visual marks on the table axis
        /// </summary>
        /// <returns></returns>
        List<Graduations> GetMilestones();

        /// <summary>
        /// Axis label for the GUI
        /// </summary>
        string Label { get; }

        /// <summary>
        /// return if the scale accept values inbetween.<br/>
        /// TODO will control interpolation and generation
        /// </summary>
        Boolean Continuous { get; }

        /// <summary>
        /// return the Gui element that allow to manipulate the scale. 
        /// this element will be visible in the axis settings
        /// </summary>
        Control GetControl();
    }

    /// <summary>
    /// visual marks on the side of the axis 
    /// </summary>
    public class Graduations
    {
        public string Label { get; private set; }//what to display alongside the mark. may it be text or number for example
        public double Position { get; private set; }//the position on the axis (between 0 and 1)

        public Graduations(string nlabel, double npos)
        {
            Label = nlabel;
            Position = npos;
        }
    }
}
