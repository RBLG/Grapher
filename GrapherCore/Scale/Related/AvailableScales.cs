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
    public static class AvailableScales
    {
        private static readonly List<AvailableScale> list = new()
        {
           new AvailableScale("--Time:---------",()=>null,null,false,ScaleType.Time),
           new AvailableScale(" Dynamic (T)",()=>new TimeLinearScale(),typeof(TimeLinearScale),true,ScaleType.Time),
           new AvailableScale(" Modulo (T%)",()=>new TimeModuloScale(),typeof(TimeModuloScale),true,ScaleType.TimeModulo),
           new AvailableScale("--Frequency:----",()=>null,null,false,ScaleType.Frequency),
           new AvailableScale(" Exponantial (F)",()=>new FrequencyExponantialScale(),typeof(FrequencyExponantialScale),true,ScaleType.Frequency),
           new AvailableScale(" Linear (F)",()=>new FrequencyLinearScale(),typeof(FrequencyLinearScale),true,ScaleType.Frequency),
           new AvailableScale(" Mei (F)",()=>new FrequencyMeiScale(),typeof(FrequencyMeiScale),true,ScaleType.Frequency),
           new AvailableScale("--Amplitude:----",()=>null,null,false,ScaleType.Amplitude),
           new AvailableScale(" Linear (A)",()=>new AmplitudeLinearScale(),typeof(AmplitudeLinearScale),true, ScaleType.Frequency),
           //new AvailableScale(" Decibel (A)",()=>new DecibelAmplitudeScale(),typeof(DecibelAmplitudeScale),true ,ScaleType.Amplitude)
           new AvailableScale("--Others:----",()=>null,null,false,ScaleType.Amplitude),
           new AvailableScale(" Padding",()=>new PaddingScale(),typeof(PaddingScale),true, ScaleType.Padding),
           new AvailableScale(" Phase",()=>new PhaseScale(),typeof(PhaseScale),true, ScaleType.Phase),
        };
        public static readonly IReadOnlyCollection<AvailableScale> scales = list;

        public class AvailableScale
        {
            public String Name { get; private set; }
            public Func<IScale?> Factory { get; private set; }
            public bool Selectable { get; private set; }
            public Type? CType { get; private set; }
            public ScaleType SType { get; private set; }//TODO rework to use interface ineritance to need even less code

            //factory take either null or a module already existing to build around
            public AvailableScale(String nname, Func<IScale?> nfactory, Type? ntype, bool nselectable, ScaleType nstype)
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
            foreach (AvailableScale scale in list)
            {
                if (scale.CType == type)
                {
                    return it;
                }
                it++;
            }
            return -1;
        }

        public static AvailableScale Get(int index)
        {
            return scales.ElementAt(index);
        }


    }
}
