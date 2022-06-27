using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale.Related
{
    /// <summary>
    /// the behavior that both input scales and output scales share
    /// </summary>
    public interface IScaleCore
    {
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
        System.Windows.Forms.Control GetControl();
    }
}
