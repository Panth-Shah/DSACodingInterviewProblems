using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    //Imagine an infinite sentence that are concatenated by words from the given sentence, infiStr.We want to cut the infiStr properly and put a piece at each row of the screen.
    //We maintain a pointer ptr.The ptr points to a position at infiStr, where next row will start.Cutting the infiStr and putting a piece at a row can be simulated as advancing the pointer by cols positions.
    //After advancing the pointer, if ptr points to a space, it means the piece can fit in row perfectly. If ptr points to the middle of a word, we must retreat the pointer to the beginning of the word, because a word cannot be split into two lines.
    public class SentenceScreenFitting
    {
        public int wordsTyping(String[] sentence, int rows, int cols)
        {
            string s = string.Join(" ", sentence) + " ";
            int len = s.Length, count = 0;
            int[] map = new int[len];
            System.Console.WriteLine(s);
            for (int i = 1; i < len; ++i)
            {
                map[i] = s[i] == ' ' ? 1 : map[i - 1] - 1;
                System.Console.WriteLine("Index" + " " + i + " " + "Map Value" + " " + map[i]);
            }
            for (int i = 0; i < rows; ++i)
            {
                System.Console.WriteLine("---------------------------------------------------");
                System.Console.WriteLine($"Count = {count} += cols = {cols}");
                count += cols;
                System.Console.WriteLine($"Count = {count}");
                System.Console.WriteLine($"Map Index = {count} % {len} = {count % len}");
                System.Console.WriteLine($"Map Value = map[ {count} % {len} ] = {map[count % len]}");
                System.Console.WriteLine($"Count = {count} += Map Value = map[{count} % {len}] = {map[count % len]}");
                count += map[count % len];
                System.Console.WriteLine($"Count = {count}");
                System.Console.WriteLine("---------------------------------------------------");
            }
            System.Console.WriteLine($"Result = {count} / {len} = {count / len}");
            System.Console.ReadLine();
            return count / len;
        }
    }
}