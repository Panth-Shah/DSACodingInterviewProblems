using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class ReversePolishNotation
    {
        public int EvalRPN(string[] tokens)
        {
            Stack<int> stack = new Stack<int>();
            foreach (string ch in tokens)
            {
                if (ch == "+")
                {
                    stack.Push(stack.Pop() + stack.Pop());
                }
                else if (ch == "-")
                {
                    int val1 = stack.Pop();
                    int val2 = stack.Pop();
                    stack.Push(val2 - val1);
                }
                else if (ch == "*")
                {
                    stack.Push(stack.Pop() * stack.Pop());
                }
                else if (ch == "/")
                {
                    int val1 = stack.Pop();
                    int val2 = stack.Pop();
                    stack.Push(val2 / val1);
                }
                else
                {
                    stack.Push(int.Parse(ch));
                }
            }

            return stack.Pop();
        }
    }
}
