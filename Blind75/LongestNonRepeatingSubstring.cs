using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind75
{
    public class LongestNonRepeatingSubstring
    {
        public int LongestSubstringWithNoRepeatingCharacters(string s)
        {
            int stringLength = s.Length;
            //Initialize Begin and End pointer for sliding window
            int begin = 0;
            int end = 0;
            int subStringLength = 0;
            //Initialize Char Map to identify if repeating char appears
            HashSet<char> charMap = new HashSet<char>();

            //Iterate until end of string with sliding window approach
            while (begin < stringLength && end < stringLength)
            {
                //Check if current character is present in CharMap, which indicates repeating character
                if (!charMap.Contains(s[end]))
                {
                    //If character isn't present in CharMap, add it and expand the window from the end
                    charMap.Add(s[end++]);
                    //Calculate max SubString Length after expanding end
                    subStringLength = Math.Max(subStringLength , end - begin );
                }
                else
                {
                    //If character exists in the CharMap, repeating character is identified and so remove that character
                    //Expand sliding window from the start
                    charMap.Remove(s[begin++]);
                }
            }
            return subStringLength;
        }
    }
}
