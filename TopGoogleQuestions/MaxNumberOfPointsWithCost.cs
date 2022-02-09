using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    //1937. Maximum Number of Points with Cost
    public class MaxNumberOfPointsWithCost
    {
        public long MaxPoints(int[][] points)
        {
            int row = points.Length;
            int column = points[0].Length;

            //Store calculation from previous row
            long[] dp = new long[column];

            long[] left = new long[column];
            Array.Fill(left, 0);
            long[] right = new long[column];
            Array.Fill(right, 0);

            //Fill the dp array with first row of input points
            for (int i = 0; i < column; i++)
            {
                dp[i] = points[0][i];
            }

            //Iterate through entire points matrix to find maximum cost
            for (int r = 1; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    if (c == 0)
                        left[c] = dp[c];
                    else
                        left[c] = Math.Max(left[c-1] -1, dp[c]);
                }

                for (int c = column - 1; c >= 0; c--)
                {
                    if (c == column - 1)
                        right[c] = dp[c];
                    else
                        right[c] = Math.Max(right[c+1] - 1, dp[c]);
                }

                for (int c = 0; c < column; c++)
                {
                    dp[c] = points[r][c] + Math.Max(left[c], right[c]);
                }
            }
            return dp.Max();
        }
    }
}
