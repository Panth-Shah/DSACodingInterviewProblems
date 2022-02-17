using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    //1101. The Earliest Moment When Everyone Become Friends
    public class EarliestAcq
    {
        public int EarliestAcqFind(int[][] logs, int n)
        {
            var sortedLog = logs.OrderBy(x => x[0]).ToArray();
            //Initialize union find datastructure with n size
            UnionFind unifi = new UnionFind(n);

            //Iterate through each node of log and perform union operation for each node with it's neighbouring node
            //Keep performing this operation until GetCount = 1
            foreach (int[] edge in sortedLog)
            {
                //Perform union operation until only one component is left
                unifi.Union(edge[1], edge[2]);
                if (unifi.GetCount() == 1)
                {
                    return edge[0];
                }
            }
            return -1;
        }
    }
}
