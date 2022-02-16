using System;

namespace Blind75
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertInterval insertInterval = new InsertInterval();
            insertInterval.Insert(new int[][] { new int[] { 1, 3}, new int[] { 6, 9 } }, new int[] { 2, 5});
        }
    }
}
