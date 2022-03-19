using System;
using System.Collections.Generic;

namespace GraphTheoryProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[][] input = new int[][] { new int[] { 0,1 }, new int[] { 0,3 }, new int[] { 1,2 }, new int[] {2,1} };
            //PathExistGraph pathExistGraph = new PathExistGraph();
            //pathExistGraph.ValidPath(3, input, 0, 2);

            //AllPathsFromSourceToTarget allPathList = new AllPathsFromSourceToTarget();
            //allPathList.AllPathsSourceTarget(input);

            //AllPathsFromSourceToDest sourceDest = new AllPathsFromSourceToDest();
            //sourceDest.LeadsToDestination(4, input, 0, 3);

            //NumberOfProvinces np = new NumberOfProvinces();
            //np.FindCircleNum(new int[][] { new int[] { 1, 1, 0 }, new int[] { 1, 1, 0 }, new int[] { 0, 0, 1 } });

            //BinaryTreeVerticalOrderTraversal btVerticalOrderTraversal = new BinaryTreeVerticalOrderTraversal();
            //btVerticalOrderTraversal.VerticalOrder(new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))));

            //NumberOfIslands ns = new NumberOfIslands();
            //ns.NumIslands(new char[][] { new char[] { '1', '1', '1', '1', '0' }, new char[] { '1', '1', '0', '1', '0' }, new char[] { '1', '1', '0', '0', '0' }, new char[] { '0', '0', '0', '0', '0' } });

            //int[][] input = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 1 }, new int[] { 1, 5 }};
            //RedundentConnectionDFS rch = new RedundentConnectionDFS();
            //var res = rch.FindRedundantDirectedConnection(input);

            //AllPossibleRecipes recipes = new AllPossibleRecipes();
            //IList<IList<string>> ingredients = new List<IList<string>>();
            //IList<string> ingredient = new List<string>();
            //ingredient.Add("yeast");
            //ingredient.Add("flour");
            //ingredients.Add(ingredient);
            ////ingredients.Add(new List<string>() { "bread", "meat"});
            ////ingredients.Add(new List<string>() { "sandwich", "meat", "bread" });
            ////recipes.FindAllRecipes(new string[] {"bread", "sandwich", "burger"}, ingredients, new string[]{"yeast", "flour", "meat" });
            //recipes.FindAllRecipes(new string[] { "bread" }, ingredients, new string[] { "yeast"});

            //int[][] input = new int[][] { new int[] { 0, 1 }, new int[] { 0, 3 }, new int[] { 1, 2 }, new int[] { 1, 3 }};
            //MaximalNetworkRank maxRank = new MaximalNetworkRank();
            //maxRank.MaximalNetworkRankGraph(4, input);

            NumberOfIsland2 numIsland2 = new NumberOfIsland2();
            numIsland2.NumIslands2(3, 3, new int[][] { new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 1 } });
        }
    }
}
