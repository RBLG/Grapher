using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Misc
{
    /// <summary>
    /// equivalent to Enumerable.Range() but without the overhead of creating a list of values
    /// and use a [start,end[ approach rather than start, length. also the name "Range" was taken, so its S for signed
    /// </summary>
    public class SRange : IEnumerable<int>
    {
        private readonly int start;
        private readonly int end;

        public SRange(int nstart, int nend) {
            start = nstart;
            end = nend;
        }

        public static SRange New(int start, int end) => new(start, end);
        public static SRange NewAsCount(int start, int count) => new(start, start + count);

        public IEnumerator<int> GetEnumerator() {
            int ind = start;
            while (ind < end) {
                yield return ind;
                ind++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            int ind = start;
            while (ind < end) {
                yield return ind;
                ind++;
            }
        }
    }
}
