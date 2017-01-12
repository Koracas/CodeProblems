using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            //  Get the current input number
            int n = Convert.ToInt32(Console.ReadLine());

            //  Subtract 1 to eliminate the cases where 3, 5 or 15 match exactly.
            int number = n - 1;

            //  Get the number of times 3 goes into N
            long threeIntoN = number / 3;

            //  Get the number of times 5 goes into N
            long fiveIntoN = number / 5;

            //  Get the number of times 15 goes into N, because these are shared
            long fifteenIntoN = number / 15;

            //  On way is to 
            //	- Cycle through all values of 3 that are in N and add them to the sum.
            //	- Do the same for 5
            //	- Do the same for 15 but subtract out because they are repeats.
            //	This will provide a O( n + m + o ), where each is the number of times 3, 5 and 15 go into N respectivtly

            //	However this is geometric in nature: 
            //		3 * 1 + 3 * 2 + 3 * 3 + ... + 3 * n or 3 * ( 1 + 2 + 3 + ... + n)
            //		5 * 1 + 5 * 2 + 5 * 3 + ... + 5 * m or 5 * ( 1 + 2 + 3 + ... + m)
            //		15 * 1 + 15 * 2 + 15 * 3 + ... + 15 * o or 15 * ( 1 + 2 + 3 + ... + o)
            //	So we should be able to do 3*(n*( n+1)/2) + 5*(m*( m+1)/2) - 15*(o*( o+1)/2)
            //	See :: http://www.wikihow.com/Sum-the-Integers-from-1-to-N
            //	This make it O(1) , which will matter when numbers are very large.

            //  Calculate the total
            long sum = 3 * (threeIntoN * (threeIntoN + 1) / 2) + 5 * (fiveIntoN * (fiveIntoN + 1) / 2) - 15 * (fifteenIntoN * (fifteenIntoN + 1) / 2);

            Console.WriteLine(sum);
        }
    }
}
