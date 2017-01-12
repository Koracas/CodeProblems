/*
 *  Check if Palindrome
 */
    static bool IsPalindrome( string input )
    {
        //  get length
        int length = input.Length;
        
        //  Used for debugging
        bool test = false;
        
        //  Loop through to the mid point to check
        for( int iChar = 0 ; iChar < (length/2); iChar++ )
        {
            //  --- DEBUG 
            if(test) Console.WriteLine( "{0} vs {1} ", input[iChar] , input[length - iChar - 1]);
            
            //  If the current letter and its corresponding counter part dont match
            if( input[iChar] != input[length - iChar - 1])
            {
                // No Palindrome
                return false;    
            }
        }
        return true;
    }
   
    static int CheckMinPalindrome( string input )
    {
        //  get length
        int length = input.Length;
        
        //  Used for debugging
        bool test = false;
                
        //  Go through character by character to see if its a Palindrome 
        for( int iChar = 0 ; iChar < length; iChar++ )
        {
            //  Generate substring for checking
            string subString = input.Substring( iChar , length - iChar );
            
            //  See if this is a Palindrome
            bool isMatch = IsPalindrome(  subString );

            //  --- DEBUG 
            if(test) Console.WriteLine( "{0} {1}", subString , isMatch);
            
            //  There is a Palimdrome here
            if( isMatch )
            {
                // Return where the Palindrome starts
                return iChar; 
            }
        }
        
        //  Went through everything and no luck finding a Palindrome so return length
        return length;
    }
/*
 * Complete the function below.
 */
    static string MakePalindrome(string pInput) {
        //  final palindrome
        string finalAnswer = pInput;
        
        //  Used for debugging
        bool test = false;
        
        //  Get the char index where an internal palindrome might start
        int minPalindromeIndex = CheckMinPalindrome(pInput);

        //  --- DEBUG     
        if (test)Console.WriteLine(minPalindromeIndex);
        
        //  If it is the first letter, GREAT! already done
        if( minPalindromeIndex == 0 )
        {
            //  Return answer
            return finalAnswer;
        }
        //  Else we need to do some work...
        else
        {
            // Minus 1 as we want the char before where the palindrome starts..
            minPalindromeIndex --;    

            //  Loop through the phrase and append accrodingly
            for( int iRevChar = minPalindromeIndex; iRevChar >= 0; iRevChar -- )
            {     
                //  Append char
                finalAnswer += pInput[iRevChar];    
            }
            
            //  Return the newly minted Palidrome
            return finalAnswer;
        }
    }

