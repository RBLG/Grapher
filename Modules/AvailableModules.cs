using Grapher.GuiElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Modules
{
    public class AvailableModules
    {
        private static readonly List<AvailableModule> list = new List<AvailableModule>()
        {
           new AvailableModule("Pitch",()=>new DefaultPitchModule()),
           new AvailableModule("3D Editor",()=>new ProtoModule()),
           new AvailableModule("LH Editor",()=>{var r=new ProtoModule(); r.table.Width=1;return r; }),
           new AvailableModule("WH Editor",()=>{var r=new ProtoModule(); r.table.Length=1;return r; }),
           new AvailableModule("Fake",()=>new MockInput())
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
