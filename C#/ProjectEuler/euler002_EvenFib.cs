using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            long n = Convert.ToInt64(Console.ReadLine());
            
            //  Values used to calc the Fibonacci
            long fibonacciValNext = 1;
            long fibonacciValPrev = 1;
            long fibonacciValTemp = 1;
            
            //  Var for the sum 
            long sum = 0;
            
            //  Generate the Fibonacci sequence
            while( fibonacciValNext < n ){
                fibonacciValTemp = fibonacciValNext;
                    
                fibonacciValNext= fibonacciValTemp + fibonacciValPrev;
                fibonacciValPrev = fibonacciValTemp;
                
                //  Next value is already bigger than N
                if( fibonacciValNext > n ){
                    break;
                }
                
                if(fibonacciValNext % 2 == 0 ){
                    sum += fibonacciValNext;
                }
            }
            Console.WriteLine(sum);

        }
    }
}
