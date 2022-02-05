using System;

namespace GraphTheoryProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = new int[][] { new int[] { 1,2 }, new int[] { 3 }, new int[] { 3 }, new int[] { } };
            //PathExistGraph pathExistGraph = new PathExistGraph();
            //pathExistGraph.ValidPath(3, input, 0, 2);

            AllPathsFromSourceToTarget allPathList = new AllPathsFromSourceToTarget();
            allPathList.AllPathsSourceTarget(input);
        }
    }
}
