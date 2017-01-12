using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    
    
    static ulong getNextHighestPowerOfTwoIn64Bit( ulong value)
    {
        if( value == 0 )
        {
            return 1;    
        }
        // Divide by 2^k for consecutive doublings of k up to 32
        // The result is a number of 1 bits equal to the number
        // of bits in the original number, plus 1. That's the
        // next highest power of 2.
        
        value --;
        value |= (ulong)value >> 1;
        value |= (ulong)value >> 2;
        value |= (ulong)value >> 4;
        value |= (ulong)value >> 8;
        value |= (ulong)value >> 16;
        value |= (ulong)value >> 32;
        value ++;
        

        
        //  This has gone out of 64 range 
        if ( value == 0 )
        {
            value = (ulong)System.Numerics.BigInteger.Pow(2, 63);    
        }
        //  Else divide by 2 to get power of 2 that fits in the number
        else
        {
            value = value >> 1;    
        }
            
        //Console.WriteLine( "Value:{0}" , value );

        return value;
    }
    
    static bool isPowerOfTwo( ulong x )
    {
        return ( x & ( x - 1 ) ) == 0;    
    }
    
    static string determineWinner ( bool lousieTurn )
    {
        if( lousieTurn )
        {
            return "Louise";
        }
        else
        {
            return "Richard";
        }
    }
    
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int numInputs = Convert.ToInt32(Console.ReadLine());
        
        
        for( int iTestCase = 0; iTestCase < numInputs; iTestCase++)
        {
            ulong value = Convert.ToUInt64(Console.ReadLine());
        
            //  Lousie goes first so its true
            bool isLouiseTurn = false; 

            //Console.WriteLine( "{0} : {1}", numInputs, value);

            while( value > 0 && value != 1)
            {
                //  If value is a power of 2
                if( isPowerOfTwo( value ))
                {
                    //  Divide by 2
                    value = value / 2;
                }
                //  If not a power of 2
                else
                {
                    //  Find the closest power of 2 
                    ulong closestPowerOfTwo = getNextHighestPowerOfTwoIn64Bit(value);

                    if( closestPowerOfTwo == 1 )
                    {
                        value = 1;
                    }
                    else
                    {
                        value = value - closestPowerOfTwo;
                    }
                    
                    //string winner = determineWinner(isLouiseTurn);
                    //Console.WriteLine( "Value:{0} | Turn:{1} | Power{2}" , value, winner, closestPowerOfTwo );
                }
                isLouiseTurn = !isLouiseTurn;

            }
            string winner = determineWinner(isLouiseTurn);
            Console.WriteLine( winner );
        }
    }
}