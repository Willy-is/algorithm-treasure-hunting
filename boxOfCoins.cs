using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace BoxOfCoins
{
    public class BoxOfCoins
    {
        public static int Solve(int[] boxes)
        {
            // Alex: Optimal Strategy to get the optimal case
            // Cindy: TotalValue - Alex ... sum of the rest of values
            int Alex = OptimalStrategy(boxes, boxes.Length);
            int Cindy = TotalValue(boxes, boxes.Length) - Alex;

            return Alex - Cindy;
        }
        
        private static int OptimalStrategy(int[] boxes, int n)
        {
            // P(i,j) = Maximum value that Alex can collect from i to j boxes.

            // 1st case> If Alex picked the leftmost box, Cindy picks [i+1] or [j] and wants to leave Alex with min
            // Alex: [i] + Min(P(i + 2,j), P(i + 1,j - 1))

            // 2nd case> If Alex picked the rightmost box, Cindy picks [i] or [j - 1] and wants to leave Alex with min
            // Alex: [j] + Min(P(i + 1,j - 1), P(i,j - 2))
            int [,] blob = new int[n,n];
            int gap, i, j, x, y, z;

            for (gap = 0; gap < n; gap++)
            {
                for (i = 0, j = gap; j < n; i++, j++)
                {
                    // x = P(i + 2,j)
                    x = ((i + 2) <= j) ? blob[i + 2,j] : 0;
                    // y = P(i + 1,j - 1)
                    y = ((i + 1) <= (j - 1)) ? blob[i + 1,j - 1] : 0;
                    // z = P(i,j - 2)
                    z = (i <= (j - 2)) ? blob[i,j - 2] : 0;
                    // Alex will compare 1st case and 2nd case to get the bigger value
                    blob[i,j] = Math.Max(boxes[i] + Math.Min(x,y), boxes[j] + Math.Min(y,z));
                }
            }
            // Boxes from 0 to (n - 1)
            return blob[0,n - 1];
        }

        private static int TotalValue(int[] boxes, int n)
        {
            // base case
            if (n < 1) return 0;
            // Recursion case: Sum(0 to (n - 1)) = Sum(0 to (n - 2)) + boxes[n - 1]
            else return boxes[n - 1] + TotalValue(boxes, n - 1);
        }
    }
}
