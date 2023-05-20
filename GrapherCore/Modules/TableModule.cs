using Grapher.Editor3d.Processing;
using Grapher.Modes;
using Grapher.Scale;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Modules
{
    public class TableModule : IModule
    {
        public IModule Input { get; set; } = new DefaultPitchModule();

        public RawTable Table { get; set; } = new(10, 20);//HACK un-hardcode size

        public IInputScale Wscale { get; set; } = new FrequencyExponantialScale();
        public IInputScale Lscale { get; set; } = new TimeLinearScale();
        public IOutputScale Hscale { get; set; } = new AmplitudeLinearScale();
        public IMode Mode { get; set; } = new SetMode();

        public TableModule() {
            //UpdateUniqueScales();
        }

        public virtual Spectrum GetSpectrum(double time, double timeoff, double bpitch, double seed) {
            Spectrum buffer = Input.GetSpectrum(time, timeoff, bpitch, seed);
            foreach (Wave w in buffer.Waves) {
                Apply2(w, buffer);
            }
            return buffer;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual UserControl? GetControl() => new Graph3DEditor(this);

        public string Name { get; set; } = "Editor " + count++;
        private static int count = 0;

        public virtual void SetInput(IModule input) { Input = input; }


        ////// PREVIOUSLY IN TABLE ///////////

        public void Apply2(Wave wave, Spectrum spectrum) {
            uint w1, w2, l1, l2;
            double wmix, lmix;
            if (Table.width_ == 1) { wmix = w1 = w2 = 0; }
            else { (w1, w2, wmix) = ((uint,uint,double))Wscale.PickValueTo2(wave, spectrum, (int)Table.width_); } //HACK

            if (Table.height == 1) { lmix = l1 = l2 = 0; }
            else { (l1, l2, lmix) = ((uint, uint, double))Lscale.PickValueTo2(wave, spectrum, (int)Table.height); }

            double tval = GetValueFromQuadIndex(w1, w2, wmix, l1, l2, lmix);
            if (!double.IsNaN(tval)) { Hscale.ProcessValue(wave, spectrum, Table.height, Mode, tval); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double GetValueFromQuadIndex(uint w1, uint w2, double wmix, uint l1, uint l2, double lmix) {
            if (w1 < 0 || Table.width_ <= w1 || l1 < 0 || Table.height <= l1 ||
                w2 < 0 || Table.width_ <= w2 || l2 < 0 || Table.height <= l2) { return double.NaN; }

            return (GetLinearInterpolatedValue(w1, w2, wmix, l1, l2, lmix) - 0) / 1;
        }

        /// <summary>
        /// does interpolation between 2 and 2 non continuous table values
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double GetLinearInterpolatedValue(uint w1, uint w2, double wmix, uint l1, uint l2, double lmix) { //TODO ADD TABLE AS PARAM
            double mwmix = 1 - wmix;
            double mlmix = 1 - lmix;

            if (w1 == w2)//avoiding unecessary table access (are those ifs faster than array access?)
            {
                if (l1 == l2) { return Table.Get(l1, w1); }
                else { return Table.Get(l1, w1) * mlmix + Table.Get(l2, w1) * lmix; }
            }
            else {
                if (l1 == l2) { return Table.Get(l1, w1) * mwmix + Table.Get(l1, w2) * wmix; }
                else {
                    double ri1 = Table.Get(l1, w1) * mlmix + Table.Get(l2, w1) * lmix;
                    double ri2 = Table.Get(l1, w2) * mlmix + Table.Get(l2, w2) * lmix;
                    return ri1 * mwmix + ri2 * wmix;
                }
            }
        }
    }
}
