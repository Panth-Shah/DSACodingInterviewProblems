using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class NonOverlappingIntervals
    {
        public int EraseOverlapIntervals(int[][] intervals)
        {
            //validate input
            if (intervals.Length == 0)
            {
                return 0;
            }
            //Sort array by end time
            Array.Sort(intervals, (a, b) => a[0] - b[0]);
            int count = 1;
            int prev = 0;
            //Start date of current interval should be more than end date of previous interval
            for (int i = 1; i < intervals.Length; i++)
            {
                //If end time of previous interval is more than start time of current interval
                if (intervals[prev][1] > intervals[i][0])
                {
                    //Mark current interval as overlapping
                    count++;
                    //If end time of previous interval is more than end time of current interval
                    //Current interval completely overals previous interval; consider current interval as valid interval
                    //This is so that we can accomodate more intervals
                    if (intervals[prev][1] > intervals[i][1]) prev = i;
                }
                else prev = i;
            }
            return count;
        }
    }
}
