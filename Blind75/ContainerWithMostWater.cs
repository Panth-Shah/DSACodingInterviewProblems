using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blind75
{
    public class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            //Here, we need to obtained maximum area formed between the lines which is limited by the height of the shorter line
            //Farther the lines are, more the distance is
            //This approch can be best solved using two pointer approach
            //Start pointer will start from the first line and end will point to last line
            //We will start to calculate area between two external most lines
            //We need to consider the area between the lines of larger lengths to maximize the area
            //We will need to move from shorter line to longer line despite the reduction in the width.

            int maxArea = 0, left = 0, right = height.Length - 1;
            while (left < right)
            {
                //Calculate Height and Widge of the container formed between left and right lines
                int containerWidth = right - left;
                int containerHeight = Math.Min(height[left], height[right]);

                //Calculate maxArea formed with a prior combination and between current lines
                maxArea = Math.Max(maxArea, containerHeight * containerWidth);

                //Move pointer from the line which has lower height than the other
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            return maxArea;
        }
    }
}
