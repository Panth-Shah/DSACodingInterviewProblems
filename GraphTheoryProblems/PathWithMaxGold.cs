using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class PathWithMaxGold
    {
        private int[][] gridClone;
        private int rowCount;
        private int columnCount;
        private int ans = 0;
        private int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        public int GetMaximumGold(int[][] grid)
        {
            this.gridClone = grid;
            this.rowCount = grid.Length;
            this.columnCount = grid[0].Length;
            for (int r = 0; r < this.rowCount; r++)
            {
                for (int c = 0; c < this.columnCount; c++)
                {
                    if (gridClone[r][c] != 0)
                    {
                        dfs(r, c, grid[r][c]);
                    }
                }
            }

            return ans;
        }

        private void dfs(int row, int column, int pathSum)
        {

            if (pathSum > ans)
            {
                ans = pathSum;
            }

            int temp = gridClone[row][column];
            gridClone[row][column] = 0; //Mark cell visited

            if (row > 0 && gridClone[row - 1][column] != 0)
            {
                this.dfs(row - 1, column, pathSum + gridClone[row - 1][column]);
            }
            if (row < rowCount - 1 && gridClone[row + 1][column] != 0)
            {
                this.dfs(row + 1, column, pathSum + gridClone[row + 1][column]);
            }
            if (column > 0 && gridClone[row][column - 1] != 0)
            {
                this.dfs(row, column - 1, pathSum + gridClone[row][column - 1]);
            }
            if (column < columnCount - 1 && gridClone[row][column + 1] != 0)
            {
                this.dfs(row, column + 1, pathSum + gridClone[row][column + 1]);
            }
            gridClone[row][column] = temp;
        }
    }
}
