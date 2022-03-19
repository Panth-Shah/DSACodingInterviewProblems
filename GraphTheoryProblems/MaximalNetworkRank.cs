using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class MaximalNetworkRank
    {
        public int MaximalNetworkRankGraph(int n, int[][] roads)
        {
            int[,] nodeConnectivityMatrix = new int[n, n];
            int maxPath = 0;
            int col = 0;
            int internalMaxPath = 0;
            foreach (int[] road in roads)
            {
                nodeConnectivityMatrix[road[0], road[1]] = 1;
                nodeConnectivityMatrix[road[1], road[0]] = 1;
            }

            for (int r = 0; r < n - 1; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    internalMaxPath += nodeConnectivityMatrix[r, c];
                    internalMaxPath += nodeConnectivityMatrix[r + 1, c];
                }
                maxPath = Math.Max(maxPath, internalMaxPath - 1);
            }
            return maxPath;
        }
    }
}
