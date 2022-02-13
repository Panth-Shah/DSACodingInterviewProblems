using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class NumberOfProvinces
    {
        #region Using DFS
        public int FindCircleNum(int[][] isConnected)
        {
            int row = isConnected.Length;
            int column = isConnected[0].Length;
            //Initialize counter to calculate number of provinces
            int count = 0;
            //Initialize array to track which cities are already visited in bidirectional graph to avoid loop while traversing
            int[] visited = new int[row];

            //Start to iterate row wise and perform DFS starting each node in the graph
            for (int city = 0; city < isConnected.Length; city++)
            {
                //Check if current node of the graph is already visited
                if (visited[city] == 0)
                {
                    //If current node is not visited, perform DFS on this node and traverse all the way to the leaf node of the tree starting this node to find connected component in the graph starting current node
                    graphTraversalDFS(isConnected, visited, city);
                    //Each connected component is a part of same province and so increament counter to add number of provinces after each DFS on current node/city
                    count++;
                }
            }

            return count;
        }

        private void graphTraversalDFS(int[][] cityMap, int[] visitedCity, int cityNum)
        {
            //Iterate through each neighbour of node from which DFS is initiated
            for (int neighbourCity = 0; neighbourCity < cityMap.Length; neighbourCity++)
            {
                //Check if there is aconnectivity between starting node and it's neighbour node
                //If nodes are connected and neighbouring city is not already visited
                if (cityMap[cityNum][neighbourCity] == 1 && visitedCity[neighbourCity] == 0)
                {
                    //Mark neighbouring city as visited
                    visitedCity[neighbourCity] = 1;
                    //Take neighbouring city as a starting point to perform DFS
                    graphTraversalDFS(cityMap, visitedCity, neighbourCity);
                }
            }
        }
        #endregion

        #region Using BFS
        public int FindCircleNumUsingBFS(int[][] isConnected)
        {
            //Apply BFS to traverse graph and find count of connected components
            int[] visited = new int[isConnected.Length];
            int count = 0;

            //Initialize queue to perform BFS starting the first node of the matrix
            Queue<int> queue = new Queue<int>();

            //Start traversing each city and pick them starting point to perform BFS
            for (int city = 0; city < isConnected.Length; city++)
            {
                //Check if city is already visited in undirected graph
                if (visited[city] == 0)
                {
                    //Add current city to queue to perform BFS on it's neighbours
                    queue.Enqueue(city);
                    while (queue.Count > 0)
                    {

                        int currentCity = queue.Dequeue();
                        //Mark current City as visited so we won't visite it again
                        visited[currentCity] = 1;

                        //Find all the neighbours of the current Node and add them to queue to perform BFS on neighbouring nodes
                        for (int neighbourCity = 0; neighbourCity < isConnected.Length; neighbourCity++)
                        {
                            if (isConnected[currentCity][neighbourCity] == 1 && visited[neighbourCity] == 0)
                            {
                                queue.Enqueue(neighbourCity);
                            }
                        }
                    }
                    //If all the connected nodes are traversed starting current node, it completes one province and counts as connected component
                    count++;
                }
            }
            return count;
        }
        #endregion

        #region Union Find
        public int FindCircleNumUnionFind(int[][] isConnected)
        {
            if (isConnected == null || isConnected.Length == 0)
                return 0;

            int totalCityCount = isConnected.Length;
            //Initialize UnionFind datastructure
            UnionFind unionFindConnectedComponents = new UnionFind(totalCityCount);

            //Traverse through each city and it's connected cities to build connected components using Union Find DS
            for (int i = 0; i < totalCityCount; i++)
            {
                for (int j = 0; j < totalCityCount; j++)
                {
                    //If direct path between two cities is available, perform Union operation to match the root of both the nodes
                    if (isConnected[i][j] == 1)
                    {
                        //Union operation will be performed to join two disjoint sets and make a connected component by making root of both the nodes same
                        unionFindConnectedComponents.Union(i, j);
                    }
                }
            }
            //Total Count is initialized to number of cities
            //In worst case, if no cities are connected to each other, number of connected components will be number of cities
            //Union Find datastructure maintains count of provinces internally and reduce count upon performing union operation
            return unionFindConnectedComponents.GetCount();
        }
        #endregion
    }
}