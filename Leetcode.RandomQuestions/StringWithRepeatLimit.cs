using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.RandomQuestions
{
    public class StringWithRepeatLimit
    {
        public string RepeatLimitedString(string s, int repeatLimit)
        {
            int[] charFrequency = new int[26];
            foreach (char ch in s)
            {
                charFrequency[ch - 'a']++;
            }

            StringBuilder sb = new StringBuilder();
            //Keep count of previous characters and number of times same character is taken to maintain threshold of repeatLimit
            int prev = -1;
            int prevCharCount = 0;
            //Loop through each character of string
            for (int i = 0; i < s.Length; i++)
            {
                int idx = 25;
                //Find largest characters left in the string as we are returning lexicographically largest string possible
                while (charFrequency[idx] != 0)
                {
                    idx--;
                }

                //If current character can still be considered for the result string and either not equal to prev character or character taken previously can still be repeated again
                if (idx != prev || prevCharCount != repeatLimit)
                {
                    //Pick current character and reduce character frequency by 1 each time character is added to result
                    charFrequency[idx]--;


                    if (idx == prev)
                    {
                        //If prev char can still be taken amd increase count of this character
                        prevCharCount++;
                    }
                    else
                    {
                        //If no character is picked, pick current character and assign it to prev for next iteration
                        prev = idx;
                        //Set character pick count to 1 as we picked current character first time
                        prevCharCount = 1;
                    }

                    sb.Append((char)('a' + idx));
                }
                else
                {
                    //Can't take same character picked last time and have to pick a new character
                    int idxRemaining = idx - 1;
                    //Find and pick second largest character available
                    while (idxRemaining > 0)
                    {
                        if (charFrequency[idxRemaining] > 0)
                        {
                            break;
                        }
                        else idxRemaining--;
                    }

                    if (idxRemaining > 0)
                    {
                        prev = idxRemaining;
                        prevCharCount = 1;
                        charFrequency[idxRemaining]--;
                        sb.Append((char)('a' + idxRemaining));
                    }
                }
            }

            return sb.ToString();
        }
    }
}
