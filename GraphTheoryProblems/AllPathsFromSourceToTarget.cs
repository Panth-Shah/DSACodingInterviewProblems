using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class AllPathsFromSourceToTarget
    {
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            IList<IList<int>> resultPaths = new List<IList<int>>();
            List<int> currentPath = new List<int>();
            //Solution using Backtracking
            //Check boundary conditions
            if (graph.Length == 0 || graph == null)
            {
                return resultPaths;
            }
            //Start dfs from node 0 and end it at n-1 for a complete path
            //Use backtracking to find all the possible paths
            dfs(0, graph, new List<int>(), ref resultPaths);
            return resultPaths;
        }

        private void dfs(int currentNode, int[][] graph, List<int> currentPath, ref IList<IList<int>> result)
        {
            //Add current Node to current Path
            currentPath.Add(currentNode);
            //Define base case
            //Add current path when dfs reach to n-1 node
            if (currentNode == graph.Length - 1)
            {
                List<int> finalPath = new List<int>();
                finalPath.AddRange(currentPath);
                result.Add(finalPath);
                return;
            }
            //Traverse through all the connecting vertices of currentNode and find paths
            foreach (int vertex in graph[currentNode])
            {
                //Traverse through all the nodes using dfs and backtracking
                dfs(vertex, graph, currentPath, ref result);
                //When you reach to n-1 node, add path to the list
                //Remove node added at n-1 from the currentPath to start backtrakcing
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }
}
