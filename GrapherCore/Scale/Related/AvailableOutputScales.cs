using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    /// <summary>
    /// handle the list of all scales that should be available in the Gui //TODO update the summary
    /// </summary>
    public static class AvailableOutputScales
    {
        private static readonly List<AvailableOutputScale> list = new()
        {
           new AvailableOutputScale(" Harmonics",/*      */()=>new HarmonicScale(),/*            */typeof(HarmonicScale)),
           new AvailableOutputScale(" Amplitude",/*      */()=>new AmplitudeLinearScale(),/*     */typeof(AmplitudeLinearScale)),
           new AvailableOutputScale(" Phase",/*          */()=>new PhaseOutputScale(),/*         */typeof(PhaseOutputScale)),
           new AvailableOutputScale(" Padding",/*        */()=>new PaddingScale(),/*             */typeof(PaddingScale)),
           new AvailableOutputScale(" Value",/*          */()=>new ValueOutputScale(),/*         */typeof(ValueOutputScale)),
        };
        public static readonly IReadOnlyCollection<AvailableOutputScale> scales = list;

        public class AvailableOutputScale
        {
            public string Name { get; private set; }
            public Func<IOutputScale?> Factory { get; private set; }
            public bool Selectable { get; private set; }
            public Type? CType { get; private set; }

            //tf was that for
            //public ScaleType SType { get; private set; }//TODO rework to use interface ineritance to need even less code

            //factory take either null or a module already existing to build around
            public AvailableOutputScale(string nname, Func<IOutputScale?> nfactory, Type? ntype) {//, bool nselectable, ScaleType nstype) {
                Name = nname;
                Factory = nfactory;
                Selectable = true;//nselectable;
                CType = ntype;
                //SType = nstype;
            }
        }

        public enum ScaleType
        {
            Time, Frequency, Amplitude, Padding, Phase, None, Value
        }

        public static int GetIndex(Type type) { //HACK replace the list by a set
            int it = 0;
            foreach (AvailableOutputScale scale in list) {
                if (scale.CType == type) { return it; }
                it++;
            }
            return -1;
        }

        public static AvailableOutputScale Get(int index) {
            return scales.ElementAt(index);
        }


    }
}
