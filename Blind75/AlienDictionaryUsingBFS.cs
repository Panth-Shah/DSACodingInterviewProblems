using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind75
{
    public class AlienDictionaryUsingBFS
    {
        public string AlienOrder(string[] words)
        {
            //Solution using Kahn's algorithm using BFS

            //Step 0: Initialize DS and find all unique letters
            Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
            //Initialize DS to keep track of indegree for each letter
            Dictionary<char, int> letterIndegreeMap = new Dictionary<char, int>();

            //Iterate over each word and try extract information as much as possible
            foreach (string word in words)
            {
                foreach (char letter in word)
                {
                    //Initialize indegreeMap and graph taking each unique letter of word as key
                    letterIndegreeMap.TryAdd(letter, 0);
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
                        graph[word1[j]].Add(word2[j]);
                        //Increase indegree count when incombing edge is detected from word 1 letter to word 2 letter
                        letterIndegreeMap[word2[j]] += 1;
                        break;
                    }
                }
            }

            //Step 2: Perform BFS using graph built
            //Sequence of final result will be the sequence in which letter will be entering in the queue for BFS
            StringBuilder sb = new StringBuilder();
            Queue<char> q = new Queue<char>();

            //Start BFS by inserting all the nodes with indegree count = 0, following their adjacent nodes
            //Make sure to reduce indegree count for each adjacent node of current processing node in BFS
            foreach (var mapKey in letterIndegreeMap.Keys)
            {
                if (letterIndegreeMap[mapKey] == 0)
                {
                    q.Enqueue(mapKey);
                }
            }

            //Start performing BFS
            while (q.Count > 0)
            {
                char currentChar = q.Dequeue();
                sb.Append(currentChar);
                foreach (char adjacentChar in graph[currentChar])
                {
                    //Reduce indegree count for adjacent node by 1 before pushing into queue
                    letterIndegreeMap[adjacentChar] -= 1;
                    //If Adjacent node's indegree = 0, push to queue
                    if (letterIndegreeMap[adjacentChar] == 0)
                    {
                        q.Enqueue(adjacentChar);
                    }
                }
            }

            //If not all unique letters are added in the result string in lexicographical order, return ""
            if (sb.Length < letterIndegreeMap.Count)
            {
                return "";
            }

            return sb.ToString();
        }
    }
}
