using Grapher.GuiElement.ScaleSettings;
using Grapher.Modules;
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
    public class FrequencyInputScale : IInputScale
    {
        public double min;
        public double max;
        public double range;

        public FrequencyUnit Unit {
            get => unit;
            set {
                unit = value;
                min = Scale(Min);
                max = Scale(Max);
                range = max - min;
            }
        }

        public FrequencyUnit unit;


        public double Min { get; } = 20;
        public double Max { get; } = 20_000;

        public FrequencyInputScale() {
            Unit= FrequencyUnit.Exponantial;
        }


        public string Label => "f(Hz)";

        public bool Continuous => true;

        public bool IsLooping => false;

        public Control GetControl() => new FrequencyInputGui(this);

        public List<Graduation> GetMilestones() {
            throw new NotImplementedException();
        }

        public double PickValueTo(Wave wave, Spectrum spectrum, uint size) {
            return (Scale(wave.Frequency) - min) / range * size;
        }

        public (uint, uint, double) PickValueTo2(Wave wave, Spectrum spectrum, uint size) {
            return TableModule.PrepareInterpolation(PickValueTo(wave, spectrum, size), size, IsLooping);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Scale(double notscaled) => unit switch {
            FrequencyUnit.Exponantial /**/ => Math.Log(notscaled + 1),
            FrequencyUnit.Mei /*        */ => 2595 * Math.Log10(1 + notscaled / 700),
            FrequencyUnit.Linear /*     */ => notscaled,
            _ /*                        */ => notscaled,
        };

        public double Unscale(double scaled) => unit switch {
            FrequencyUnit.Exponantial /**/ => Math.Exp(scaled) - 1,
            FrequencyUnit.Mei /*        */ => (Math.Pow(10, scaled / 2595) - 1) * 700,
            FrequencyUnit.Linear /*     */ => scaled,
            _ /*                        */ => scaled,
        };

    }

    public enum FrequencyUnit
    {
        Linear, Exponantial, Mei
    }
}
