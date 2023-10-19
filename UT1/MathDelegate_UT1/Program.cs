using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathDelegate_UT1
{
    /* Author: Andrew Black since 9/28/23
     * Purpose: Class demonstrates use of Delegates per Unit Test 1 Instructions
     * Limitations: None
     */
    internal class Program
    {
        /* Method: Round
         * Purpose: Return double d rounded to ith place
         * Limitations: None
         */
        private delegate double Round(double d, int i);


        /* Method: Main
         * Purpose: Demonstrate use of Delegate
         * Limitations: none
         */
        static void Main(string[] args)
        {

            //declare test variable and decimal cutoff
            double dTest = 5.123456789;
            int cutOff = 3;

            //declare delegate
            Round rounder = new Round(Math.Round);

            //declare result variable and set it to return of delegate
            double dResult = rounder(dTest, cutOff);

            //write results to console for testing
            Console.Write(dResult);

        }
    }
}
