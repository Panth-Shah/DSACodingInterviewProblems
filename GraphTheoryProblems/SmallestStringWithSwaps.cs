using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class SmallestStringWithSwaps
    {
        public string SmallestStringWithSwapsUnionFind(string s, IList<IList<int>> pairs)
        {

            //Intuition:
            //Idea here is to consider string as an array of character
            //Each character is associated with it's respective index
            //Each respective index of character is a node in the graph
            //To perform Union Find, consider each character index as a disjoint set which needs united
            //While performing union operation from paris, we perform union on indexes which can be connected
            //After performing Union operation, we get number of connected components
            //Characters can be swaped among same connected components, but not between disjoing sets which are not connected and have same root
            //Priority queue will help maintain lexicographical order while building string from characters stored under same root of connected components after performing Union Find operation
            //Here, Ascii value of each character is used to pass as a pariority while storing each character in PriorityQueue

            //Key Takeaways:
            //String needs represted as an array of characters and character indexes are used to build graph
            //Pairs represent graph edges between two character indexes which can be swapped
            //Multiple graph edges can be united to form a connected component using union find data structure
            //A root is elected for all the nodes(character array indexes) and characters are stored in priority queue under this root
            //Swap operation is a combination two operations: 
            //1. Find root for each index
            //2. Store character against each index in priority queue

            // Convert the input string into a byte[] to build Priority Queue
            byte[] stringAsciiBytesArray = Encoding.ASCII.GetBytes(s);

            //Initialize rootCharacterPrirityMap, which will hold priority queue against each root components after Union operation is performed on individual components
            //Dictionary<int, PriorityQueue<char, int>> rootCharacterPriorityMap = new Dictionary<int, PriorityQueue<char, int>>();

            //UnionFind uniFi = new UnionFind(s.Length);
            ////Perform Union operation on all the pairs provided to find connected components to perform swag of characters
            //foreach (IList<int> pair in pairs)
            //{
            //    uniFi.Union(pair[0], pair[1]);
            //}

            //for (int i = 0; i < s.Length; i++)
            //{
            //    //Find root element for current element
            //    int root = uniFi.Find(i);

            //    // Add the character to the priority queue labelled by the root
            //    rootCharacterPriorityMap.TryAdd(root, new PriorityQueue<char, int>());
            //    //Add each character against the root and sorted 
            //    rootCharacterPriorityMap[root].Enqueue(s[i], stringAsciiBytesArray[i]);
            //}

            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < s.Length; i++)
            //{
            //    //Capture root for current node
            //    int nodeRoot = uniFi.GetRoot(i);
            //    //Dequeue character from the priority queue stored under root of current node
            //    char stringCharacter = rootCharacterPriorityMap[nodeRoot].Dequeue();
            //    sb.Append(stringCharacter);
            //}
            //return sb.ToString();
            return null;
        }
    }
}
