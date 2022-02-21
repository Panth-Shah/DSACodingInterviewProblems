using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.CodingPatterns
{
    public class DijkstraAlgorithm
    {
        //743. Network Delay Time
        //Time Complexity: O(N + ElogN)
            //Max number of vertices added into priority queue is E. Thus Push and Pop operations on the Priority Queue takes O(logE) time.
            //The value of E can be at most N * (N - 1)
            //Therefore, O(logE) is equivalent to O(logN^2), equals O(2logN) = O(logN)
            //Hence, time complexity for priority queue ops equals O(logN) for E edges = O(ElogN)
            //O(N) is to find minimum time from the array of size N
        //Space Complexity: O(N + E)
            //Building graph adjacency list O(E) space
            //Dijkstra algorithm will take O(E) space for priority queue as each vertex could be added into priority queue N - 1 times if all the vertices are connected to each other
            // Which makes N*(N - 1) and O(N^2) which is equivalent to O(E)
            //Array to store visited and timeToReceiveSignalAt arrayw will take O(N)


        Dictionary<int, List<(int, int)>> adj = new Dictionary<int, List<(int, int)>>();
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            //Implementation of Dijkstra's algorihtm
            //1. Create an adjacency List representation of a graph from times
            //2. Maintain array of time taken by signal to reach to a given node
            //3. Initialize Priority Queue to get most promising node at each traversal from source to destination
            //4. Iterate over all the edges starting node k until we find a path to n and find time taken for n node to receive single from k

            //Build adjacency list from given input
            foreach (int[] edge in times)
            {
                int source = edge[0];
                int destination = edge[1];
                int travelTime = edge[2];

                adj.TryAdd(source, new List<(int, int)>());
                adj[source].Add(new(destination, travelTime));
            }

            //Initialize array of time taken to reach to specific node
            int[] timeToReceiveSignalAt = new int[n+1];

            Array.Fill(timeToReceiveSignalAt, int.MaxValue);

            //Initialize visited array to keep track of visited nodes in directed  graph
            bool[] visited = new bool[n + 1];
            Array.Fill(visited, false);

            //Perform dijkastra
            dijkstra(ref timeToReceiveSignalAt, k, n, visited);

            //This needs done to handle cyclic graph test case
            //[[2, 1, 3] [1, 2, 1]], n = 2, k = 2

            int ans = int.MinValue;
            for (int i = 1; i <= n; i++)
            {
                ans = Math.Max(ans, timeToReceiveSignalAt[i]);
            }

            return ans == int.MaxValue ? -1 : ans;
        }
        private void dijkstra(ref int[] singleReceiveAt, int source, int dest, bool[] visited)
        {
            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
            pq.Enqueue(new (source, 0), 0);

            singleReceiveAt[source] = 0;
            while (pq.Count != 0)
            {
                //Dequeue first promising element from priority queue
                (int, int) promisingPair = pq.Dequeue();

                int currNode = promisingPair.Item1;
                int currNodeTime = promisingPair.Item2;

                visited[currNode] = true;

                //Optimization: No need to process duplicate records in priority queue for same destination node if record with better time already processed
                if (singleReceiveAt[currNode] < currNodeTime)
                {
                    continue;
                }
                if (adj.ContainsKey(currNode))
                {
                    foreach ((int, int) destNode in adj[currNode])
                    {

                        int time = destNode.Item2;
                        int neighbourNode = destNode.Item1;

                        //If adjacent node is already visited, don't process
                        if (visited[neighbourNode])
                        {
                            continue;
                        }

                        //Perform Edge Relaxation
                        if (singleReceiveAt[currNode] + time < singleReceiveAt[neighbourNode])
                        {
                            singleReceiveAt[neighbourNode] = singleReceiveAt[currNode] + time;
                            pq.Enqueue(new(neighbourNode, singleReceiveAt[neighbourNode]), singleReceiveAt[neighbourNode]);
                        }
                    }
                }
            }
        }
    }
}
