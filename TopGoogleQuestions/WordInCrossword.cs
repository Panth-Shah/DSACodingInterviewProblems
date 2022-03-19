using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class WordInCrossword
    {
        public bool PlaceWordInCrossword(char[][] board, string word)
        {
            char[][] rotatedBoard = getRotatedBoard(board, word);
            char[] reverseStringArr = word.ToCharArray();
            Array.Reverse(reverseStringArr);
            string reverseString = new string(reverseStringArr);
            return helper(board, word) || helper(rotatedBoard, word) || helper(rotatedBoard, reverseString) || helper(board, reverseString);
        }


        private bool helper(char[][] board, string word)
        {
            //Convert row into string
            foreach (char[] row in board)
            {
                string rowWord = new string(row);
                foreach(string token in rowWord.Split('#'))
                {
                    if (word.Length == token.Length && canFit(word, token))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool canFit(string word, string token)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (token[i] != ' ' && token[i] != word[i])
                {
                    return false;
                }
            }

            return true;

        }
        private char[][] getRotatedBoard(char[][] board, string word)
        {
            int rowCount = board.Length;
            int colCount = board[0].Length;

            char[][] rotatedBoard = new char[rowCount][colCount];

            for(int r = 0; r < rowCount; r++){
                for (int c = 0; c < colCount; c++) {
                    rotatedBoard[c][r] = board[r][c];
                }
            }

            return rotatedBoard;
        }
    }
}
