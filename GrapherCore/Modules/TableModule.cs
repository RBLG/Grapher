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
        public const double MIN = 0;
        public const double MAX = 1;

        public IModule Input { get; set; } = new DefaultPitchModule();

        public RawTable Table { get; set; } = new(10, 20);//HACK un-hardcode size

        public IInputScale Wscale { get; set; } = new FrequencyInputScale();
        public IInputScale Lscale { get; set; } = new TimeLinearScale();
        public IOutputScale Hscale { get; set; } = new AmplitudeLinearScale();
        public IMode Mode { get; set; } = new SetMode();

        public TableModule() {
            //UpdateUniqueScales();
        }

        public virtual Spectrum GetSpectrum(double time, double timeoff, double bpitch, double seed) {
            Spectrum buffer = Input.GetSpectrum(time, timeoff, bpitch, seed);
            foreach (Wave w in buffer.Waves) {
                Apply(w, buffer);
            }
            return buffer;
        }

        public virtual UserControl? GetControl() => new Graph3DEditor(this);

        public string Name { get; set; } = "Editor " + count++;
        private static int count = 0;

        public virtual void SetInput(IModule input) { Input = input; }


        ////// PREVIOUSLY IN TABLE ///////////

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Apply(Wave wave, Spectrum spectrum) {
            RawTable table = Table;
            uint w1, w2, l1, l2;
            double wmix, lmix;
            if (table.width_ == 1) { wmix = w1 = w2 = 0; }
            else { (w1, w2, wmix) = Wscale.PickValueTo2(wave, spectrum, table.width_); }

            if (table.height == 1) { lmix = l1 = l2 = 0; }
            else { (l1, l2, lmix) = Lscale.PickValueTo2(wave, spectrum, table.height); }

            if (double.IsNaN(lmix) || double.IsNaN(lmix)) {
                Console.WriteLine("aaaaaaaaaaaaaaaah");
            }

            double tval = GetValueFromQuadIndex(w1, w2, wmix, l1, l2, lmix, table);
            if (!double.IsNaN(tval)) { Hscale.ProcessValue(wave, spectrum, table.height, Mode, tval); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetValueFromQuadIndex(uint w1, uint w2, double wmix, uint l1, uint l2, double lmix, RawTable table) {
            if (IsOOB(w1, table.width_) || IsOOB(w2, table.width_) ||
                IsOOB(l1, table.height) || IsOOB(l2, table.height)) {
                return double.NaN;
            }
            return (GetLinearInterpolatedValue(w1, w2, wmix, l1, l2, lmix, table) - MIN) / MAX;
        }

        /// <summary>
        /// does interpolation between 2 and 2 non continuous table values
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double GetLinearInterpolatedValue(uint w1, uint w2, double wmix, uint l1, uint l2, double lmix, RawTable table) {
            double mwmix = 1 - wmix;
            double mlmix = 1 - lmix;

            if (w1 == w2)//avoiding unecessary table access (are those ifs faster than array access?)
            {
                if (l1 == l2) { return table[w1, l1]; }
                else { return table[w1, l1] * mlmix + table[w1, l2] * lmix; }
            }
            else {
                if (l1 == l2) { return table[w1, l1] * mwmix + table[w2, l1] * wmix; }
                else {
                    double ri1 = table[w1, l1] * mwmix + table[w2, l1] * wmix;
                    double ri2 = table[w1, l2] * mwmix + table[w2, l2] * wmix;
                    return ri1 * mlmix + ri2 * lmix;
                }
            }
        }

        /// <summary>
        /// helper function for interpolation between two values next to each other
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (uint, uint, double) PrepareInterpolation(double val, uint size, bool islooping) {
            //i1 and i2 are the two index to interpolate between, mix is where between both the value is
            double dsize = size;
            val = ((val % dsize) + dsize) % dsize; //modulo that always return a positive value
            uint i1 = (uint)val; //previous index by truncating val
            uint i2 = (val == i1) ? i1 : i1 + 1; //faster (int)Math.Ceiling(index2); //next by +1
            if (i2 >= size) {
                i2 = islooping ? 0 : i1;
            }
            double mix = val - i1;//% 1;//also faster %1

            return (i1, i2, mix);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOOB(uint val, uint min, uint max) {
            return val < min || max <= val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOOB(uint val, uint max) {
            return max <= val;
        }
    }
}
