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

        public List<Graduations> GetMilestones()
        {
            return new()
            {
                new Graduations("0%", 0),
                new Graduations("50%", 0.5),
                new Graduations("100%", 1)
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
            { GetRevert(wave, spectrum, mode.Process(GetAbsPhase(wave, spectrum), tval)); }
            else
            { wave.Phase = mode.Process(wave.Phase, tval); }
        }

        private static double GetAbsPhase(Spectrum.Wave wave, Spectrum spectrum)
        {
            return wave.Frequency * (spectrum.Time / 1000 + wave.Phase);
        }

        private static void GetRevert(Spectrum.Wave wave, Spectrum spectrum, double val)
        {
            wave.Phase = (val / wave.Frequency) - (spectrum.Time / 1000);
        }
    }
}
