using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class SmallestDivisor
    {
        public int SmallestDivisorValue(int[] nums, int threshold)
        {
            int lo = 1;
            int hi = getMaxNums(nums);
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (isThresholdMet(nums, mid, threshold))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }
            return lo;
        }

        private bool isThresholdMet(int[] numsArr, int mid, int th)
        {
            int numsSum = 0;
            foreach (int num in numsArr)
            {
                numsSum += (int)Math.Ceiling((double)num / mid);
            }

            return numsSum <= th;
        }

        private int getMaxNums(int[] numsArr)
        {
            int max = int.MinValue;
            foreach (int val in numsArr)
            {
                max = Math.Max(max, val);
            }
            return max;
        }
    }
}
