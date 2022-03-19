using System;

namespace LeetCode.CodingPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            DijkstraAlgorithm djAlgo = new DijkstraAlgorithm();
            djAlgo.NetworkDelayTime(new int[][] { new int[] { 1, 2, 1 } }, 2, 2);
        }
    }
}
