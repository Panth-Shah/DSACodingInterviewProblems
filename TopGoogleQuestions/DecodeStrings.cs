using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class DecodeStrings
    {
        public string DecodeString(string s)
        {
            //In this problem, we need to decode string received in the form of k[string] where we have to decode string as string repeated k times. 2[b] = bb
            //We will use 2 stack approach to reduce time complaxity of pop and decode string when we detect "]"
            //countStack : Store all the integers k
            //stringStack: Store all the decoded strings

            //Initialzie stack to store k and string
            Stack<int> countStack = new Stack<int>();
            Stack<StringBuilder> stringStack = new Stack<StringBuilder>();

            StringBuilder currentString = new StringBuilder();
            int k = 0;
            //Iterate through entire string to extract k and string information between []
            foreach (char currentChar in s)
            {
                if (char.IsDigit(currentChar))
                {
                    k = k * 10 + currentChar - '0';
                }
                else if (currentChar == '[')
                {
                    //If we identify [ we start to push characters into stack

                    //Push number k to countStack
                    countStack.Push(k);

                    //Push currentString to stringStack
                    stringStack.Push(currentString);

                    //reset currentString and K
                    currentString = new StringBuilder();
                    k = 0;
                }
                else if (currentChar == ']')
                {
                    StringBuilder decodedString = stringStack.Pop();
                    for (int currentK = countStack.Pop(); currentK > 0; currentK--)
                    {
                        decodedString.Append(currentString);
                    }
                    currentString = decodedString;
                }
                else
                {
                    currentString.Append(currentChar);
                }
            }
            return currentString.ToString();
        }
    }
}
