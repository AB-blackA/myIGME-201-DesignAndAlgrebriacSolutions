using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*@author Andrew Black, original program by Karli Watson
 *@since unknown, starter code provided 9/7/23, modified by Andrew 9/7/23
 *@purpose: As part of an exercise I am taking code that uses the'Mandelbrot' application from Beginning C# and modifying it to allow
 *users to set their own limits for the images the application makes. In essence, using some complex math, this application makes
 *randomly generated images using characters by outputting them to the console via mathematics.*/

namespace Mandelbrot
{

    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>


        //some variables declared here to be accessed in methods other than main
        static double realCoordUpper = 0;
        static double realCoordLower = 0;
        static double imagCoordUpper = 0;
        static double imagCoordLower = 0;

        [STAThread]
        static void Main(string[] args)
        {

            //these will be used in calculating. basically they're holders for x and y values
            double imagCoord;
            double realCoord;

            //determined constants for iterations in later loop
            const double ImagCoordIterations = 48;
            const double RealCoordIterations = 80;

            ReadIntro();

            GatherImagCoords();

            GatherRealCoords();

            double imagIncrements = GetIncrementVal(imagCoordLower, imagCoordUpper, ImagCoordIterations);
            double realIncrements = GetIncrementVal(realCoordLower, realCoordUpper, RealCoordIterations);


            //main program, slightly modified to use user input
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;
            for (imagCoord = imagCoordUpper; imagCoord >= imagCoordLower; imagCoord -= imagIncrements)
            {
                for (realCoord = realCoordLower; realCoord <= realCoordUpper; realCoord += realIncrements)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }

        //take three doubles: lower bound, upper bound, and iterations, and return the incremental value we want based off
        //how many iterations are determined to be needed (iterations are constants)
        private static double GetIncrementVal(double lower, double upper, double iterations)
        {
            if(lower < 0 && upper < 0){
                return (Math.Abs(upper - lower) / iterations);
            }else{
                return (Math.Abs(lower - upper) / iterations);
            }
      }

        //get the rool coordinates from the user
        private static void GatherRealCoords()
        {
            Console.WriteLine();
            Console.WriteLine("Okay, now we need some real coordinates from you. We need a lower then an upper bound. By default the values are -.6 and 1.77. " +
                "A lower bound that is negative and a higher bound that is positive within a smaller range tends to yield best results");

            for (int i = 1; i < 3; i++)
            {
                if (i == 1)
                {
                    //catch any attempts to not put in a double, and set back our loop counter to compensate
                    try
                    {
                        Console.WriteLine("What would you like your lower bound to be?");
                        realCoordLower = Double.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error! Coordinate must be a double! Please try again");
                        Console.WriteLine();
                        i--;
                    }
                }
                else
                {
                    //catch any attempts to not put in a double, and set back our loop counter to compensate
                    try
                    {
                        Console.WriteLine("What would you like your upper bound to be?");
                        realCoordUpper = Double.Parse(Console.ReadLine());

                        //catch any attemps to put a lowerbound as greater then the higher, reject entry, then set back loop
                        //to compensate
                        if (realCoordLower >= realCoordUpper)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Error! Upper bound must be higher than lower bound! Please try again");
                            i--;
                        }
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error! Coordinate must be a double! Please try again");
                        Console.WriteLine();
                        i--;
                    }
                }
            }
        }

        private static void GatherImagCoords()
        {
            Console.WriteLine("Okay, first we need some imaginary coordinates from you. We need a upper then an lower bound. By default the values are 1.2 and -1.2. " +
                "A higher bound that is positive and a lower bound that is negative within a smaller range tends to yields the best results.");

            for (int i = 1; i < 3; i++)
            {
                if (i == 1)
                {
                    //catch any attempts to not put in a double, and set back our loop counter to compensate
                    try
                    {
                        Console.WriteLine("What would you like your upperbound to be?");
                        imagCoordUpper = Double.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error! Coordinate must be a double! Please try again");
                        Console.WriteLine();
                        i--;
                    }
                }
                else
                {
                    //catch any attempts to not put in a double, and set back our loop counter to compensate
                    try
                    {
                        Console.WriteLine("What would you like your lowerbound to be?");
                        imagCoordLower = Double.Parse(Console.ReadLine());

                        //catch any attemps to put a lower bound as greater then the higher, reject entry, then set back loop
                        //to compensate
                        if (imagCoordLower >= imagCoordUpper)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Error! Lower bound must be lower than upper bound! Please try again");
                            i--;
                        }
                    }
                    catch
                    {
                        Console.WriteLine();
                        Console.WriteLine("Error! Coordinate must be a double! Please try again");
                        Console.WriteLine();
                        i--;
                    }
                }
            }
        }

        //describe program and how user can user program
        private static void ReadIntro()
        {
            Console.WriteLine("Welcome to Mandelbrot. Using inputs from you, we are going to randomly generate an image. Here's how it works:");
            Console.WriteLine("We are going to ask for two sets of numbers from you, both of size two. Using these numbers the program manipulates " +
                "how the image is formed. Essentially they modify some math equations that generate the image. Cool, huh?");

            //blank lines outputted for neatness frequently in program
            Console.WriteLine();
        }
    }
}