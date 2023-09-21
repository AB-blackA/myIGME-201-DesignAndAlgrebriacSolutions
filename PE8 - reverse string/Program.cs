using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*@author Andrew Black, since 9/19/23
 *@purpose exercise program that gets user input for a string and reverses it
 *@limitations requires user input to work
 */
namespace PE8_ReverseString
{
    static class Program
    {
        /*@purpose: all of program takes place in main method. stores values, informs user of intent, gets user input, reverses and outputs that reverse of input
         *@limitations: requires user to work
         */
        static void Main(string[] args)
        {
            //declare string vars. userIn for "user input" and userReverse for the reverse of userIn
            //only userReverse needs to be declared with an empty string
            string userIn;
            string userReverse = "";

            //declare program intent to user
            Console.WriteLine("Welcome to this humble program. Enter anything in the console and then press 'Enter' and I will output the reverse of what you entered.\n");

            //set userIn to readline. we accept anything here, no need for try/catch
            userIn = Console.ReadLine();

            //get length of userIn, to be used shortly
            int stringLength = userIn.Length;

            //for loop based on stringLength to iterate through userIn
            for(int i  = 0; i < stringLength; i++)
            {
                //add to userReverse from userIn index. 
                userReverse += userIn[stringLength - 1 - i];
            }

            //print to user
            Console.WriteLine("Reverse: {0}", userReverse);

        }
    }
}
