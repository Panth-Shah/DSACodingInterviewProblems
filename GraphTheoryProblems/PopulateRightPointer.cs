using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class PopulateRightPointer
    {

        // preorder recursive
        public Node connectPreorder(Node root)
        {
            if (root == null) return null;

            if (root.left != null)
            {
                root.left.next = root.right;
                if (root.next != null)
                {
                    root.right.next = root.next.left;
                }
            }

            connectPreorder(root.left);
            connectPreorder(root.right);
            return root;
        }

        // inorder recursive
        public Node connectInorder(Node root)
        {
            rightSiblingTree(root, null, false);
            return root;
        }

        // inorder traversal
        private void rightSiblingTree(Node node, Node parent, bool isLeftChild)
        {
            if (node == null) return;

            Node left = node.left, right = node.right;

            rightSiblingTree(left, node, true);

            // I am done with my left subtree
            // now dealing with myself
            if (parent == null) node.next = null;
            else if (isLeftChild) node.next = parent.right;
            else
            { // if this node is a right child
                if (parent.next == null) node.next = null; //for right children special case
                else node.next = parent.next.left; // my parent is done because of inorder
                                                   // because parent is inorder predecessor

            }
            rightSiblingTree(right, node, false);
        }

        // O(1) space
        // level order traversal
        public Node Connect(Node root)
        {
            //Check if input is invalid 
            if (root == null)
            {
                return root;
            }

            //Assign root node at level 0 to leftmost to start traversal
            Node leftmost = root;

            //Traverse until no left node will be left to create connection from
            while (leftmost.left != null)
            {

                //Point head to leftmost node
                //Start iterating from head of linked list and establish next pointer for each
                //node corresponding links for the next level
                Node head = leftmost;

                //Start processing nodes from same level
                //Establish connections on head
                while (head != null)
                {
                    //Connection 1: connection between nodes under same parent on N+1 level
                    head.left.next = head.right;
                    //Connection 2: connection between nodes under same parent on N+1 level
                    if (head.next != null)
                    {
                        head.right.next = head.next.left;
                    }
                    //Progress along the list which established next pointers and stop when head.next == null
                    head = head.next;
                }

                //Switch level and move to next level from N to N+1
                leftmost = leftmost.left;
            }
            return root;
        }

        // O(n) space // bfs
        public Node connect2(Node root)
        {
            //Initialize queue to perform BFS traversal
            Queue<Node> q = new Queue<Node>();
            //Perform Input validation
            if (root == null) 
                return null;
            //Start traversal from root node
            q.Enqueue(root);

            while (q.Count > 0)
            {
                //Max 2 level of nodes should be present in Queue at a time
                int size = q.Count;

                while (size > 0)
                {
                    Node curr = q.Dequeue();
                    //Only one element present, base case scenario
                    if (size == 1) 
                        curr.next = null;
                    else
                        curr.next = q.Peek();

                    if (curr.left != null) 
                        q.Enqueue(curr.left);
                    if (curr.right != null) 
                        q.Enqueue(curr.right);
                    size--;
                }

            }

            return root;
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
    }
}
