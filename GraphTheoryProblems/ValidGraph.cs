using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class ValidGraph
    {
        #region Union Find Approach
        public bool ValidTree(int n, int[][] edges)
        {
            //Condition 1: If graph contains n-1 edges
            if (edges.Length != n - 1) return false;

            //Condition 2: Graph must contain a single component
            //Create components using UnionFind operations with n nodes
            UnionFindDS unifi = new UnionFindDS(n);
            foreach(int[] edge in edges)
            {
                //Keep adding all the edges into single component
                //Check if Union operation can be performed, if Union operation fails, cycle detects
                if (!unifi.Union(edge[0], edge[1]))
                    return false;
            }

            return true;
        }
        #endregion

        public class UnionFindDS
        {
            int[] root;
            int[] rank;
            //Using size to keep track of size of each set to retermine if single component is of size n, which proves all the nodes are connected
            int[] size;
            
            public UnionFindDS(int treeSize)
            {
                root = new int[treeSize];
                rank = new int[treeSize];
                size = new int[treeSize];
                for (int node = 0; node < treeSize; node++ )
                {
                    //Initialize each node with it's own parent
                    root[node] = node;
                    //Initialize height of each node to 1
                    rank[node] = 1;
                    //Initialize size of each component to 1
                    size[node] = 1;
                }
            }

            // The find method, with path compression.
            public int Find(int node)
            {
                //If root of the node is same as node, return node
                if (node == root[node])
                {
                    return node;
                }
                //Perform recursive operation until root of the node is not found
                //Path Compression is performed by setting elected root of an element as a root of the current node
                //Path Compression reduces the search space for the root and operations doesn't have to hop through all the chained nodes to find root of component
                return root[node] = Find(root[node]);
            }

            public bool Union(int nodeA, int nodeB)
            {
                int rootA = Find(nodeA);
                int rootB = Find(nodeB);

                //If root of both the nodes isn't the same, they aren't part of same component
                //If both the nodes aren't part of the same component, perform Union operation
                //This operation is performed with Union By Ran appraoch

                if (rootA != rootB)
                {
                    if (rank[rootA] > rank[rootB])
                    {
                        //Merge nodeB under nodeA component
                        root[rootB] = rootA;
                        //Size of component with rootA increases by size of component with rootB
                        size[rootA] += size[rootB];
                    }
                    else if (rank[rootB] > rank[rootA])
                    {
                        //Merge nodeA under nodeB component
                        root[rootA] = rootB;
                        //Size of component with rootB increases by size of component with rootA
                        size[rootB] += rootA;
                    }
                    else
                    {
                        //If rank of both the root are same
                        root[rootB] = rootA;
                        rank[rootA] += 1;
                        size[rootA] += 1;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
