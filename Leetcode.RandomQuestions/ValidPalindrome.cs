using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.RandomQuestions
{
    public class ValidPalindrome
    {
        public bool ValidPalindromeSolution(string s)
        {
            int start = 0;
            int end = s.Length - 1;
            while (start < end)
            {
                if (s[start] == s[end])
                {
                    start++;
                    end--;
                }
                else
                {
                    if (helper(s, start, end - 1))
                    {
                        return true;
                    }
                    if (helper(s, start + 1, end))
                    {
                        return true;
                    }
                    return false;
                }

            }
            return true;
        }

        public bool helper(String s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] == s[end])
                {
                    start++;
                    end--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
