using System.Collections.Generic;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    //handle conversion from default scales (linear frequency, milliseconds,etc) to table scale
    //idk im lost on how it work but it does
    public interface IScale
    {
        double GetScaled(double notscaled);

        double GetUnscaled(double scaled);

        double GetMin();
        double GetMax();

        double To01(double notscaled);

        double From01(double scaled);

        double PickValue(Wave wave, double time, Spectrum spectrum);
        void SetValue(double value, Wave wave, double time, Spectrum spectrum);

        List<Milestone> GetMilestones();

        string GetLabel();


    }
    public class Milestone
    {
        public string Label { get; private set; }
        public double Position { get; private set; }

        public Milestone(string nlabel, double npos)
        {
            Label = nlabel;
            Position = npos;
        }
    }
}
