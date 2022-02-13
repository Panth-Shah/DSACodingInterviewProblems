using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    //Union Find Data Structure implementation
    public class UnionFind
    {
        private int[] root;
        // Use a rank array to record the height of each vertex, i.e., the "rank" of each vertex.
        private int[] rank;
        private int count;

        public UnionFind(int size)
        {
            root = new int[size];
            rank = new int[size];
            count = size;
            for (int i = 0; i < size; i++)
            {
                //Initialize root of each node to itself
                root[i] = i;
                //Initialize height of each node to 1
                rank[i] = 1;
            }
        }
        // Find is implemented with Path Compression.
        public int Find(int x)
        {
            if (x == root[x])
            {
                return x;
            }
            return root[x] = Find(root[x]);
        }

        // The union function with union by rank
        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY)
            {
                if (rank[rootX] > rank[rootY])
                {
                    root[rootY] = rootX;
                }
                else if (rank[rootY] > rank[rootX])
                {
                    root[rootX] = rootY;
                }
                else
                {
                    root[rootY] = rootX;
                    rank[rootX] += 1;
                }
                count--;
            }
        }

        public int GetCount()
        {
            return count;
        }

        public int GetRoot(int node)
        {
            return root[node];
        }
    }
}
