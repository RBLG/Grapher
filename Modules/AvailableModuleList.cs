using Grapher.GuiElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Modules
{
    public class AvailableModuleList
    {
        private static readonly List<AvailableModule> list = new List<AvailableModule>()
        {
           new AvailableModule("Pitch",()=>new DefaultPitchModule()),
           new AvailableModule("3D Editor",()=>new ProtoModule()),
           new AvailableModule("Fake",()=>new MockInput())
           //,new AvailableModule("2D Editor",()=>new Graph2DModule())
        };
        public static readonly IReadOnlyCollection<AvailableModule> modules = list;


        public class AvailableModule
        {
            public String Name { get; private set; }
            public Func<IModule> Factory { get; private set; }

            public AvailableModule(String nname, Func<IModule> nfactory)
            {
                Name = nname;
                Factory = nfactory;
            }
        }
    }
}
