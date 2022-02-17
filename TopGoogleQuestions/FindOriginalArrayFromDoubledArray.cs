using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    //2007. Find Original Array From Doubled Array
    public class FindOriginalArrayFromDoubledArray
    {
        public int[] FindOriginalArray(int[] changed)
        {
            int[] orig = new int[changed.Length / 2];
            int i = 0;

            //Check if length of doubled array changed is of length > 2   
            if (changed.Length % 2 != 0)
            {
                return new int[] { };
            }

            //Sort original array => O(NlogN)
            Array.Sort(changed);

            //Set two pointers at the end of an array
            int start = changed.Length - 1;
            int end = changed.Length - 1;

            //Iterate through all the elements of changed
            while (i < orig.Length && start >= 0 && end >= 0)
            {
                if (changed[start] == -1)
                {
                    start--;
                    continue;
                }
                else if (changed[end] == -1)
                {
                    end--;
                    continue;
                }
                if (changed[end] % 2 != 0)
                {
                    return new int[] { };
                }

                if (changed[end] / 2 == changed[start])
                {
                    orig[i++] = changed[start];
                    changed[start] = -1;
                    changed[end] = -1;
                }
                else
                {
                    start--;
                }
            }

            if (i != orig.Length)
            {
                return new int[] { };
            }
            return orig;
        }
    }
}
