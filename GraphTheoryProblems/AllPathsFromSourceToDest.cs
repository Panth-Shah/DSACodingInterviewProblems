using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class AllPathsFromSourceToDest
    {
        //Identify BackEdge: BACK EDGE: We assign pre-visit and post-visit numbers to each node starting from 1.
        //Pre-visit numbers are assigned as soon as the node is visited while post-visit numbers are assigned after visiting all the children.
        //For Example, in a simple graph A -> B -> C, the order of assignment will be A.pre = 1 -> B.pre = 2 -> C.pre = 3 -> C.post = 4 -> B.post = 5 -> A.post = 6.
        //So, for any node being currently processed, the pre-visit numbers of all its ancestors are non-zero values while their post-visit numbers have not been assigned yet. Therefore, any child of the current node "i" with pre[child]!=0 && post[child] == 0 must be a back edge.
        //If you are wondering about children with non-zero pre AND post visit numbers, they form cross edges with node "i" which will lead us to the destination.So, no need to exclude them.
        private List<int>[] graph = null;
        private int[] pre;
        private int[] post;
        private int count;
        public bool LeadsToDestination(int n, int[][] edges, int source, int destination)
        {
            graph = new List<int>[n];
            pre = new int[n];
            post = new int[n];
            count = 1;
            //Build graph using Adjacency List
            buildGraph(n, edges);
            //Perform DFS on graph
            return graphTraversal(graph, source, destination);
        }
        private bool graphTraversal(List<int>[] graph, int node, int destination)
        {
            
            //Previsit number set to the count
            pre[node] = count++;
            //Leaf Node?? Then it must be the destination. Assign postvisit and return i==dest 
            if (graph[node].Count == 0)
            {
                post[node] = count++;
                return node == destination;
            }

            //Traverse through each adjacent vertex from current node
            foreach(int v in graph[node])
            {
                //Checking for self loops
                if (node == v) return false;
                //Checking for back edges
                if (pre[v] != 0 && post[v] == 0)
                {
                    return false;
                }

                //Run dfs on the child
                if (!graphTraversal(graph, v, destination))
                {
                    return false;
                }
            }
            //Assign post and return true as default if no false scenarios
            post[node] = count++;
            return true;
        }
        private void buildGraph(int n, int[][] graphEdges)
        {
            //Initialize List of adjacent nodes at each index
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (int[] edge in graphEdges)
            {
                graph[edge[0]].Add(edge[1]);
            }
        }
    }
}
