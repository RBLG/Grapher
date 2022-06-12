using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Modules
{
    public interface IModuleChainProvider
    {
        IModule GetRootModule();

        void SetRootModule(IModule module);

    }
}
