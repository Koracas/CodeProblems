using System;
using System.Collections.Generic;

// To execute C#, please define "static void Main" on a class
// named Solution.

class Solution
{
    
    //
    //    FUNTION :: given an amount determine the number of possibilites of change.  This is a recurisve function.
    //        1) Try to see if the current denomiation will fit. (Stay above 0)
    //        2) If so take the remainder and try the current denominator again.
    //        3) If not return and increment the denominator and repeat.
    //        4) If == 0, you have reach an end of a possibility.
    //
    public int numberOfChangePossibilities( int[] denom, int amount, int iCurDenom)
    {
       //    var to hold the possiblity count
        int numPossible = 0;
        
        //    Reach the end of a possibility
        if( amount == 0 )
        {
            return 1;
        }
        
        //    This is a dead end
        if( amount < 0 )
        {
            return 0;
        }
        
        //    This is the last denomination... also dead end
        if( iCurDenom == denom.Length )
        {
            return 0;
        }
        
        int curDenom = denom[iCurDenom];
        
        Console.Write( "Checking ways to make {0} with denominations [" , amount);
        for( int i = iCurDenom; i < denom.Length; i++)
        {
            //    If the index is greater than the current denom put in a ,
            if( i > iCurDenom ) 
            {
                Console.Write(", ");
            }

            Console.Write( denom[i] );
        }
        Console.Write("]\n");

        //    While amount is still positive
        while( amount >= 0 )
        {

            numPossible += numberOfChangePossibilities( denom, amount, iCurDenom + 1);
            Console.WriteLine( "Amount Checked {0} , {1}" , amount , curDenom );

            amount -= curDenom;    

        }
        
        
        //    Return the possiblity
        return numPossible;
    }
    
    //
    //    MAIN
    //
    static void Main(string[] args)
    {
        //    List of denominations assume reverse sort
        int[] denomination = new int[] { 3,2,1 };
        
        //    Value to dissect
        int amount = 4;
        
        //    Declare and initilaize solution
        Solution mySolution = new Solution();
        
        //    Get the answer from the function call
        int answer = mySolution.numberOfChangePossibilities( denomination, amount, 0 );
        
        //    Call solution function
        Console.WriteLine( "The number of possibilities are: {0}" , answer );
    }
}
