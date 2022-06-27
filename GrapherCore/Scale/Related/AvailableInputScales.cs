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
           new AvailableInputScale("--Time:---------",()=>null,null,false,ScaleType.Time),
           new AvailableInputScale(" Dynamic (T)",()=>new TimeLinearScale(),typeof(TimeLinearScale),true,ScaleType.Time),
           new AvailableInputScale(" Modulo (T%)",()=>new TimeModuloScale(),typeof(TimeModuloScale),true,ScaleType.TimeModulo),
           new AvailableInputScale("--Frequency:----",()=>null,null,false,ScaleType.Frequency),
           new AvailableInputScale(" Exponantial (F)",()=>new FrequencyExponantialScale(),typeof(FrequencyExponantialScale),true,ScaleType.Frequency),
           new AvailableInputScale(" Linear (F)",()=>new FrequencyLinearScale(),typeof(FrequencyLinearScale),true,ScaleType.Frequency),
           new AvailableInputScale(" Mei (F)",()=>new FrequencyMeiScale(),typeof(FrequencyMeiScale),true,ScaleType.Frequency),
           new AvailableInputScale(" Harmonics (F)",()=>new HarmonicScale(),typeof(HarmonicScale),true,ScaleType.Frequency),
           new AvailableInputScale("--Amplitude:----",()=>null,null,false,ScaleType.Amplitude),
           new AvailableInputScale(" Linear (A)",()=>new AmplitudeLinearScale(),typeof(AmplitudeLinearScale),true, ScaleType.Frequency),
           //new AvailableScale(" Decibel (A)",()=>new DecibelAmplitudeScale(),typeof(DecibelAmplitudeScale),true ,ScaleType.Amplitude)
           new AvailableInputScale("--Others:----",()=>null,null,false,ScaleType.Amplitude),
           new AvailableInputScale(" Padding",()=>new PaddingScale(),typeof(PaddingScale),true, ScaleType.Padding),
           new AvailableInputScale(" Phase",()=>new PhaseScale(),typeof(PhaseScale),true, ScaleType.Phase),
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
            public AvailableInputScale(String nname, Func<IInputScale?> nfactory, Type? ntype, bool nselectable, ScaleType nstype)
            {
                Name = nname;
                Factory = nfactory;
                Selectable = nselectable;
                CType = ntype;
                SType = nstype;
            }
        }

        public enum ScaleType
        {
            Time, TimeModulo, Frequency, Amplitude, Padding, Phase
        }

        public static int GetIndex(Type type)
        {
            int it = 0;
            foreach (AvailableInputScale scale in list)
            {
                if (scale.CType == type)
                {
                    return it;
                }
                it++;
            }
            return -1;
        }

        public static AvailableInputScale Get(int index)
        {
            return scales.ElementAt(index);
        }


    }
}
