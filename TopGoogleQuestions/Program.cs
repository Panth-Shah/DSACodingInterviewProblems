using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            //SnapShotArray snap = new SnapShotArray(4);
            //MaxNumberOfPointsWithCost maxCostDP = new MaxNumberOfPointsWithCost();
            //maxCostDP.MaxPoints(new int[][] { new int[] { 1, 2, 3}, new int[] { 1, 5, 1}, new int[] { 3, 1, 1}  });

            //FindOriginalArrayFromDoubledArray orginalFromDoubledArray = new FindOriginalArrayFromDoubledArray();
            //orginalFromDoubledArray.FindOriginalArray(new int[] { 1, 3, 4, 2, 6, 8});

            //DecodeStrings decode = new DecodeStrings();
            //decode.DecodeString("3[ab2[cd4[a]]]");

            //NumberOfMatchingSubsequences numberMatchingSub = new NumberOfMatchingSubsequences();
            //numberMatchingSub.NumMatchingSubseqModified("abcde", new string[] { "a", "bb", "acd", "ace" });

            NonOverlappingIntervals interval = new NonOverlappingIntervals();
            var ans = interval.EraseOverlapIntervals(new int[][] { new int[] { 1, 11}, new int[] { 2, 22 }, new int[] { 11, 22 }, new int[] { 1, 100 } });
        }
    }
}
