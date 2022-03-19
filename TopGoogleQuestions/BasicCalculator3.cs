using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class BasicCalculator3
    {
        private Queue<char> stringContent = new Queue<char>();
        public int Calculate(string s)
        {
            foreach (char ch in s)
            {
                if (!Char.IsWhiteSpace(ch))
                {
                    stringContent.Enqueue(ch);
                }
            }

            stringContent.Enqueue('+');
            return calculator();
        }

        private int calculator()
        {
            char sign = '+';
            int operand = 0, sum = 0, prev = 0;

            while (stringContent.Count > 0)
            {
                char c = stringContent.Dequeue();
                if (c >= '0' && c <= '9')
                {
                    //Add current character number to previous number
                    //24 = 10*2 + 4
                    operand = 10 * operand + (c - '0');
                }
                else if (c == '(')
                {
                    operand = calculator();
                }
                else
                {
                    if (sign == '-')
                    {
                        sum += prev;
                        prev = -operand;
                        break;
                    }
                    else if (sign == '+')
                    {
                        sum += prev;
                        prev = operand;
                        break;
                    }
                    else if (sign == '*')
                    {
                        prev *= operand;
                        break;
                    }
                    else if (sign == '/')
                    {
                        prev /= operand;
                        break;
                    }

                    if (c == ')')
                    {
                        break;
                    }
                    sign = c;
                    operand = 0;
                }
            }

            return sum + prev;
        }
    }
}
