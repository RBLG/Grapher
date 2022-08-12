using Grapher.GuiElement;
using Grapher.Scale;
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
        private static readonly List<AvailableModule> list = new()
        {
           new AvailableModule("Pitch",()=>new DefaultPitchModule(),typeof(DefaultPitchModule)),
           new AvailableModule("3D Editor",()=>new TableModule(), typeof(TableModule)),
           new AvailableModule("Harmo Editor",()=>new HarmonicModule(),typeof(HarmonicModule)),
           new AvailableModule("Set Editor",()=>new SettuperModule(),typeof(SettuperModule)),
           
           //new AvailableModule("LH Editor",()=>{var r=new TableModule(); r.MTable.Width=1;return r; },typeof(TableModule)),
           //new AvailableModule("WH Editor",()=>{var r=new TableModule(); r.MTable.Length=1;return r; }, typeof(TableModule)),
           //new AvailableModule("Fake",()=>new MockInput())
        };
        public static readonly IReadOnlyCollection<AvailableModule> modules = list;

        public class AvailableModule
        {
            public String Name { get; private set; }
            public Func<IModule> Factory { get; private set; }
            public Type CType { get; private set; }

            public AvailableModule(String nname, Func<IModule> nfactory, Type cType)
            {
                Name = nname;
                Factory = nfactory;
                CType = cType;
            }
        }

        public static int GetIndex(Type type)
        {
            int it = 0;
            foreach (AvailableModule scale in list)
            {
                if (scale.CType == type)
                {
                    return it;
                }
                it++;
            }
            return -1;
        }

        public static AvailableModule Get(int index)
        {
            return modules.ElementAt(index);
        }
    }
}
