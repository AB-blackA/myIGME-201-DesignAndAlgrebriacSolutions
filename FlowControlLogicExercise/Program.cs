using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*@author Andrew Black
 *@since 9/7/23
 *@purpose: logical exercise that asks user for two numbers and displays them, but asks for two new ones if both are
 *greater than 10 (individually)*/

namespace FlowControlLogicExercise
{
    internal class Program
    {

        //variables described outside main method for access by other methods
        static double num1;
        static double num2;

        const double valueMax = 10;
        static void Main(string[] args)
        {
            ReadIntro();
            GetNumbers();
            ReadNumbers();
        }

        //read numbers to user
        private static void ReadNumbers()
        {
            Console.WriteLine("Your numbers were: " + num1 + " and " +  num2);
        }

        //get numbers from user
        private static void GetNumbers()
        {
            bool reject = true;
            do
            {
                for (int i = 1; i < 3; i++) {

                    if (i == 1) { // first iteration

                        //catch any attempts to insert non-numbers, reset counter for iterator if so
                        try
                        {
                            Console.WriteLine("Okay, give us the first number: ");
                            num1 = Double.Parse(Console.ReadLine());
                            Console.WriteLine();
                        }
                        catch
                        {
                            Console.WriteLine("Error, that's not a number!");
                            Console.WriteLine();
                            i--;
                        }
                    }

                    else { // second loop

                        //catch any attempts to insert non-numbers, reset counter for iterator if so
                        try
                        {
                            Console.WriteLine("Great, give us another number: ");
                            num2 = Double.Parse(Console.ReadLine());
                            Console.WriteLine();
                        }catch
                        {
                            Console.WriteLine("Error, that's not a number!");
                            Console.WriteLine();
                            i--;
                        }
                    }
                }

                //check if we reject the values
                reject = ((num1 > valueMax) && (num2 > valueMax));

                if (reject)
                {
                    Console.WriteLine("You picked two numbers with value greater than ten! We'll have to restart from the beginning.");
                    Console.WriteLine();
                }

            } while (reject);
        }

        //describe to user the application function
        private static void ReadIntro()
        {
            Console.WriteLine("Hello, I would like two numbers from you. If you give me two numbers over the value of ten, I " +
                "will reject them and ask you again. Otherwise I'll display them to you.");
            Console.WriteLine();
        }
    }
}
