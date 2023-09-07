using Grapher.GuiElement.ScaleSettings;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public List<Graduation> GetMilestones() {
            return new()
            {
                new Graduation("0%", 0),
                new Graduation("50%", 0.5),
                new Graduation("100%", 1)
            };
        }

        public Control GetControl() => new PhaseOutputGui(this);

        public bool IsAbsolute { get; set; } = true;
        public double Offset { get; set; } = 0.25;

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval) {
            if (IsAbsolute) {

                double glob = GetGlobalPhase(wave, spectrum);
                double absphase = GetAbsPhase(wave, glob);
                double nval = mode.Process(absphase, tval);
                wave.PhaseOffset = GetRevert(nval, glob) + Offset;
            } else {
                wave.PhaseOffset = mode.Process(wave.PhaseOffset, tval);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetAbsPhase(Wave wave, double globphase) {
            return wave.PhaseOffset + globphase;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetRevert(double val, double globphase) {
            return val - globphase;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetGlobalPhase(Wave wave, Spectrum spectrum) {
            return spectrum.SourceTime * 0.001d * wave.Frequency;
        }
    }
}
