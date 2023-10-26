using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UT2___PhoneUML;

/* Author: Andrew Black since 10/26/23
 * Purpose: Creation of some "Phone" Classes per Practical Question in Unit Test 2
 * Limitations: Requires use of PhoneUML Library
 */
namespace UT2___Phones_Test
{
    internal class Program
    {
        /* Method: Main
         * Purpose: Make a Tardis and PhoneBooth object and pass them to a different function 
         * Limitations: none
         */
        static void Main(string[] args)
        {
            //create relevant Phone objects
            Tardis tardy = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();

            //send objects to UsePhone functions to use them
            UsePhone(tardy);
            UsePhone(phoneBooth);

        }

        /* Method: Main
         * Purpose: Call MakeCall and HangUp functions of passed objects. Non-Phones will be ignored
         * Limitations: none
         */
        static void UsePhone(object obj)
        {
            //try for any PhoneInterface object
            try
            {
                //make a PhoneInterface based off obj
                PhoneInterface phoneInterface = (PhoneInterface)obj;

                //call its methods
                phoneInterface.MakeCall();
                phoneInterface.HangUp();
            }
            //catch any non-PhoneInterface objects
            catch
            {
                //output to console issue
                Console.WriteLine("Passed object did not inherit from PhoneInterface");
            }
        }
    }
}
