using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    public static class AvailableScales
    {
        private static readonly List<AvailableScale> list = new List<AvailableScale>()
        {
           new AvailableScale("--Time:---------",()=>null,null,false,ScaleType.Time),
           new AvailableScale(" Dynamic (T)",()=>new LoopingTimeScale(),typeof(LoopingTimeScale),true,ScaleType.Time),
           new AvailableScale("--Frequency:----",()=>null,null,false,ScaleType.Frequency),
           new AvailableScale("Exponantial (F)",()=>new ExponantialFrequencyScale(),typeof(ExponantialFrequencyScale),true,ScaleType.Frequency),
           new AvailableScale(" Linear (F)",()=>new LinearFrequencyScale(),typeof(LinearFrequencyScale),true,ScaleType.Frequency),
           new AvailableScale(" Mei (F)",()=>new MeiFrequencyScale(),typeof(MeiFrequencyScale),true,ScaleType.Frequency),
           new AvailableScale("--Amplitude:----",()=>null,null,false,ScaleType.Amplitude),
           new AvailableScale(" Linear (A)",()=>new LinearAmplitudeScale(),typeof(LinearAmplitudeScale),true, ScaleType.Frequency),
           //new AvailableScale("Decibel (A)",()=>new DecibelAmplitudeScale(),typeof(DecibelAmplitudeScale),true ,ScaleType.Amplitude)
        };
        public static IReadOnlyCollection<AvailableScale> scales = list;

        public class AvailableScale
        {
            public String Name { get; private set; }
            public Func<IScale> Factory { get; private set; }
            public Boolean Selectable { get; private set; }
            public Type CType { get; private set; }
            public ScaleType SType { get; private set; }

            //factory take either null or a module already existing to build around
            public AvailableScale(String nname, Func<IScale> nfactory, Type ntype, Boolean nselectable, ScaleType nstype)
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
            Time, Frequency, Amplitude, Padding
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
