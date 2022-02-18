using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind75
{
    public  class AlientDictionaryUsingDFS
    {
        //Step 0: Initialize DS and find all unique letters
        Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
        Dictionary<char, bool> seen = new Dictionary<char, bool>();
        StringBuilder output = new StringBuilder();

        public string AlienOrder(string[] words)
        {
            //Solution Uisng DFS
            //Intuition:
            //1. Build graph with nodes as unique letters in words and edges will be lexicographical relation between nodes
            //2. This approach doesn't need maintaining indegree count of each node
            //3. Here, postorder traversal of graph is performed while performing DFS to
            //While performing traversal, we go all the way to a node with no children and that will be the base case of recursive function
            //Backtrack to node currently getting explored and check if all of it's adjacent nodes are visited before current node is set to be visited
            //4. To detect cycle, we keep track of all the visited nodes. Cycle will only be formed if any visited node is visited during current traversal. If visited node is identified by that node is not visited in current traversal, that isn't forming cycle
            //For example: If A->B->C and A->C is also an edge. If C is visited when we explored A, if we reach to C when we are exploring B and find C visited, it's not forming a cycle because we havent' visited C while we are exploring B
            //5. While returning result, reverse the string because add nodes in postorder and so node with no children is added first, which is last in lexicographical order

            //Iterate over each word and try extract information as much as possible
            foreach (string word in words)
            {
                foreach (char letter in word)
                {
                    //Initialize indegreeMap and graph taking each unique letter of word as key
                    graph.TryAdd(letter, new List<char>());
                }
            }

            //Step 1: Find edges between each unique node to build a graph representing as Adjacency List
            for (int i = 0; i < words.Length - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];

                //Check if word 2 is not a prefix of word 1
                //This is an edge case where cycle is detected
                if (word1.Length > word2.Length && word1.StartsWith(word2))
                {
                    return "";
                }

                //Find the first non matching letters from both the strings and build relation between them
                for (int j = 0; j < Math.Min(word1.Length, word2.Length); j++)
                {
                    if (word1[j] != word2[j])
                    {
                        //Non matching letter from Word 1 is lexicographically smaller than letter from Word2 at same index
                        //Build reverse adjacency list, so we don't have to reverse result at the end of DFS
                        graph[word2[j]].Add(word1[j]);
                        break;
                    }
                }
            }

            //Step 2: Perform DFS to build result
            foreach (char mapKey in graph.Keys)
            {
                bool result = dfs(mapKey);
                if (!result) return "";
            }

            //If not all unique letters are added in the result string in lexicographical order, return ""
            if (output.Length < graph.Count)
            {
                return "";
            }

            return output.ToString();
        }

        //Return true if no cycle is detected
        private bool dfs(char ch)
        {
            //Start exploring current character
            //Check if current character exists in seen dictionary and if it's set to true or false
            //If set to false: cycle is detected as node is seen again during same exploration
            //If set to true : no cycle as node is not seen again during same exploration
            if (seen.ContainsKey(ch))
            {
                return seen[ch];
            }

            seen.TryAdd(ch, false);

            foreach (char adjacentChar in graph[ch])
            {
                bool result = dfs(adjacentChar);
                //If already seen node is seen during the same traversal, cycle is detected
                if (!result) return false;
            }
            //Set seen to true for current node as node is seen during current exploration
            //No cycle is detected as it's been seen only once
            seen[ch] = true;
            output.Append(ch);
            //Return true if all the adjacent nodes of current element is visited and no cycle detected
            return true;
        }
    }
}
