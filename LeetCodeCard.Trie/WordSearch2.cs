//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LeetCodeCard.Trie
//{
//    public class WordSearch2
//    {
//        private TrieNode root;
//        private char[][] _board = null;
//        public IList<string> result;
//        public WordSearch2()
//        {
//            this.root = new TrieNode();
//            this.result = new List<string>();
//        }

//        public IList<string> FindWords(char[][] board, string[] words)
//        {

//            //Initialization and parameter declaration
//            int row = board.Length;
//            int column = board[0].Length;
//            this._board = board;

//            //Build Trie
//            foreach (string word in words)
//            {
//                this.Insert(word);
//            }

//            //Itrate over each cell in grid and perform backtracking on trie
//            for (int r = 0; r < row; r++)
//            {
//                for (int c = 0; c < column; c++)
//                {
//                    //Check if word starting current letter is present in trie
//                    if (root.containsKey(board[r][c]))
//                    {
//                        backtracking(r, c, root);
//                    }
//                }
//            }

//            return this.result;
//        }

//        private void backtracking(int row, int column, TrieNode node)
//        {

//            char currentChar = this._board[row][column];
//            TrieNode currNode = node.getChild(currentChar);

//            //check if word ends
//            if (currNode.getRootValue() != null)
//            {
//                this.result.Add(currNode.getRootValue());
//                //To avoid duplicate entries in result
//                currNode.setRootValue(null);
//            }

//            //mark current letter # before exploration begins
//            this._board[row][column] = '#';

//            //explore neighbours
//            int[] rowOffset = { -1, 0, 1, 0 };
//            int[] colOffset = { 0, 1, 0, -1 };
//            for (int i = 0; i < 4; i++)
//            {
//                int newRow = row + rowOffset[i];
//                int newColumn = column + colOffset[i];
//                if (newRow < 0 || newRow >= this._board.Length || newColumn < 0 || newColumn >= this._board[0].Length)
//                {
//                    continue;
//                }

//                if (currNode.containsKey(this._board[newRow][newColumn]))
//                {
//                    backtracking(newRow, newColumn, currNode);
//                }
//            }

//            //End of exploration and set original letter back in the grid
//            this._board[row][column] = currentChar;
//        }

//        public void Insert(string word)
//        {
//            TrieNode node = root;
//            foreach (char ch in word)
//            {
//                if (!node.containsKey(ch))
//                {
//                    node.put(ch, new TrieNode());
//                }
//                node = node.getChild(ch);
//            }
//            node.setEnd();
//            node.setRootValue(word);
//        }
//    }
//}
