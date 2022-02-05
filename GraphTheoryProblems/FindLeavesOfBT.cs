using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    //Problem: 366. Find Leaves of Binary Tree
    //Time Complexity: O(N)
        //Analysis: Traversing and Storing all the pairs at the correct position takes O(N) time.
    //Space Complexity: O(N) -> Space used to store solution array
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class FindLeavesOfBT
    {
        private IList<IList<int>> solution;
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            //Approach 1: DFS with Sorting of Height of nodes
            this.solution = new List<IList<int>>();
            getHeight(root);

            return this.solution;

        }

        class SnapShotType
        {
            private static int snap_id;
            private static int value;
            private SnapShotType()
            {

            }
        }
        private int getHeight(TreeNode root)
        {

            //return -1 if null node is detected
            if (root == null)
            {
                return -1;
            }

            //First calculate node.left and node.right node heights
            int leftHeight = getHeight(root.left);
            int rightHeight = getHeight(root.right);

            //based on the height of the left and right children, obtain the height of the current (parent) node
            int currentHeight = 1 + Math.Max(leftHeight, rightHeight);

            if (this.solution.Count == currentHeight)
            {
                this.solution.Add(new List<int>());
            }
            this.solution[currentHeight].Add(root.val);

            return currentHeight;
        }
    }
}
