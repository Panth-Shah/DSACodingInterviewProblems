using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    //Time: O(m*n)
    //Space: O(m*n)
    //Idea is to keep ball rolling until it reaches to a wall and not to destination.
    //This problem will give true if destination is adjacent to walls and ball can stop at the wall
    //If ball can pass through the destination and hit the wall after passing, result will be false
    public class TheMaze
    {
        private int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

        public bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            //DFS + cache
            int rows = maze.Length;
            int cols = maze[0].Length;
            bool[,] visited = new bool[rows, cols];

            return dfs(maze, start, destination, visited, rows, cols);
        }

        private bool dfs(int[][] maze, int[] start, int[] des, bool[,] visited, int rows, int cols)
        {
            if (visited[start[0], start[1]])
            {
                return false;
            }
            if (start[0] == des[0] && start[1] == des[1])
            {
                return true;
            }

            visited[start[0], start[1]] = true;

            foreach (int[] direction in directions)
            {
                int dx = start[0];
                int dy = start[1];
                while (dx + direction[0] >= 0 && dx + direction[0] < rows
                       && dy + direction[1] >= 0 && dy + direction[1] < cols
                       && maze[dx + direction[0]][dy + direction[1]] != 1)
                {
                    dx += direction[0];
                    dy += direction[1];
                }
                if (dfs(maze, new int[] { dx, dy }, des, visited, rows, cols))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
