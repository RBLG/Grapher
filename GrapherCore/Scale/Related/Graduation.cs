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
    /// visual marks on the side of the axis 
    /// </summary>
    public class Graduation
    {
        public string Label { get; private set; }//what to display alongside the mark. may it be text or number for example
        public double Position { get; private set; }//the position on the axis (between 0 and 1)

        public Graduation(string nlabel, double npos)
        {
            Label = nlabel;
            Position = npos;
        }
    }
}
