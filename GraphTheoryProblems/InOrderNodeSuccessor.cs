using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    //285. Inorder Successor in BST

    public class InOrderNodeSuccessor
    {
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            //Cases to consider:
            //1. p is the largest element of all the nodes in BST and so successor = null
            //2. p has no right subtree, successor will be parent of last inserted left ancestor
            //3. p has right subtree, successor will be leftmost child of right subtree

            //Since we are looking at the immediate successor of p in BST, we can take advantage of BST property, InOrder traversal of BST will return result in increasing order
            //Approach:
            //Run InOrder traversal until we visit node greater than p and because result of this traversal is strictly non-descending order, we can be sure that first visited node greater than p will be it's successor
            TreeNode successor = null;
            while (root != null)
            {
                successor = InorderSuccessor(root.left, p);
                if (successor != null)
                {
                    return successor;
                }
                else
                {
                    if (root.val > p.val)
                    {
                        return root;
                    }
                    else
                    {
                        //Only perform right search if p > root
                        return InorderSuccessor(root.right, p);
                    }
                }
            }

            return null;
        }
    }
}
