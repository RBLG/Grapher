using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Modes
{
    //list of all modes to be available in the user interface (targeted at table module's mode)
    public static class AvailableModes
    {
        private static readonly List<AvailableMode> list = new()
        {
           new AvailableMode("Multiply",()=>new MultiplyMode(),typeof(MultiplyMode)),
           new AvailableMode("Add",()=>new AddMode(),typeof(AddMode)),
           new AvailableMode("Set",()=>new SetMode(),typeof(SetMode)),
           //new AvailableMode("Ceiling",()=>new MaxMode(),typeof(MaxMode))
        };
        public static readonly IReadOnlyCollection<AvailableMode> modes = list;


        public class AvailableMode
        {
            public string Name { get; private set; }
            public Func<IMode> Factory { get; private set; }
            public Type CType { get; private set; }

            public AvailableMode(string nname, Func<IMode> nfactory, Type cType)
            {
                Name = nname;
                Factory = nfactory;
                CType = cType;
            }
        }

        public static int GetIndex(Type type)
        {
            int it = 0;
            foreach (AvailableMode mode in list)
            {
                if (mode.CType == type)
                {
                    return it;
                }
                it++;
            }
            return -1;
        }

        public static AvailableMode Get(int index)
        {
            return modes.ElementAt(index);
        }
    }
}
