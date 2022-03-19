using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class DailyTempratureMonoStack
    {
        public int[] DailyTemperatures(int[] temperatures)
        {   
            int[] result = new int[temperatures.Length];
            Array.Fill(result, 0);
            Stack<(int, int)> monoStack = new Stack<(int, int)>();

            for (int i = 0; i < temperatures.Length; i++)
            {
                while (monoStack.Count > 0 && temperatures[i] > monoStack.Peek().Item1)
                {
                    (int, int) stackEntry = monoStack.Pop();
                    result[stackEntry.Item2] = (i - stackEntry.Item2);
                }

                monoStack.Push(new(temperatures[i], i));
            }
            return result;

            Dictionary<int, int> map = new Dictionary<int, int>();
            var keys = map.Keys;
        }
    }
}
