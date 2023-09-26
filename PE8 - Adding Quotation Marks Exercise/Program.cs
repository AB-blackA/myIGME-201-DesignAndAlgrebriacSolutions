using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*@author: Andrew Black, since 9/19/23
 *@purpose: exercise program that accepts a string from a user and adds double quotes to every word in that string before returning it to the user
 *@limitations: requires user input to work
 */
namespace PE8_QuotationAdder
{
    static class Program
    {
        /*purpose: main class does ever function. holds variables, writes to user, gathers user inputs, does processes on input, and prints to output
         *limitations: requires user input
         */
        static void Main(string[] args)
        {

            //explain program to user and how to use
            Console.WriteLine("Hello, please type in a sentence of any length and I will return it to you slightly modified with quotation marks.\n");

            //declare string arrays holding user input. userIn is the user response string and contains every word they input into the console that is seperated by a space (' ')
            //userModded is what will eventually be the modded version of userIn and is therefor set to its length. userModded doesn't have to be an array, a string is also fine
            string[] userIn = Console.ReadLine().Split(' ');
            string[] userModded = new string[userIn.Length];

            //iterate through the userIn array and add its values, modified, to userModded
            for(int i = 0; i < userIn.Length; i++)
            {
                //index for index add to userModded the value of userIn at i and add quotes around the input. 
                userModded[i] = "\"" + userIn[i] + "\"";

                //reprint to user their modded sentence
                Console.Write(userModded[i] + " ");
            } 
            


        }
    }
}
