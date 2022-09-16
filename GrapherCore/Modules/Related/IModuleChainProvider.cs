using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Modules
{
    public interface IModuleChainProvider
    {
        /// <summary>
        /// last module to process things and root of the module tree (or caterpillar)
        /// </summary>
        IModule RootModule { get; set; }

        /// <summary>
        /// how long a midi even has to be computed before being removed (to allow envellopes)
        /// </summary>
        double TimeOffDelay { get; set; }

        /// <summary>
        /// additionnal detune from the main UI
        /// </summary>
        double Detune { get; set; }

    }
}
