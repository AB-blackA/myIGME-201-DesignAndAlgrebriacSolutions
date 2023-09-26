using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Class Program
 * Author: Andrew Black, since 9/22/23
 * Purpose: Using Delegates
 * Restrictions: None
 */
namespace PE9_DelegateReadLine
{
    static class Program
    {
        // Method: SeudoreadLine
        // Purpose: Return String via Delegate
        // Restrictions: None
        private delegate string SeudoReadLine();

        /* Method: ReturnUserIn
         * Purpose: Impersonate ReadLine()
         * Restrictions: None
         */
        private static string ReturnUserIn()
        {
            return Console.ReadLine();
        }

        /* Method: Main
         * Purpose: Impersonate ReadLine() using Delegate
         * Restrictions: None
         */
        static void Main(string[] args)
        {
            //declare delegate
            SeudoReadLine readIn = new SeudoReadLine(ReturnUserIn);

            //declare userIn and set equal to delegate
            string userIn = readIn();

            //write userIn to console to ensure functions working correctly
            Console.WriteLine(userIn.ToString());

        }
    }
}
