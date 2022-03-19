using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class NumberOfIsland2
    {
        private int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
        private IList<int> result = new List<int>();
        public IList<int> NumIslands2(int m, int n, int[][] positions)
        {
            int totalElements = m * n;
            UnionFindIsland unifi = new UnionFindIsland(totalElements);

            foreach (int[] pos in positions)
            {
                int row = pos[0];
                int col = pos[1];
                int root = n * row + col;
                unifi.Insert(root);

                foreach (int[] direction in directions)
                {
                    int newRow = row + direction[0];
                    int newColumn = col + direction[1];
                    int newRoot = n * newRow + newColumn;

                    if (newRow < 0 || newColumn < 0 || newRow >= m || newColumn >= n || unifi.roots[newRoot] == -1)
                    {
                        continue;
                    }
                    unifi.Union(root, newRoot);
                }
                result.Add(unifi.ConnectedComponentCount());
            }
            return result;
        }
    }

    public class UnionFindIsland
    {
        public int[] roots;
        public int[] rank;
        public int count = 0;
        public UnionFindIsland(int size)
        {
            this.roots = new int[size];
            this.rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                roots[i] = -1;
            }
        }

        public void Insert(int root)
        {
            if (roots[root] == -1)
            {
                roots[root] = root;
                rank[root] = 1;
                count += 1;
            }
        }

        public int Find(int node)
        {
            if (roots[node] == node)
            {
                return roots[node];
            }
            return roots[node] = Find(roots[node]);
        }

        public void Union(int nodeA, int nodeB)
        {
            int rootA = Find(nodeA);
            int rootB = Find(nodeB);
            if (rootA != rootB)
            {
                if (rank[rootA] > rank[rootB])
                {
                    roots[rootB] = rootA;
                }
                else if (rank[rootA] < rank[rootB])
                {
                    roots[rootA] = rootB;
                }
                else
                {
                    roots[rootB] = rootA;
                    rank[rootA] += 1;
                }
                count--;
            }
        }

        public bool isConnected(int nodeA, int nodeB)
        {
            return Find(nodeA) == Find(nodeB);
        }

        public int ConnectedComponentCount()
        {
            return this.count;
        }
    }
}
