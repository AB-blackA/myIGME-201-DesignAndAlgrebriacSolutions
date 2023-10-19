using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*@author Andrew Black
 *@since 9/6/23
 *@purpose: this program serves as an answer to a question in my IGME.201.01 classes homework. In essence, we are
 *accepting some ints via input from a user and multiplying them all together and outputting that multiplication product*/

namespace VarsExpressionsQuestion5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declaration of userNumbers to hold user input
            int userNo1 = 0;
            int userNo2 = 0;
            int userNo3 = 0;
            int userNo4 = 0;

            //constant to determine how many loops of asking the user we want to do later
            const int UserNumsReq = 4;  

            //decleration to user about what this program will do for them
            Console.WriteLine("Hello! If you could, please insert four integers for us to multiply together. We'll give you the result at the end." +
                " Please, just one number at a time!");

            //empty lines outputted for neatness ocassionally throughout program
            Console.WriteLine();

            //loops that will ask the user for four integers
            for(int i = 0; i < UserNumsReq; i++)
            {

                //display how many ints are still needed while asking for user input
                Console.WriteLine("Okay, give us an integer. Integers needed still : " + (UserNumsReq-i));

                //try/catch incase user doesn't put in an int, so we can loop back and ask again while meeting program conditions
                try
                {
                    //switch case based off i's current value to correspond to the user's numbers
                    switch (i) {
                        case 0:
                            userNo1 = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 1:
                            userNo2 = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 2:
                            userNo3 = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            userNo4 = Convert.ToInt32(Console.ReadLine());
                            break;
                    }
                    
                }
                //if user didn't enter an int, use this catch
                catch
                {
                    //inform user of error then set i back one to keep loop in tact
                    Console.WriteLine("Sorry, that's not a number! Please try again");
                    i--;
                }
            }

            Console.WriteLine();

            //end result outputted to user
            Console.WriteLine("The product of all the numbers you entered is " + (userNo1 * userNo2 * userNo3 * userNo4));


        }
    }
}
