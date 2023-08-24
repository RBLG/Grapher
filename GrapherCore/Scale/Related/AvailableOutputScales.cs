using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    /// <summary>
    /// handle the list of all scales that should be available in the Gui
    /// </summary>
    public static class AvailableOutputScales
    {
        private static readonly List<AvailableOutputScale> list = new()
        {
           new AvailableOutputScale(" Harmonics",/*      */()=>new HarmonicScale(),/*            */typeof(HarmonicScale),/*             */true, ScaleType.Frequency),
           new AvailableOutputScale(" Amplitude",/*      */()=>new AmplitudeLinearScale(),/*     */typeof(AmplitudeLinearScale),/*      */true, ScaleType.Amplitude),
           new AvailableOutputScale(" Phase",/*          */()=>new PhaseOutputScale(),/*         */typeof(PhaseOutputScale),/*          */true, ScaleType.Phase),
           new AvailableOutputScale(" Padding",/*        */()=>new PaddingScale(),/*             */typeof(PaddingScale),/*              */true, ScaleType.Padding),
        };
        public static readonly IReadOnlyCollection<AvailableOutputScale> scales = list;

        public class AvailableOutputScale
        {
            public string Name { get; private set; }
            public Func<IOutputScale?> Factory { get; private set; }
            public bool Selectable { get; private set; }
            public Type? CType { get; private set; }
            public ScaleType SType { get; private set; }//TODO rework to use interface ineritance to need even less code

            //factory take either null or a module already existing to build around
            public AvailableOutputScale(string nname, Func<IOutputScale?> nfactory, Type? ntype, bool nselectable, ScaleType nstype) {
                Name = nname;
                Factory = nfactory;
                Selectable = nselectable;
                CType = ntype;
                SType = nstype;
            }
        }

        public enum ScaleType
        {
            Time, Frequency, Amplitude, Padding, Phase, None
        }

        public static int GetIndex(Type type) {
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
