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
            MaxNumberOfPointsWithCost maxCostDP = new MaxNumberOfPointsWithCost();
            maxCostDP.MaxPoints(new int[][] { new int[] { 1, 2, 3}, new int[] { 1, 5, 1}, new int[] { 3, 1, 1}  });
        }
    }
}
