using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Modes
{
    public static class AvailableModes
    {
        private static readonly List<AvailableMode> list = new List<AvailableMode>()
        {
           new AvailableMode("Multiply (0-200%)",()=>new MultiplyProcesser(),typeof(MultiplyProcesser))
        };
        public static readonly IReadOnlyCollection<AvailableMode> modes = list;


        public class AvailableMode
        {
            public String Name { get; private set; }
            public Func<IMode> Factory { get; private set; }
            public Type CType { get; private set; }

            public AvailableMode(String nname, Func<IMode> nfactory, Type cType)
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
