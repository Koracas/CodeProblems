using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution {
class Solution {
    static void Main(string[] args) {
        //  Grab the input
        String str = Console.ReadLine();
        //Console.WriteLine( str );

        //  Split the input by space
        String[] strArr = str.Split();

        //  Stack to do the calculation
        Stack<float> numberStack = new Stack<float>();

        //  Cycle through the input
        foreach ( string curChar in strArr )
        {
            float operand1 = 0;
            float operand2 = 0;
            float result = 0;
            
            //Console.WriteLine( curChar );

            
            switch( curChar )
            {
                case "+":                
                    //  Pop off tow operands
                    operand1 = numberStack.Pop();
                    operand2 = numberStack.Pop();
                    //  Do the operation
                    result = operand2 + operand1;
                
                    //Console.WriteLine( "Pop {0} + {1}, calc | Push {2} ", operand2 , operand1 , result);
                
                    //  Push back on the stack
                    numberStack.Push( result );
                
                    break;
                case "-":
                    //  Pop off tow operands
                    operand1 = numberStack.Pop();
                    operand2 = numberStack.Pop();
                    //  Do the operation
                    result = operand2 - operand1;
                    
                    //Console.WriteLine( "Pop {0} - {1}, calc | Push {2} ", operand2 , operand1 , result);
                
                    //  Push back on the stack
                    numberStack.Push( result );
                    break;
                case "/":
                    //  Pop off tow operands
                    operand1 = numberStack.Pop();
                    operand2 = numberStack.Pop();
                
                    if( operand1 == 0 )
                    {
                        result = 0;
                    }
                    else 
                    {
                        //  Do the operation
                        result = operand2 / operand1;
                    }
                    
                    
                    //Console.WriteLine( "Pop {0} / {1}, calc | Push {2} ", operand2 , operand1 , result);
                
                    //  Push back on the stack
                    numberStack.Push( result );
                    break;
                case "*":
                    //  Pop off tow operands
                    operand1 = numberStack.Pop();
                    operand2 = numberStack.Pop();
                    //  Do the operation
                    result = operand2 * operand1;
                    
                    //Console.WriteLine( "Pop {0} * {1}, calc | Push {2} ", operand2 , operand1 , result);
                
                    //  Push back on the stack
                    numberStack.Push( result );
                    break;
                default:
                    float value = 0;
                    bool clean = true;
                    try{
                        value = Convert.ToInt32(curChar);
                        numberStack.Push(value);
                        //Console.WriteLine( curChar + " pushed onto stack");
                    }
                    catch ( System.FormatException )
                    {
                        //  Do nothing cause it is bad input
                        //Console.WriteLine("bad input");
                    }
                    
                    break;
            }
        }
        
        Console.WriteLine( numberStack.Pop() );
       
       
        
        /* Enter your code here. Read input from STDIN. Print output to STDOUT */
    }
}
}