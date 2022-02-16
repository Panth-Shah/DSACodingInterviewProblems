using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind75
{
    public class MaxProductSubarray
    {
        public int MaxProduct(int[] nums)
        {
            //Using DP to solve this problem
            //At each state in nuns array, there are three possibilities for nums[i]
            //Scenario 1: nums[i] = +ve number
            //Scenario 2: nums[i] = 0
            //Scenario 3: nums[i] = -ve number
            //For each nums[i], we maintain max_so_far and min_so_far
            if (nums.Length == 0)
            {
                return 0;
            }

            int max_so_far = nums[0];
            int min_so_far = nums[0];
            int result = max_so_far;

            //Iterate through each value in nums
            //Start iterating from second element in nums
            for (int i = 1; i < nums.Length; i++)
            {
                //Capture current value
                int current = nums[i];
                //Calculate max product till current state
                int temp = Math.Max(current, Math.Max(max_so_far * current, min_so_far * current));

                //Calculate min product till current state
                //Here, make sure to not use max_so_far calculated for current state and so store that in temp variable until min_so_far is not calculated for current state
                min_so_far = Math.Min(current, Math.Min(max_so_far * current, min_so_far * current));

                max_so_far = temp;

                result = Math.Max(max_so_far, result);
            }

            return result;
        }
    }
}
