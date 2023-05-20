using Grapher.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Editor3d.Processing
{
    public class RawTable
    {
        private readonly double[] values;
        public readonly uint width_; //_ for pretty code formatting
        private readonly URange wrange;
        public readonly uint height;
        private readonly URange hrange;
        private uint Length { get => width_ * height; }

        public RawTable(uint nwidth, uint nheight) {
            width_ = nwidth;
            wrange = new URange(0, width_);
            height = nheight;
            hrange = new URange(0, height);
            values = new double[Length];
            Array.Fill(values, 0.5d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint Index(uint wi, uint hi) {
            return wi + hi * width_;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Get(uint wi, uint hi) {
            return values[Index(wi, hi)];
        }

        public void Set(uint wi, uint hi, double value) {
            values[Index(wi, hi)] = Math.Clamp(value, 0d, 1d);
        }

        public double this[uint wi, uint hi] {
            get => Get(wi, hi);
            set => Set(wi, hi, value);
        }

        public RawTable CloneAndRIRows(uint hstart, int hlen) {
            return CloneAndRIRows(hstart, hlen, (wit, hit, table) => 0);
        }

        /// <summary>
        /// clone this table but add or remove hlen amount of new rows before.
        /// use filler if adding to fill the new values
        /// </summary>
        /// <returns></returns>
        public RawTable CloneAndRIRows(uint hstart, int hlen, Func<uint, uint, RawTable, double> filler) {
            //keep start value in array range
            hstart = Math.Min(hstart, height);

            //prevent hlen from removing more than what would leave 1 row
            hlen = Math.Max(hlen, -(int)(height - hstart + 1));

            //height index (minus hstart) after:
            uint nhoffset = (uint)Math.Max(0, hlen); // insertion, in the new table
            uint offset = (uint)Math.Abs(hlen);

            uint hend = hstart + nhoffset;
            uint nheight = (uint)(height + hlen);
            RawTable ntable = new(width_, nheight);

            var hcopy1range = URange.New(0, hstart);
            var hblankrange = URange.New(hstart, hend);
            var hcopy2range = URange.New(hend, nheight);

            foreach (uint wit in wrange) {
                //copy the values before the insertion
                foreach (uint hit in hcopy1range) {
                    ntable[wit, hit] = this[wit, hit];
                }
                //fill the new rows if there is
                foreach (uint hit2 in hblankrange) {
                    ntable[wit, hit2] = filler(wit, hit2, this);
                }
                //copy the values before the insertion, ignoring the removed rows, if there is
                foreach (uint hit3 in hcopy2range) {
                    ntable[wit, hit3] = this[wit, hit3 - offset];
                }
            }
            return ntable;
        }

        public RawTable CloneAndRIColumns(uint wstart, int wlen) {
            return CloneAndRIColumns(wstart, wlen, (wit, hit, table) => 0);
        }

        public RawTable CloneAndRIColumns(uint wstart, int wlen, Func<uint, uint, RawTable, double> filler) {
            wstart = Math.Min(wstart, width_);
            wlen = Math.Max(wlen, -(int)(width_ - wstart + 1));
            uint nwoffset = (uint)Math.Max(0, wlen);
            uint offset = (uint)Math.Abs(wlen);

            uint wend = wstart + nwoffset;
            uint nwidth = (uint)(width_ + wlen);
            RawTable ntable = new(nwidth, height);

            var wcopy1range = URange.New(0, wstart);
            var wblankrange = URange.New(wstart, wend);
            var wcopy2range = URange.New(wend, nwidth);

            foreach (uint hit in hrange) {
                //copy the values before the insertion
                foreach (uint wit in wcopy1range) {
                    ntable[wit, hit] = this[wit, hit];
                }
                //fill the new rows if there is
                foreach (uint wit2 in wblankrange) {
                    ntable[wit2, hit] = filler(wit2, hit, this);
                }
                //copy the values before the insertion, ignoring the removed rows, if there is
                foreach (uint wit3 in wcopy2range) {
                    ntable[wit3, hit] = this[wit3 - offset, hit];
                }
            }
            return ntable;
        }

        public void ForEach(Action<uint, uint> action) {
            foreach (uint itx in wrange) {
                foreach (uint ity in hrange) {
                    action(itx, ity);
                }
            }
        }

        public double[,] CopyToArray() {
            double[,] narray = new double[width_, height];
            ForEach((itx, ity) => {
                narray[itx, ity] = Get(itx, ity);
            });
            return narray;
        }

    }


}
