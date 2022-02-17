using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheoryProblems
{
    public class BinaryTreeVerticalOrderTraversal
    {
        public IList<IList<int>> VerticalOrder(TreeNode root)
        {
            Queue<TreeNodeMap> bfsQueue = new Queue<TreeNodeMap>();
            Dictionary<int, List<int>> columnTable = new Dictionary<int, List<int>>();
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }

            bfsQueue.Enqueue(new TreeNodeMap(root, 0));
            int column = 0;
            int minColumn = 0, maxColumn = 0;
            //Perform BFS
            while (bfsQueue.Count > 0)
            {
                TreeNodeMap currentNode = bfsQueue.Dequeue();
                root = currentNode.GetNode();
                column = currentNode.GetColumn();

                if (root != null)
                {
                    columnTable.TryAdd(column, new List<int>());
                    columnTable[column].Add(root.val);

                    minColumn = Math.Min(column, minColumn);
                    maxColumn = Math.Max(column, maxColumn);

                    bfsQueue.Enqueue(new TreeNodeMap(root.left, column - 1));
                    bfsQueue.Enqueue(new TreeNodeMap(root.right, column + 1));
                }
            }
            for (int i = minColumn; i < maxColumn; i++)
            {
                result.Add(columnTable[i]);
            }
            return result;
        }

        public class TreeNodeMap
        {
            public TreeNode node;
            public int column;
            public TreeNodeMap(TreeNode node, int col)
            {
                this.node = node;
                this.column = col;
            }
            public TreeNode GetNode()
            {
                return this.node;
            }
            public int GetColumn()
            {
                return this.column;
            }
            public int GetNodeValue()
            {
                return this.node.val;
            }
        }
    }
}
