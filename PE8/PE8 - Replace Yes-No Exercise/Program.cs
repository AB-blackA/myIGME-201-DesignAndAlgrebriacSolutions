using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*@author: Andrew Black, since 9/19/23
 *@purpose: exercise program that transmutes part of string inputs by changing "no"s to "yes"s
 *@limitations: requires user input. doesn't look for exact case by case scenarios but instead looks for two letter combinations that at least include the word "no" to be replaced.
 *an example of this limitation can be seen in the word "nothing" getting replaced with "yesthing"
 */
namespace PE8_ReplaceNoWithYes
{
    static class Program
    {
        /*@purpose: main class contains entire program. holds variables, explains program to user, accepts user input, moddifies that input, and outputs to user
         *@limitations: requires user input
         */
        static void Main(string[] args)
        {

            //explain program to user and ask for input
            Console.WriteLine("Please enter a sentence and when you're happy press Enter. I will change some of the words.\n");

            //get user input and set it to variable string userIn
            string userIn = Console.ReadLine();

            //set variable moddedIn (modded input) to userIn and start looking for all the 'nos' we need to replace. 
            //by loose definition of the exercise instructions, the yes's don't need to match the way the no's were written by case. example, "NO" can be replaced with "yes"
            //do this for all cases
            string moddedIn = userIn.Replace("no", "yes");
            moddedIn = moddedIn.Replace("No", "yes");
            moddedIn = moddedIn.Replace("NO", "yes");
            moddedIn = moddedIn.Replace("nO", "yes");

            //print modified string to user. newline for neatness
            Console.WriteLine("\n{0}", moddedIn);



        }
    }
}
