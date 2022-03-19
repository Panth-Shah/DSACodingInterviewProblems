using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class NumberOfClosedIslands
    {
        private int rowCount;
        private int colCount;
        private int[][] gridClone;
        private int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        public int ClosedIsland(int[][] grid)
        {
            //Fill all the components connected to the edge as according to definition, closed island is an island totally surrounded by 1s.
            this.rowCount = grid.Length;
            this.colCount = grid[0].Length;
            this.gridClone = grid;
            for (int r = 0; r < this.rowCount; r++)
            {
                for (int c = 0; c < this.colCount; c++)
                {
                    if (r == 0 || c == 0 || r == rowCount - 1 || c == colCount - 1)
                    {
                        fillEdgeConnectedComponents(r, c);
                    }
                }
            }

            int res = 0;
            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < colCount; c++)
                {
                    if (gridClone[r][c] == 0)
                    {
                        res++;
                        fillEdgeConnectedComponents(r, c);
                    }
                }
            }

            return res;
        }

        private void fillEdgeConnectedComponents(int row, int col)
        {
            if (row < 0 || col < 0 || row >= rowCount || col >= colCount
              || gridClone[row][col] == 1)
            {
                return;
            }

            gridClone[row][col] = 1;
            foreach (int[] direction in directions)
            {
                int newRow = direction[0] + row;
                int newCol = direction[1] + col;
                fillEdgeConnectedComponents(newRow, newCol);
            }
        }
    }
}
