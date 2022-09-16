using Grapher.GuiElement.ScaleSettings;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    public class PhaseOutputScale : IOutputScale
    {
        //public double Min => 0;
        //public double Max => 1;

        public string Label => "Phase";

        public List<Graduation> GetMilestones()
        {
            return new()
            {
                new Graduation("0%", 0),
                new Graduation("50%", 0.5),
                new Graduation("100%", 1)
            };
        }

        public Control GetControl() => new PhaseOutputGui(this);

        public bool Continuous => true;
        public bool IsLooping => true;

        public bool IsAbsolute { get; set; } = true;
        public double Offset { get; set; } = 0;

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            if (IsAbsolute)
            {
                //double val = GetAbsPhase(wave, spectrum);
                //double postval = mode.Process(val, tval);
                //wave.Phase += postval - val + Offset / 100;

                //TODO improve by removing the need to recalculate globalphase 2 time
                wave.Phase = GetRevert(wave, spectrum, mode.Process(GetAbsPhase(wave, spectrum), tval)) + Offset;
            }
            else
            { wave.Phase = mode.Process(wave.Phase, tval); }
        }

        public static double GetAbsPhase(Spectrum.Wave wave, Spectrum spectrum)
        {
            return wave.Phase + GetGlobalPhase(wave, spectrum);
        }

        public static double GetRevert(Spectrum.Wave wave, Spectrum spectrum, double val)
        {
            return val - GetGlobalPhase(wave, spectrum);
        }

        public static double GetGlobalPhase(Spectrum.Wave wave, Spectrum spectrum)
        {
            return spectrum.Time / 1000 * wave.Frequency;
        }
    }
}
