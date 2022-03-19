using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class NumberOfEnclaves
    {
        private int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        private int[][] gridClone;
        private int rowCount;
        private int colCount;
        public int NumEnclaves(int[][] grid)
        {
            this.rowCount = grid.Length;
            this.colCount = grid[0].Length;
            this.gridClone = grid;

            //Set all the land connected with boundary to 0
            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    if (r == 0 || c == 0 || r == rowCount - 1 || c == colCount - 1)
                    {
                        fillEdgeConnectedComponent(r, c);
                    }
                }
            }

            int res = 0;
            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    if (this.gridClone[r][c] == 1)
                    {
                        res++;
                        fillEdgeConnectedComponent(r, c);
                    }
                }
            }

            return res;
        }

        private void fillEdgeConnectedComponent(int row, int col)
        {
            if (row < 0 || col < 0 || row >= rowCount || col >= colCount || this.gridClone[row][col] == 0)
            {
                return;
            }

            this.gridClone[row][col] = 0;
            foreach (int[] direction in directions)
            {
                int newRow = direction[0] + row;
                int newCol = direction[1] + col;
                fillEdgeConnectedComponent(newRow, newCol);
            }
        }
    }
}
