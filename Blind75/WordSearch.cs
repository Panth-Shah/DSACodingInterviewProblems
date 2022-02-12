using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind75
{
    public class WordSearch
    {
        private char[][] cloneBoard;
        private int rowCount;
        private int columnCount;
        private int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

        public bool Exist(char[][] board, string word)
        {
            //Construct word from letters of sequentially adjacent cells, where adjacent cells are horizontally or vertically neighbouring
            //Move one step to right, left, top or bottom direction to look for letters from current cell

            //Intuition:
            //For each cell, perform backtracking to move in 4 direction to identify if the word can be formed
            //Base Case: Word is matched and no prefix left to match from the word
            //Restriction Condition: If current cell is out of boundary or itsn't matching with the letter from word
            //For each cell, there are two possible outcomes as below:
            //Possibility 1: Current cell matches with the letter from word, if so mark that cell as visited and perform DFS in 4 directions starting current cell
            //Possibility 2: Current cell doesn't match with the letter from word, stop exporation of current path and perform backtracking

            this.cloneBoard = board;
            this.rowCount = board.Length;
            this.columnCount = board[0].Length;

            // Pruning: Case 1: not enough characters in board
            if (word.Length > rowCount * columnCount) return false;

            // Pruning: Case 2: board does not contain characters or enough characters that word contains
            Dictionary<char, int> wordLetterFrequencyMap = new Dictionary<char, int>();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (!wordLetterFrequencyMap.ContainsKey(this.cloneBoard[i][j]))
                    {
                        wordLetterFrequencyMap.Add(this.cloneBoard[i][j], 0);
                    }
                    wordLetterFrequencyMap[board[i][j]] += 1;
                }
            }

            for (int i = 0; i < word.Length; i++)
            {
                char currentLetter = word[i];
                if (!wordLetterFrequencyMap.ContainsKey(currentLetter))
                {
                    return false;
                }
                else
                {
                    int temp = wordLetterFrequencyMap[currentLetter];
                    if (temp == 1)
                    {
                        wordLetterFrequencyMap.Remove(currentLetter);
                    }
                    else
                    {
                        wordLetterFrequencyMap[currentLetter] -= 1;
                    }
                }
            }

            //Traverse through each cell in the board
            for (int row = 0; row < this.rowCount; row++)
            {
                for (int column = 0; column < this.columnCount; column++)
                {

                    if (this.backtrack(row, column, word, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool backtrack(int currentRow, int currentColumn, string word, int currentIndex)
        {
            //Step 1: Check base case
            if (currentIndex >= word.Length)
            {
                return true;
            }

            //Step 2: Check restriction condition - Boundary check and current cell value check
            if (currentRow < 0 || currentRow == this.rowCount || currentColumn == this.columnCount || currentColumn < 0 || this.cloneBoard[currentRow][currentColumn] != word[currentIndex])
            {
                return false;
            }

            //Step 3: Start exploring neighbouring nodes in DFS
            bool ret = false;

            //Mark path before next exploration to perform backtracking
            this.cloneBoard[currentRow][currentColumn] = '#';

            //Start backtracking in all 4 directions
            foreach (int[] direction in directions)
            {
                int r = currentRow + direction[0];
                int c = currentColumn + direction[1];
                ret = this.backtrack(r, c, word, currentIndex + 1);
                if (ret)
                    break;
            }

            //Step 4: Result successfully found and set word letters into current explored path
            this.cloneBoard[currentRow][currentColumn] = word[currentIndex];
            return ret;

        }
    }
}
