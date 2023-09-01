using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*@author Andrew Black, @since 9/1/23
 *@purpose: standard HelloWorld program that demostrates I know the very first steps of using a new language.
 */

namespace aBlack_HelloWorld
{
    internal class Program
    {
        private static int birthMonth = 9;
        private static string birthStone = "sapphire";

        //main method to display my name, plus a couple other methods I wrote for fun
        static void Main(string[] args)
        {

            //Console.WriteLine("Hello World!");
            Console.WriteLine("Andrew Black");

            ModifyBirthMonth();

            DoSomeLoopsAndPrint();

        }

        //this method changes the value of birthmonth
        private static void ModifyBirthMonth()
        {

            birthMonth *= birthMonth;
            birthMonth += birthMonth;

        }

        //this method demonstrates a simple for loop and prints some stuff
        private static void DoSomeLoopsAndPrint()
        {

            for(int i = 0; i < birthStone.Length; i++)
            {
                Console.WriteLine(birthStone[i]);
            }

            Console.WriteLine("is your birthMonth " + birthMonth + "?");

        }
    }
}
