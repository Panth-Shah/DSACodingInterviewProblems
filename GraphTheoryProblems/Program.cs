using System;

namespace GraphTheoryProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = new int[][] { new int[] { 0,1 }, new int[] { 0,3 }, new int[] { 1,2 }, new int[] {2,1} };
            //PathExistGraph pathExistGraph = new PathExistGraph();
            //pathExistGraph.ValidPath(3, input, 0, 2);

            //AllPathsFromSourceToTarget allPathList = new AllPathsFromSourceToTarget();
            //allPathList.AllPathsSourceTarget(input);

            //AllPathsFromSourceToDest sourceDest = new AllPathsFromSourceToDest();
            //sourceDest.LeadsToDestination(4, input, 0, 3);

            //NumberOfProvinces np = new NumberOfProvinces();
            //np.FindCircleNum(new int[][] { new int[] { 1, 1, 0 }, new int[] { 1, 1, 0 }, new int[] { 0, 0, 1 } });

            BinaryTreeVerticalOrderTraversal btVerticalOrderTraversal = new BinaryTreeVerticalOrderTraversal();
            btVerticalOrderTraversal.VerticalOrder(new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))));
        }
    }
}
