using Grapher.GuiElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Modules
{
    public interface IModule
    {
        /// <summary>
        /// return the decomposed set of (usually sinuses) waves.<br/>
        /// will be replaced by ApplySpectrum with a Spectrum as param to allow multithreading
        /// </summary>
        Spectrum GetSpectrum(double time, double timeoff, double bpitch, double seed);


        /// <summary>
        /// return a new GUI for the user to manipulate the module if there is one
        /// </summary>
        /// <returns></returns>
        UserControl? GetControl();


        /// <summary>
        /// return the name for the user to identify the module
        /// </summary>
        string Name { get; }


        /// <summary>
        /// return the module input if it has one
        /// </summary>
        /// <returns></returns>
        IModule? Input { get; }


        /// <summary>
        /// set the input, if it has one
        /// </summary>
        void SetInput(IModule input);

    }
}
