using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*author: Andrew Black, since 9/19/23
 *purpose: exercise that requested me to store the value of an equation in a 3d array. equations => z = 3y^2 + 2x - 1
 *limitations: self contained program so no limitations besides my own ability to understand how to use 3d arrays
 */
namespace PE8___3D_Array_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //min/starting values for x and y in our equation
            double xMin = -1;
            double yMin = 1;

            //declaration of equations used
            double x = 0;
            double y = 0;


            //incrementer for our x and y values as we begin to use loops.
            double incrementer = .1;

            //decleration of 3d array. sizes were chosen based off the following criteria i have not yet mentioned:
            //max value for x is 1 and for y is 4 (both inclusive), so with our incrementer of .1 that leaves 21 and 31 values to use
            //Math: (1 - (-1)) / .1 = 20, (4-1) / .1 = 30, add one for being inclusive
            //y will have many values but since it isn't being calculated it only needs one for its initalization
            double[,,] results = new double[1, 21, 31];

            //i chose incrementers for array position based on math terms: f for function (z), r for row (x), c for column (z)
            //this outside for loop is completely unnecessary because it only runs once, but it makes me feel better knowing it's there
            //representing the z so i'm leaving it in.
            for (int f = 0; f < results.GetLength(0); f++)
            {
                //loop through x positions
                for (int r = 0; r < results.GetLength(1); r++)
                {
                    //if/else for incrementing and resetting the x value. if we're not on the default run of our loop (i.e., r != 0, increment x)
                    if (r != 0)
                    {
                        x += incrementer;
                    }
                    //should we somehow return to r = 0 (impossible as coded), return to minvalue for x
                    else
                    {
                        x = xMin;
                    }

                    //loop through y positions
                    for (int c = 0; c < results.GetLength(2); c++)
                    {

                        //reset y value to min if this is first run of loop for int c, otherwise always increment after equation
                        if (c == 0)
                        {
                            y = yMin;
                        }

                        //store results of equation in proper index locations
                        results[f, r, c] = Math.Pow((3 * y), 2) + (2 * x) - 1;

                        //increment y value
                        y += incrementer;

                    }
                }
            }

            //this loop follows much of the above logic in terms of determining index.
            //prints out values so i can see them and determine if they make sense.
            //commented out to save memory

            /*for (int f = 0; f < results.GetLength(0); f++)
            {
                for (int r = 0; r < results.GetLength(1); r++)
                {
                    for (int c = 0; c < results.GetLength(2); c++)
                    {
                        try
                        {
                            Console.Write(results[f, r, c] + "\n");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(f + " " + r + " " + c);
                        }


                    }

                }
            }*/
        }
    }
}
