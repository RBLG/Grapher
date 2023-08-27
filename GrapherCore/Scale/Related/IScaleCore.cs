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
        List<Graduation> GetMilestones(); //TODO is it usefull in output scales?

        /// <summary>
        /// Axis label for the GUI
        /// </summary>
        string Label { get; }


        /// <summary>
        /// return the Gui element that allow to manipulate the scale. 
        /// this element will be visible in the axis settings
        /// </summary>
        Control GetControl();

    }
}
