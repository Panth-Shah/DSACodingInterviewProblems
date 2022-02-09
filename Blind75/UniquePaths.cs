using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind75
{
    public class UniquePaths
    {
        public int FindUniquePaths(int m, int n)
        {
            //Define Data structure to store the state transition information
            //Here there are only two states, m and n
            int rowVal = m, columnVal = n;
            int[,] dp = new int[m,n];

            //Fill the entire DP array with 1 as each cell in DP matrix itself is a possible unique path
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dp[i, j] = 1;
                }
            }
            //First row and first column will only have one path as robot can move either right or down
            //Start traversing from dp[1][1]
            for (int row = 1; row < m; row++)
            {
                for (int col = 1; col < n; col++)
                {
                    //At current state for row and col, dp[row][column] will hold maximum possible paths until this point
                    //Robot can move to right or down at once and to find total possible paths to reach to dp[m-1][n-1]
                    //we need to move one down and one right each time
                    dp[row,col] = dp[row - 1,col] + dp[row,col - 1];
                }
            }

            return dp[m - 1,n - 1];
        }
    }
}
