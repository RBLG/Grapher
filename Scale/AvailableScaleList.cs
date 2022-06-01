using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    public static class AvailableScaleList
    {
        private static readonly List<AvailableScale> list = new List<AvailableScale>()
        {
           new AvailableScale("----Time:----",()=>null,false),
           new AvailableScale("Dynamic",()=>new DynamicToWholeTimeScale(),true),
           new AvailableScale("-Frequency:--",()=>null,false),
           new AvailableScale("Exponantial",()=>new ExponantialFrequencyScale(),true),
           new AvailableScale("Linear",()=>new LinearFrequencyScale(),true),
           new AvailableScale("Mei",()=>new MeiFrequencyScale(),true),
           new AvailableScale("-Amplitude:--",()=>null,false)
           //,new AvailableScale("Decibel",()=>new DecibelAmplitudeScale(),true)
        };
        public static IReadOnlyCollection<AvailableScale> scales = list;

        public class AvailableScale
        {
            public String Name { get; private set; }
            public Func<IScale> Factory { get; private set; }
            public Boolean Selectable { get; private set; }

            //factory take either null or a module already existing to build around
            public AvailableScale(String nname, Func<IScale> nfactory, Boolean nselectable)
            {
                Name = nname;
                Factory = nfactory;
                Selectable = nselectable;
            }
        }


    }
}
