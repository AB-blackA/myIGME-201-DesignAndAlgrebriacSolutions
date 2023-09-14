using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*@author Andrew Black @since 9/14/23
 *@purpose: program allows the user to play a guessing game with the computer, trying to figure out what number the 
 *computer has randomly picked. Interface relays feedback to user to help guide them towards the answer.
 *@limitations: requires user input to function but otherwise no limits
 */

namespace PE6_Number_Game
{
    internal class Program
    {
        //@purpose main program does everything in this program by request. Sets values, gets user attempts, etc.
        //@limitations no limitations besides requiring user input
        static void Main(string[] args)
        {

            //min and max for possible number range
            const int minNum = 0;
            const int maxNum = 100;

            //max attempts to guess
            const int maxAttempts = 8;
            int userAttempts = 0;

            //required Random class to determine number
            Random rand = new Random();

            //number to be chosen
            int chosenNum = rand.Next(minNum, maxNum + 1);

            //current user chosen number, rewritten throughout program
            int userNum;

            //tell user how to use program
            Console.WriteLine("Welcome to this humble guessing game. I have thought of a number and it's up to you to try and guess" +
                " it. Write any integer (i.e., no decimals) into the console and I will keep track of your attempts and guide you " +
                "towards the correct answer. You have a maximum of " + maxAttempts + " attempts to guess correctly.");

            //blank lines outputted for neatness throughout program
            Console.WriteLine();

            Console.WriteLine("I'm ready when you are. Enter an integer and let's play!");
            Console.WriteLine();

            //loop controls how many guesses the user has left based on max attempts
            for(int i = 0; i < maxAttempts; i++)
            {
                //relay game state to player
                Console.WriteLine((maxAttempts - userAttempts) + " left to guess.");
                Console.WriteLine();

                //WRITE NUMBER FOR TESTING PURPOSES ONLY, COMMENT OUT OF ACTUALY PROGRAM
                //Console.WriteLine(chosenNum);

                //try catch to ensure they enter an int
                try
                {
                    userNum = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    //succesfully add one to user attempt if they entered an int
                    userAttempts++;

                    //set of elif statements for when their input is >, <, or = to the chosen number. 
                    //depending on result inform them of where their number lies in comparison
                    //to the actual number OR if they win inform them
                    if (userNum > chosenNum)
                    {
                        Console.WriteLine("Sorry, that number is GREATER than my number.");
                        Console.WriteLine();
                    }else if (userNum < chosenNum)
                    {
                        Console.WriteLine("Sorry, that number is LESSER than my number.");
                        Console.WriteLine();
                    }
                    //else implies =, inform user they won and tell them how many attempts they used, then break from loop 
                    //to end game
                    else
                    {
                        Console.WriteLine("Congratulations, that's my number! \n You finished in " + userAttempts + 
                            " attempts.");
                        Console.WriteLine();
                        break;
                    }

                }

                //catch any attempts to enter a non-int and inform user. also setback our for loop by 1 to compensate
                catch
                {
                    Console.WriteLine("Error! That is not an integer! Please retry.");

                    i--;
                }

                //if user has used all attempts, inform them they lose. sad.
                if(userAttempts >= maxAttempts)
                {
                    Console.WriteLine("Sorry, you've used all your attempts! The correct number was " + chosenNum);
                }
            }


        }
    }
}
