using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*@author Andrew Black, with origin code from @Professor David Schuh
 *@since 9/2/23, origin date unknown
 *@purpose: starter code provided to me as an exercise in finding errors in code. I am taking original code, commenting it out, explaining the error(s),
 *and replacing it with code that works. You can differentiate between the original comments and my comments through how we commented them out:
 *Professor Schuh used '//' and I will be using '/*'. As a note, while I would normally advocate for putting comments above the code in question, due to 
 *the hard to read nature of this project I will instead be writing my comments BELOW the original code and comment */

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            /* int i = 0 
             * 
             *results in compiler error due to missing semicolon */
             
            int i = 0;


            string allNumbers = null;
            /*this string was moved to fix a compiler error*/

            // loop through the numbers 1 through 10
            /* for (i = 1; i < 10; ++i)
             *
             * this for loop results in a logic error, as if we wish to loop through the numbers 1 through 10 we would want our i
             * to stop when it's less than or equal to 10, or less than 11 */

            for (i = 1; i <= 10; ++i)
            {
                // declare string to hold all numbers
                /* string allNumbers = null;
                 * 
                 * While this statement is sound, later this string is trying to be referenced but can't due to its location. I went in more detail near the bottom
                 * of this program, but I essentially moved this to be declared in the main instead of in this loop to fix this. */
                

                // output explanation of calculation
                /* Console.Write(i + "/" + i - 1 + " = ");
                 * 
                 * this code results in a compiler error due to how the code is phrased. As it is, it attempts to add a number to a string and print it out
                 * due to the lack of parenthesis declaring that the "i-1" is supposed to be a seperate calculation from adding the i's to the string '"/"'.
                 * This is relevant because while you can add ints to strings (thus appending it to the string), you can't subtract them */

                Console.Write(i + "/" + (i - 1) + " = ");

                // output the calculation based on the numbers
                /* Console.WriteLine(i / (i - 1));
                 * 
                 * Currently this code results in a run-time error. As it is, since it's a math equation being calculated and printed, the program will attempt to print
                 * out the solution to the equation (1/0) on the first loop, which of course is undefined. There are a few ways to circumvent this but I used a try/catch statement
                 * in the event we are dividing by zero */

                try
                {
                    Console.WriteLine(i / (i - 1));
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("undefined");
                }

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                /* i = i + 1;
                 * 
                 * This code results in a logic error. We are already increasing the counter by one in our loop heading so there's no reason to increase it again.
                 * As it is, it throws off our desired result of outputing n/(n-1) for each number n from values 1-10
                 * The best solution is simply to remove it. */
            }

            // output all numbers which have been processed
            /* Console.WriteLine("These numbers have been processed: " allNumbers);
             * 
             * This code results in a compiler error as it is missing an importan '+' symbol between the original written string and allnumbers. Any seperate variable
             * or written string in the statement needs to be seperated by a '+' symbol.
             * IN ADDITION, currently allNumbers isn't even accessible by the main program since it was declared inside a loop inside the main program. To fix this, I retroactively
             * changed the decleration location of the allNumbers string. */

            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}

