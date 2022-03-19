using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    //Not Working Solution with DFS
    public class RedundentConnectionHard
    {
        private int[] isProcessed;
        private Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        private Dictionary<int, int> incomingEdgeMap = new Dictionary<int, int>();
        private List<int[]> edgesToKeep; 
        private bool isCycle;
        private int[] edgeToRemove;
        private int[] edgeFormCycle = new int[2];
        private int nodeWithTwoIncomingEdges = -1;
        public int[] FindRedundantDirectedConnection(int[][] edges)
        {
            //Idea here is to find edge which forms cycle
            this.isProcessed = new int[edges.Length + 1];
            this.isCycle = false;
            this.edgesToKeep = new List<int[]>();
            //Initialize isProcssed array with all the nodes set to not processed
            //Node state:
            //-1: Node not processed
            //0: Node currently processing
            //1: Node node processed
            Array.Fill(isProcessed, -1);

            int source = -1;
            int target = -1;
            //Build graph with Adjacency List
            foreach (int[] edge in edges)
            {
                source = edge[0];
                target = edge[1];
                incomingEdgeMap.TryAdd(target, 0);
                incomingEdgeMap[target] += 1;
                if (incomingEdgeMap[target] == 2)
                {
                    this.edgeToRemove = edge;
                    nodeWithTwoIncomingEdges = target;
                }
                else
                {
                    this.edgesToKeep.Add(edge);
                }
            }

            foreach (int[] newEdges in edgesToKeep)
            {
                source = newEdges[0];
                target = newEdges[1];
                graph.TryAdd(source, new List<int>());
                graph[source].Add(target);
            }

            //Condition 1: find node with 2 parents
            //Condition 2: Check if cycle exists
            //Perform DFS only to nodes which are not processed

            if (nodeWithTwoIncomingEdges == -1)
            {
                this.dfs(edgesToKeep[0][0]);
            }
            else
            {
                this.dfs(nodeWithTwoIncomingEdges);
            }


            if (isCycle)
            {
                return edgeFormCycle;
            }
            else
            {
                return edgeToRemove;
            }
        }

        private void dfs(int currentNodeIndex)
        {
            if (this.isCycle)
            {
                return;
            }

            //Start processing currentNode and so update the state of current node
            this.isProcessed[currentNodeIndex] = 0;

            //traverse through each neighbouring node in the graph from current index and perform DFS until you find a cycle
            if (graph.ContainsKey(currentNodeIndex))
            {
                foreach (int neighbour in graph[currentNodeIndex])
                {
                    if (this.isProcessed[neighbour] == -1)
                    {
                        this.dfs(neighbour);
                    }
                    else if (isProcessed[neighbour] == 0)
                    {
                        this.isCycle = true;
                        this.edgeFormCycle[0] = currentNodeIndex;
                        this.edgeFormCycle[1] = neighbour;
                    }
                }
            }

            this.isProcessed[currentNodeIndex] = 1;
        }
    }

    public class RedundentConnectionDFS
    {
        //Map number of child for each parent
        private Dictionary<int, List<int>> childParentGraph = new Dictionary<int, List<int>>();
        //Key number of parents for each child
        private Dictionary<int, List<int>> parentChildGraph = new Dictionary<int, List<int>>();
        private int[] isProcessed;
        private int nodeWithTwoIncomingEdges = -1;
        private int[] edgeFormCycle = new int[2];

        public int[] FindRedundantDirectedConnection(int[][] edges)
        {
            int nodes = edges.Length;
            this.isProcessed = new int[edges.Length + 1];
            Array.Fill(isProcessed, -1);
            //Condition 1: Find node with two parents
            foreach (int[] edge in edges)
            {
                int source = edge[0];
                int target = edge[1];
                childParentGraph.TryAdd(source, new List<int>());
                parentChildGraph.TryAdd(target, new List<int>());

                childParentGraph[source].Add(target);
                parentChildGraph[target].Add(source);
                if (parentChildGraph[target].Count == 2)
                {
                    nodeWithTwoIncomingEdges = target;
                }
            }

            //If child with 2 parent is present
            if (nodeWithTwoIncomingEdges != -1)
            {
                this.isProcessed[parentChildGraph[nodeWithTwoIncomingEdges][0]] = 0;
                if (this.cycle(nodeWithTwoIncomingEdges, parentChildGraph[nodeWithTwoIncomingEdges][0]))
                {
                    return new int[] { parentChildGraph[nodeWithTwoIncomingEdges][0], nodeWithTwoIncomingEdges };
                }
                else
                {
                    return new int[] { parentChildGraph[nodeWithTwoIncomingEdges][1], nodeWithTwoIncomingEdges };
                }
            }

            foreach (int[] edge in edges)
            {
                this.isProcessed[edge[0]] = 0;
                if (this.cycle(edge[1], edge[0]))
                {
                    return edgeFormCycle;
                }
            }

            return new int[0];
        }

        private bool cycle(int start, int end)
        {
            this.isProcessed[start] = 0;
            //traverse through each neighbouring node in the graph from current index and perform DFS until you find a cycle
            if (childParentGraph.ContainsKey(start))
            {
                foreach (int neighbour in childParentGraph[start])
                {
                    if (this.isProcessed[neighbour] == -1)
                    {
                        if (cycle(neighbour, end))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else if (isProcessed[neighbour] == 0)
                    {
                        this.edgeFormCycle[0] = start;
                        this.edgeFormCycle[1] = neighbour;
                        return true;
                    }
                }
            }

            this.isProcessed[start] = 1;
            return false;
        }
    }

    public class RedundentConnectionHardUniFi
    {
        Dictionary<int, int> incoming = new Dictionary<int, int>();

        public int[] FindRedundantDirectedConnection(int[][] edges)
        {

            // count incoming edges for all nodes
            int nodeWithTwoIncomingEdges = -1;
            foreach(int[] edge in edges)
            {
                incoming.TryAdd(edge[1], 0);
                incoming[edge[1]] += 1;
                if (incoming[edge[1]] == 2) 
                    nodeWithTwoIncomingEdges = edge[1];
            }

            if (nodeWithTwoIncomingEdges == -1)
            {
                // if there are no nodes with 2 incoming edges -> just find a cycle
                //return findRedundantConnection(edges, -1);
            }
            else
            {
                // if there is a node with 2 incoming edges -> skip them one by one and try to build a graph
                // if we manage to build a graph without a cycle - the skipped node is what we're looking for
                for (int i = edges.Length- 1; i >= 0; i--)
                {
                    if (edges[i][1] == nodeWithTwoIncomingEdges)
                    {
                        //int[] res = findRedundantConnection(edges, i);
                        //if (res == null) return edges[i];
                    }
                }
            }

            return null;
        }

        //// 'Redundant Connection' solution is extended to skip a node.
        //int[] findRedundantConnection(int[][] a, int skip)
        //{
        //    UnionFind uf = new UnionFind();

        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        if (i == skip) continue;
        //        if (!uf.Union(a[i][0], a[i][1])) return a[i];
        //    }

        //    return null;
        //}
    }
}
