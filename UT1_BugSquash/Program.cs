using System;

/* Author: Uknown, modified by Andrew Black since 9/28/23
 * Purpose: Unit Test 1 code review. Comment on any errors in provided code.
 * Limitations: none
 */
namespace UT1_BugSquash
{
    class Program
    {
        // not an error but method header is incomplete 
        // Method: ORIGINAL COMMENT: Calculate x^y for y > 0 using a recursive function
        // Limitations: none
        static void Main(string[] args)
        {
            string sNumber;
            int nX;

            //missing semicolon
            //int nY
            int nY;
            int nAnswer;

            //compiler error
            //missing quotations in WriteLine function
            //Console.WriteLine(This program calculates x ^ y.);
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");

                //compiler error
                //causes an error in the do/while statement. Console.Readline() needs to have its return string set to a variable for the 
                //while part of our code block.
                //Console.Readline()
                sNumber = Console.ReadLine();

                //actual erorr would be marked here but fixed above
            } while (!int.TryParse(sNumber, out nX));

            do
            {
                //logic error?
                //one could argue that, since we're accounting for the number 0 in our recursive method later,
                //that a positive whole number is misleading as 0 is neither negative or positive. 
                //Console.Write("Enter a positive whole number for y: ");
                Console.Write("Enter a positive whole number (or zero) for y: ");

                sNumber = Console.ReadLine();

                //logic error AND runtimer error in while statement
                //we want to keep going while our TryParse is false AND we want our out to be set to nY, 
                //not nX again. In addition, we want a positive number but don't check for it which will cause
                //a stack overflow error later if it slips through
            } //while (int.TryParse(sNumber, out nX));
            while( (!int.TryParse(sNumber,out nY)) || nY < 0 );

            
            //compute the exponent of the number using a recursive function
            nAnswer = Power(nX, nY);

            //logic error
            //what we're writing to our user is just junk. Presumambly the original writer of this code
            //is trying to use a formatted string
            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            Console.WriteLine("{0}^{1} = {2}", nX, nY, nAnswer);
        }

        //added comment header
        //Method: Recursively returns the result of an int raised to an exponent
        //Limitations: none
        static int Power(int nBase, int nExponent)
        {
            //compiler warning
            //following ints don't need to be assigned.
            //technically not an error though so i'm not commenting them out
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                //logic error
                //returnVal should be = 1, not = 0 in the case our exponent is 0
                // ORIGINAL COMMENT: return the base case and do not recurse
                //returnVal = 0;
                returnVal = 1;
                
            }
            else
            {
                //runtime error
                //use of recursive function leads to stackoverflow due to misuse of addition instead of subtraction in statement.
                // ORIGINAL COMMENT: compute the subsequent values using nExponent-1 to eventually reach the base case
                //nextVal = Power(nBase, nExponent + 1);
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //compiler error
            //returnval is never actually returned. Being identified as "returnVal" is not enough to return an integer!
            //returnVal
            return returnVal;
        }
    }
}

