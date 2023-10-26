using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Andrew Black since 10/26/23
 * Purpose: Unit Test Practical Question regarding Use of SortedList
 * Limitations: None
 */
namespace UT2___Tuples
{
    internal class Program
    {
        /* Method: Main
         * Purpose: Create doubles to be used in SortedList, and apply doubles to Formula for Storing
         * Limitations: None
         */
        static void Main(string[] args)
        {
            //doubles representing variables in equation to be used
            double w;
            double y;
            double x;
            double z;
        
            //Sorted list containing "triple doubles" as a key and a double as a value
            SortedList<(double, double, double), double> results = new SortedList<(double, double, double), double>();

            //unused ints representing where in the "triple double" part of our sorted list our specific variables are stored
            /*int wIndex = 0;
            int yIndex = 1;
            int xIndex = 2;*/

            //incrementers for our variables in upcoming for loop, set by Unit Test 2 question
            //yxInc is the incrementer size for both the X and Y value
            double wInc = .2;
            double yxInc = .1;

            //loop through for each value of w, y, and x. 
            //original execution and condition variables set as defined by Unit Test 2 question
            for(w = -2; w <= 0; w+= wInc)
            {

                //unsure why but x would never reach the value 4 when condition set to x <= 4. Weird. 
                for (x = 0; x <= 4.1; x += yxInc)
                { 
                    for(y = -1; y <= 1; y += yxInc)
                    {
                        //equation based off provided formula, 4y^3 + 2x^2 - 8w + 7
                        z = (4 * Math.Pow(y, 3)) + (2 * Math.Pow(x, 2)) - (8 * w) + 7;

                        //results added to sorted list and rounded per instructions
                        results.Add((Math.Round(w, 1), Math.Round(x, 1), Math.Round(y, 1)), Math.Round(z,3));

                    }

                }

            }

            //commented out code to confirm results properly added

            /*foreach (var kvp in results)
            {
                Console.WriteLine("key: {0}, value: {1}", kvp.Key, kvp.Value);
            }*/

            //Console.Write(results.ContainsKey((0.0, 1.0, 4.0)));


        }
    }
}
