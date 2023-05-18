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
        public readonly uint height;
        private uint Length { get => width_ * height; }

        public RawTable(uint nwidth, uint nheight) {
            width_ = nwidth;
            height = nheight;
            values = new double[Length];
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
            uint ohoffset = (uint)Math.Max(0, -hlen); // deletion, in the old table

            RawTable ntable = new(width_, (uint)(height + hlen));

            for (uint wit = 0; wit < width_; wit++) { //wit -> w it -> width iterator
                //copy the values before the insertion
                for (uint hit = 0; hit < hstart; hit++) {
                    ntable.values[Index(wit, hit)] = values[Index(wit, hit)];
                }
                //fill the new rows if there is
                for (uint hit2 = hstart; hit2 < nhoffset; hit2++) {
                    ntable.values[Index(wit, hit2)] = filler(wit, hit2, this);
                }
                //copy the values before the insertion, ignoring the removed rows, if there is
                for (uint hit3 = hstart; hit3 < height; hit3++) {
                    ntable.values[Index(wit, hit3 + nhoffset)] = values[Index(wit, hit3 + ohoffset)];
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
            uint owoffset = (uint)Math.Max(0, -wlen);

            RawTable ntable = new((uint)(width_ + wlen), height);

            for (uint hit = 0; hit < height; hit++) {
                //copy the values before the insertion
                for (uint wit = 0; wit < wstart; wit++) {
                    ntable.values[Index(wit, hit)] = values[Index(wit, hit)];
                }
                //fill the new rows if there is
                for (uint wit2 = wstart; wit2 < nwoffset; wit2++) {
                    ntable.values[Index(wit2, hit)] = filler(wit2, hit, this);
                }
                //copy the values before the insertion, ignoring the removed rows, if there is
                for (uint wit3 = wstart; wit3 < width_; wit3++) {
                    ntable.values[Index(wit3 + nwoffset, hit)] = values[Index(wit3 + owoffset, hit)];
                }
            }
            return ntable;
        }

        public void ForEach(Action<uint, uint> action) {
            foreach (uint itx in Enumerable.Range(0, (int)width_)) {
                foreach (uint ity in Enumerable.Range(0, (int)height)) {
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
