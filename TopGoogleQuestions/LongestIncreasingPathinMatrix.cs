using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class LongestIncreasingPathinMatrix
    {
        //329. Longest Increasing Path in a Matrix

        private int[][] directions = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, -1 } };
        private int row, column;
        public int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix.Length == 0)
            {
                return 0;
            }
            row = matrix.Length;
            column = matrix[0].Length;

            int[,] cache = new int[row, column];

            int ans = 0;

            //Iterate through each cell in the matrix and check if current node can become a start node of longest increasing path
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    ans = Math.Max(ans, dfs(matrix, i, j, cache));
                }
            }

            return ans;
        }

        private int dfs(int[][] matrix, int r, int c, int[,] cache)
        {
            //If value found in cahce
            if (cache[r, c] != 0)
            {
                return cache[r, c];
            }
            foreach (int[] direction in directions)
            {
                int x = r + direction[0];
                int y = c + direction[1];
                if (x >= 0 && x < row && y >= 0 && y < column && matrix[x][y] > matrix[r][c])
                {
                    cache[r, c] = Math.Max(cache[r, c], dfs(matrix, x, y, cache));
                }
            }
            return ++cache[r, c];
        }
    }
}
