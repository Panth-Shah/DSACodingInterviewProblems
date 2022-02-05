using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
    public class CloneGraph
    {
        private Dictionary<Node, Node> clonedMap = new Dictionary<Node, Node>();
        public Node GraphClone(Node node)
        {
            //Maintain Hashmap to eliminate cycles while traversing undirected graph
            //key will be original Node and Value will be cloned node from the original

            //Input validation
            if (node == null)
            {
                return node;
            }

            //Create a clone for given node
            Node cloneNode = new Node(node.val, new List<Node>());

            //For the first iteration, we don't have any clone and so we will clone current node first and add it in visited map before start recursive call to visit all the paths from current node
            clonedMap.Add(node, cloneNode);

            //Iterate through all the neighbours of the current node and add it to neighbour list of cloned copy of current node
            foreach (Node neighbor in node.neighbors)
            {
                if (!clonedMap.ContainsKey(neighbor))
                {
                    cloneNode.neighbors.Add(GraphClone(neighbor));
                }
                else
                {
                    //If Node we are traversing is already in clonedMap, we will return cloned node reference for that node
                    cloneNode.neighbors.Add(clonedMap[neighbor]);
                }
            }
            return cloneNode;

        }
    }
}
