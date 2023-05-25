using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Misc
{
    /// <summary>
    /// similar to SRange but compatible with uint
    /// </summary>
    public class URange : IEnumerable<uint>
    {
        private readonly uint start;
        private readonly uint end;

        public URange(uint nstart, uint nend) {
            start = nstart;
            end = nend;
        }

        public IEnumerable<int> AsInt() {
            return SRange.New((int)start, (int)end);
        }

        public static URange New(uint start, uint end) => new(start, end);
        public static URange NewAsCount(uint start, uint count) => new(start, start + count);

        public IEnumerator<uint> GetEnumerator() {
            uint ind = start;
            while (ind < end) {
                yield return ind;
                ind++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            uint ind = start;
            while (ind < end) {
                yield return ind;
                ind++;
            }
        }
    }
}
