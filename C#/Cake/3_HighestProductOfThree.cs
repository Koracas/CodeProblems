using System;
using System.Collections.Generic; //    Needed for listusing System.Collections.Generic;

// To execute C#, please define "static void Main" on a class// named Solution.

class Solution
{
   
    public int highestProduct( List<int> curValuesArray )
    {
        int highestProduct = 1;
       
        int curLowestVal = 1;
        int curHighestVal = 1;
       
        int highestProductOfTwo = 1;
        int lowestProductOfTwo = 1;

       
        for ( int iVal = 0; iVal < curValuesArray.Count; iVal++)
        {
            int curVal = curValuesArray[iVal];
           
            //    Skip zeros
            if( curVal == 0 )
            {
                continue;
            }           
           
            //    If the cur value is greater than the cur highest
            if( curVal > curHighestVal )
            {
                //    set the new highest product
                highestProduct = highestProductOfTwo * curVal;
                //    set top highest value
                highestProductOfTwo = curHighestVal * curVal;           
                //    set new highest value
                curHighestVal = curVal;
            }
            if( curVal < curLowestVal )
            {
                //    set top lowest value
                lowestProductOfTwo = curLowestVal * curVal;           
                //    set new lowest value
                curLowestVal = curVal;
               
                //    IF the lowest two is greater than the highest two
                if ( lowestProductOfTwo > highestProductOfTwo )
                {
                    //    Highest product should account for this
                    highestProduct = lowestProductOfTwo * curHighestVal;
                }
            }
           
            Console.WriteLine( curValuesArray[iVal] );           
        }
       
        return highestProduct;
    }
   
    //    Main entry point
    static void Main(string[] args)
    {   
        //    Create list
        //List<int> values = new List<int>{ 5, 6, 7, 2 };
       
        List<int> values = new List<int>{ 5, 6, 0, 7, 2, 10, -2, -15 };
       
       
        Solution mySolution = new Solution();
       
        Console.WriteLine( "Highest Product :: " + mySolution.highestProduct( values ) );
       
    }}

