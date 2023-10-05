using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Andrew Black, since 9/19/23
 * Purpose: Store the value of an equation with three variables into an array as per the instructions in Unit Test 1.
 * equations => z = 4y^3 + 2x^2 - 8x + 7
 * Limitations: none
 */
namespace PE8_3DArrayPractice
{
    static class Program
    {

        /* Method: Round
         * Purpose: Return double d rounded to ith place
         * Limitations: None
         */
        private delegate double Round(double d, int i);

        /* Method: Main
         * Purpose: Calculate and Store Function Values in 3D Array
         * Limitations: None
         */
        static void Main(string[] args)
        {
            //declare delegate 
            Round rounder = new Round(Math.Round);

            //min/starting values for x and y in our equation
            double xMin = 0;
            double yMin = -1;

            //max/ending values for x and y in our equation
            double xMax = 4;
            double yMax = 1;

            //declaration of equations used
            double dX;
            double dY;
            double dZ;

            //declaration of positions for array, starting at 0 for x
            //y must get assigned later during for loop so no need to instantiate now
            int xPosition = 0;
            int yPosition ;

            //decleration of decimal cutoffs for rounding
            int xyCutOff = 1;
            int zCutOff = 3;

            //incrementer for our x and y values as we begin to use loops.
            double incrementer = .1;

            //decleration of 3d array. sizes were chosen based off the following criteria i have not yet mentioned:
            //max value for x is 4 and for y is 1 (both inclusive), so with our incrementer of .1 that leaves 41 and 21 values to use
            //along with a value of 3 for the z variable as it is a 3d array
            double[,,] function = new double[41, 21, 3];

            //go through every value of x
            for( dX = xMin; dX <= xMax; dX += incrementer)
            {

                //round our x value to the cutoff
                dX = rounder(dX, xyCutOff);

                //reset yPosition (index position) for each iteration of our x-value
                yPosition = 0;

                for(dY = yMin; dY <= yMax; dY += incrementer)
                {
                    //round our y value to the cut off
                    dY = rounder(dY, xyCutOff);

                    //calculate our z value and round to cut off
                    dZ = (4 * (Math.Pow(dY,3))) + (2 * Math.Pow(dX, 2)) - (8 * dX) + 7;
                    dZ = rounder(dZ, zCutOff);

                    //output dZ for testing purposes
                    //Console.WriteLine(dZ);

                    //store all x,y,z values for the current array element
                    function[xPosition, yPosition, 0] = dX;
                    function[xPosition, yPosition, 1] = dY;
                    function[xPosition, yPosition, 2] = dZ;

                    //increment y position
                    yPosition++;
                    
                }

                //increment x position
                xPosition++;
            }
            
                

            
        }
    }
}