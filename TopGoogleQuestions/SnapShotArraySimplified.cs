using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace TopGoogleQuestions
{
    public class SnapShotArraySimplified
    {
        /// <summary>
        ///     At any given index, what all values are set during which snapshot
        ///     This solution tracks down the history of each index
        /// </summary>

        public List<int[]>[] h;
        public int snapId = 0;
        public SnapShotArraySimplified(int length)
        {
            h = new List<int[]>[length];
            for (int i = 0; i < length; i++)
            {
                h[i] = new List<int[]>();
                // add an initial [snap_id, val] pair, very important
                h[i].Add(new int[] { -1, 0 });
            }
        }

        public void Set(int index, int val)
        {
            h[index].Add(new int[] { snapId, val });
        }

        public int Snap()
        {
            return snapId++;
        }

        public int Get(int index, int snap_id)
        {
            List<int[]> temp = h[index];
            int l = 0, r = temp.Count - 1;
            // binary search rightmost
            while (l < r)
            {
                int m = r - (r - l) / 2;
                if (temp[m][0] <= snap_id) l = m;
                else r = m - 1;
            }
            return temp[l][1];
        }
    }
}
