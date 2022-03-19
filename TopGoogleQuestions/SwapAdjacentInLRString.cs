using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class SwapAdjacentInLRString
    {
        public bool CanTransform(string start, string end)
        {
            if (start.Length != end.Length)
                return false;

            if (start.Replace("X", "").Length != end.Replace("X", "").Length)
            {
                return false;
            }
            //Consider L and R as a person who can walk on Left and Right respectively
            //X is an empty space they can cross
            int startPt = 0;
            int endPt = 0;
            while (startPt < start.Length && endPt < end.Length)
            {
                //Start traversing both the strings until we find L/R
                while (startPt < start.Length && start[startPt] == 'X')
                {
                    startPt++;
                }

                while (endPt < end.Length && end[endPt] == 'X')
                {
                    endPt++;
                }

                if (startPt == start.Length && endPt == end.Length)
                {
                    return true;
                }

                if (startPt == start.Length || endPt == end.Length)
                {
                    return false;
                }

                if (start[startPt] != end[endPt])
                {
                    return false;
                }

                //If startPt < endPt and L is detected, it can only move left and not right
                if (start[startPt] == 'L' && startPt < endPt)
                {
                    return false;
                }

                //If startPt > endPt and R is detected, it can only move right and not left
                if (start[startPt] == 'R' && startPt > endPt)
                {
                    return false;
                }

                startPt++;
                endPt++;
            }

            return true;
        }
    }
}
