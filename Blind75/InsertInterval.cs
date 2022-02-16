using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind75
{
    public class InsertInterval
    {
        //Key Idea:
        //    Key idea here is if newInterval is overlapping or non-overlapping
        //    If new Interval is non-overlapping, add it into result array
        //    If new interval is overlapping:
        //        Construct new interval by taking start and end points of exisitng interval and new interval
        #region With Greedy apprach
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if ((intervals?.Length ?? 0) == 0)
            {
                return new int[][] { newInterval };
            }

            int start = 0;
            int end = 1;
            List<int[]> result = new List<int[]>();

            //Iterate through entire intervals array to perform merge operation
            foreach (int[] interval in intervals)
            {
                //Check if new interval is before current interval in range
                if (newInterval[end] < interval[start])
                {
                    //Add new interval into results array
                    result.Add(newInterval);
                    //Make current interval as new interval
                    newInterval = interval;
                }else if (newInterval[start] > interval[end])
                {
                    //Check if new interval is after current interval
                    //Add current interval into results
                    //Keep new interval as it is
                    result.Add(interval);
                }
                else
                {
                    //If new interval is overlapping to current interval
                    //Merge current interval with new interval by expanding start and end interval range
                    //Keep merging intervals until new intervals is either before current interval or after
                    newInterval[start] = Math.Min(newInterval[start], interval[start]);
                    newInterval[end] = Math.Max(newInterval[end], interval[end]);
                }
            }

            result.Add(newInterval);
            return result.ToArray();
        }
        #endregion

        #region With Binary Search
        public int[][] InsertBinarySearch(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0)
            {
                return new int[][] { newInterval };
            }

            int min = findMin(intervals, newInterval); // idx of the earlies interval which intersects with a new one
            int max = findMax(intervals, newInterval); // idx of the latest interval which intersects with a new one

            if (min == max)
            {
                intervals[min] = new int[] { Math.Min(intervals[min][0], newInterval[0]), Math.Max(intervals[min][1], newInterval[1]) };
                return intervals;
            }

            int[][] newIntervals = new int[intervals.Length - (max - min)][];

            // copy all intervals < newInterval
            for (int i = 0; i < min; i++)
            {
                newIntervals[i] = intervals[i];
            }

            // copy all intervals > newInterval
            for (int i = intervals.Length - 1; i > max; i--)
            {
                newIntervals[i - (max - min)] = intervals[i];
            }

            // insert interval
            if (max < min)
            { // couldn't find intersecting intervals, just append
                newIntervals[min] = newInterval;
            }
            else
            {
                newIntervals[min] = new int[] { Math.Min(intervals[min][0], newInterval[0]), Math.Max(intervals[max][1], newInterval[1]) };
            }

            return newIntervals;
        }

        private static int findMin(int[][] intervals, int[] interval)
        {
            int idx = -1;
            int lo = 0;
            int hi = intervals.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int[] midInt = intervals[mid];
                //Check if middle interval overlap with newInterval
                if (intersects(midInt, interval))
                {
                    idx = mid;
                    hi = mid - 1;
                }
                //If new interval is after middle interval
                else if (interval[0] > midInt[1])
                {
                    lo = mid + 1;
                }
                //If new interval is before middle interval
                else
                {
                    hi = mid - 1;
                }
            }
            return idx == -1 ? lo : idx;
        }

        private static int findMax(int[][] intervals, int[] interval)
        {
            int idx = -1;
            int lo = 0;
            int hi = intervals.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int[] midInt = intervals[mid];
                //Check if middle interval intersect with newInterval
                if (intersects(midInt, interval))
                {
                    idx = mid;
                    lo = mid + 1;
                }
                else if (interval[0] > midInt[1])
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            return idx == -1 ? hi : idx;
        }

        private static bool intersects(int[] left, int[] right)
        {
            return left[0] <= right[1] && left[1] >= right[0];
        }
        #endregion
    }
}
