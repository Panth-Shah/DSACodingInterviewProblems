using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class PathExistGraph
    {
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            List<List<int>> graph = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }
            //Build a bidiractional graph 
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            Stack<int> stackTrace = new Stack<int>();
            bool[] seen = new bool[n];
            Array.Fill(seen, true);
            //Add start into stack to start traversing
            stackTrace.Push(source);
            while (stackTrace.Count() > 0)
            {
                int node = stackTrace.Pop();
                //Check if node if the destination node
                if (node == destination)
                    return true;
                if (seen[node])
                    continue;
                seen[node] = true;
                //Add all the adjecent vertices to stack for traversal from current node
                var adjacentVerices = graph[node];
                foreach (int vertex in adjacentVerices)
                {
                    stackTrace.Push(vertex);
                }
            }
            return false;
        }
    }
}
