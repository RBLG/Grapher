using Grapher.GuiElement.ScaleSettings;
using Grapher.Modes;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Scale
{
    public class ValueOutputScale : IOutputScale
    {
        public string Label => "Value";

        public Control GetControl() => new BlankScaleGui();

        public List<Graduation> GetMilestones() {
            throw new NotImplementedException();
        }

        public const double TwoPi = 2 * Math.PI;

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, IMode mode, double tval) {
            double val = GetPreValue(wave, spectrum);
            double nval = mode.Process(val, tval);
            wave.Amplitude *= nval / val; //HACK should use a separate value than amplitude
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetPreValue(Wave w, Spectrum spec) {
            return Math.Sin(TwoPi * (w.Frequency * spec.SourceTime * 0.001d + w.Phase));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetValue(Wave w, Spectrum spec) {
            return w.Amplitude * Math.Sin(TwoPi * (w.Frequency * spec.SourceTime * 0.001d + w.Phase));
        }
    }
}
