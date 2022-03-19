using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class NumberOfIslands
    {
        private int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        public int NumIslands(char[][] grid)
        {
            int result = 0;

            if (grid == null || grid.Length == 0)
            {
                return result;
            }

            for (int row = 0; row < grid.Length; row++)
            {
                for (int column = 0; column < grid[row].Length; column++)
                {
                    if (grid[row][column] == '1')
                    {
                        result += 1;
                        IslandSearch(grid, row, column);
                    }
                }
            }

            return result;
        }

        private void IslandSearch(char[][] grid, int r, int c)
        {
            if (r < 0 || c < 0 || r >= grid.Length || c >= grid[r].Length || grid[r][c] == '0')
            {
                return;
            }

            grid[r][c] = '0'; // Mark grid element visited
            foreach (int[] direction in directions)
            {
                int rowOffset = direction[0];
                int columnOffset = direction[1];
                this.IslandSearch(grid, r + rowOffset, c + columnOffset);
            }
        }

        public int NumIslandsBFS(char[][] grid)
        {
            int row = grid.Length;
            int column = grid[0].Length;
            int num_islands = 0;

            Queue<(int, int)> neighbours = new Queue<(int, int)>();

            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        ++num_islands;
                        neighbours.Enqueue(new (r, c));
                        while (neighbours.Count > 0)
                        {
                            (int, int) currentCell = neighbours.Dequeue();
                            int currRow = currentCell.Item1;
                            int currColumn = currentCell.Item2;
                            if (currRow < 0 || currColumn < 0 || currRow >= row || currColumn >= column || grid[currRow][currColumn] == '0')
                            {
                                continue;
                            }
                            grid[currRow][currColumn] = '0';

                            foreach (int[] direction in directions)
                            {
                                int rowOffset = direction[0];
                                int columnOffset = direction[1];
                                neighbours.Enqueue(new (currRow + rowOffset, currColumn + columnOffset ));
                            }
                        }
                    }
                }
            }

            return num_islands;
        }
    }
}
