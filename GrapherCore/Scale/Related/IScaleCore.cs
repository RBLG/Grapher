using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        List<Graduation> GetMilestones();

        /// <summary>
        /// Axis label for the GUI
        /// </summary>
        string Label { get; }

        /// <summary>
        /// return if the scale accept values inbetween.<br/>
        /// TODO will control interpolation and generation
        /// </summary>
        bool Continuous { get; }

        /// <summary>
        /// return the Gui element that allow to manipulate the scale. 
        /// this element will be visible in the axis settings
        /// </summary>
        Control GetControl();

        /// <summary>
        /// define if past the last index it interpolate with the first or stay on the last index <br/>
        /// (basically if it hold or loop)
        /// </summary>
        bool IsLooping { get; }

        /// <summary>
        /// if the array is built each value independent of other or it the last values are added
        /// </summary>
        bool IsCumulative { get; }
    }
}
