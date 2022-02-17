using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Backtracking
{
    //216. Combination Sum III
    public class CombinationSumlll
    {
        IList<IList<int>> result = new List<IList<int>>();
        public IList<IList<int>> CombinationSum3(int k, int n)
        {
            //Perform backtracking to evaluate each digit choice to make sum = n
            LinkedList<int> combination = new LinkedList<int>();

            this.backtrack(n, k, combination, 0);
            return result;
        }

        public void backtrack(int remain, int digitCount, LinkedList<int> combo, int next_start)
        {

            if (remain == 0 && combo.Count == digitCount)
            {
                //Make a deep copy of the combo, else it will be reverted in other branches of backtracking
                List<int> resultList = new List<int>();
                resultList.AddRange(combo);
                result.Add(resultList);
                return;
            }
            else if (remain < 0 || combo.Count == digitCount)
            {
                //Stop exploration
                return;
            }

            //Iterate through list of candidates available until this point
            for (int i = next_start; i < 9; i++)
            {
                //Add first digit to build combination, starts with 1 -> 9 to build k combinations
                combo.AddLast(i + 1);
                //Here, we will not pick same digit in next position if digit is already picked in previous position
                this.backtrack(remain - i - 1, digitCount, combo, i + 1);
                //After current branch of backtracking is completed, traverse back and remove all the elements from LinkedList
                combo.RemoveLast();
            }
        }
    }
}
