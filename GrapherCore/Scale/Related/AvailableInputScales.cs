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
    public static class AvailableInputScales
    {
        private static readonly List<AvailableInputScale> list = new()
        {
           new AvailableInputScale(" Frequency",/*      */()=>new FrequencyInputScale(),/*      */typeof(FrequencyInputScale),/*        */true, ScaleType.Frequency),
           new AvailableInputScale(" Amplitude",/*      */()=>new AmplitudeLinearScale(),/*     */typeof(AmplitudeLinearScale),/*       */true, ScaleType.Amplitude),
           new AvailableInputScale(" Time",/*           */()=>new TimeLinearScale(),/*          */typeof(TimeLinearScale),/*            */true, ScaleType.Time),
           new AvailableInputScale(" Phase",/*          */()=>new PhaseInputScale(),/*          */typeof(PhaseInputScale),/*            */true, ScaleType.Phase),
           new AvailableInputScale(" Padding",/*        */()=>new PaddingScale(),/*             */typeof(PaddingScale),/*               */true, ScaleType.Padding),
           new AvailableInputScale(" Harmonics",/*      */()=>new HarmonicScale(),/*            */typeof(HarmonicScale),/*              */true, ScaleType.Frequency),
           new AvailableInputScale(" Time Chunk",/*     */()=>new TimeModuloScale(),/*          */typeof(TimeModuloScale),/*            */true, ScaleType.TimeModulo),
           new AvailableInputScale(" Phase Chunk",/*    */()=>new PhaseModuloScale(),/*         */typeof(PhaseModuloScale),/*           */true, ScaleType.PhaseModulo),
        };
        public static readonly IReadOnlyCollection<AvailableInputScale> scales = list;

        public class AvailableInputScale
        {
            public String Name { get; private set; }
            public Func<IInputScale?> Factory { get; private set; }
            public bool Selectable { get; private set; }
            public Type? CType { get; private set; }
            public ScaleType SType { get; private set; }//TODO rework to use interface ineritance to need even less code

            //factory take either null or a module already existing to build around
            public AvailableInputScale(String nname, Func<IInputScale?> nfactory, Type? ntype, bool nselectable, ScaleType nstype) {
                Name = nname;
                Factory = nfactory;
                Selectable = nselectable;
                CType = ntype;
                SType = nstype;
            }
        }

        public enum ScaleType
        {
            Time, TimeModulo, Frequency, Amplitude, Padding, Phase, None, PhaseModulo
        }

        public static int GetIndex(Type type) {
            int it = 0;
            foreach (AvailableInputScale scale in list) {
                if (scale.CType == type) {
                    return it;
                }
                it++;
            }
            return -1;
        }

        public static AvailableInputScale Get(int index) {
            return scales.ElementAt(index);
        }


    }
}
