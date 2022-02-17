using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.CodingPatterns
{
    #region Kruskal Algorithm Implementation
    public class KruskalAlgorithm
    {
        public int MinCostConnectPoints(int[][] points)
        {
            if (points == null || points.Length == 0)
            {
                return 0;
            }

            int size = points.Length;
            //Initialize UnionFind Datastructure
            UnionFind unifi = new UnionFind(size);
            //Initialize Proprity queue to sort edges based on weight
            PriorityQueue<Edge, int> priorityQueue = new PriorityQueue<Edge, int>();

            //Iterate through each point and calculate Edge weight and store them in priority queue
            //Here, each node connects with each other node and indices of points array will be represented as vertices
            for (int i = 0; i < size; i++)
            {
                int[] coordinate1 = points[i];
                for (int j = i + 1; j < size; j++)
                {
                    int[] coordinate2 = points[j];
                    //Calculate distance between two points
                    int cost = Math.Abs(coordinate1[0] - coordinate2[0]) +
                        Math.Abs(coordinate1[1] - coordinate2[1]);
                    Edge edge = new Edge(i, j, cost);
                    priorityQueue.Enqueue(edge, cost);
                }
            }

            int result = 0; // Find minimum cost to connect all the nodes
            int count = size - 1; //This is because we need to add maximum of n-1 edges for n nodes to make minimum spanning tree; as if we add more edges, it will form cycle
            while (priorityQueue.Count > 0 && count > 0)
            {
                Edge currentEdge = priorityQueue.Dequeue();
                //Check if currentEdge is already added to minimum spanning tree or form a cycle by checking if both the vertices of edge is already connected
                if (!unifi.isConnected(currentEdge.point1, currentEdge.point2))
                {
                    unifi.Union(currentEdge.point1, currentEdge.point2);
                    result += currentEdge.cost;
                    count--;
                }
            }
            return result;
        }
    }
    #endregion
    #region Union Find Implementation
    public class UnionFind
    {
        int[] root;
        int[] rank;
        int count;
        public UnionFind(int size)
        {
            root = new int[size];
            rank = new int[size];
            count = size;
            for (int i = 0; i < size; i++)
            {
                //Initialize rank for all the nodes to 1
                rank[i] = 1;

                //Initialize root of each node to node itself
                root[i] = i;
            }
        }

        //Find operation with Find by Rank
        public int Find(int node)
        {
            if (root[node] == node)
            {
                return root[node];
            }

            return root[node] = Find(root[node]);
        }

        //Union operation using Path Compression
        public void Union(int nodeA, int nodeB)
        {
            int rootA = root[nodeA];
            int rootB = root[nodeB];

            if (rank[rootA] > rank[rootB])
            {
                root[rootB] = rootA;
            }else if (rank[rootA] < rank[rootB])
            {
                root[rootA] = rootB;
            }
            else
            {
                root[rootB] = rootA;
                rank[rootA] += 1;
            }
        }

        public bool isConnected(int nodeA, int nodeB)
        {
            //If root of both the nodes are same, they are connected
            return Find(nodeA) == Find(nodeB);
        }
    }
    #endregion

    public class Edge
    {
        public int point1;
        public int point2;
        public int cost;

        public Edge(int p1, int p2, int cost)
        {
            this.point1 = p1;
            this.point2 = p2;
            this.cost = cost;
        }
    }
}
