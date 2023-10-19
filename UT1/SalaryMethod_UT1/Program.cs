using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryMethod_UT1
{
    /* Author: Andrew Black
     * Purpose: Test Use of Methods via Instructions From Unit Test 1
     * Limitations: none
     */
    internal class Program
    {
        /* Method: Main
         * Purpose: Hold Variables related to Salaray and Congratulate User If They Get A Raise
         * Limitations: None
         */
        static void Main(string[] args)
        {
            //declare name and salary variables
            string sName;
            double dSalary = 30000;

            //ask user for name and set their entry to sName
            Console.WriteLine("What is your name?");
            sName = Console.ReadLine();

            //determine if they get a raise by GiveRaise function. If so, display their new salary
            if(GiveRaise(sName, ref dSalary))
            {
                Console.WriteLine("Congratulations on your riase! Your salaray is now: ${0}", dSalary);
            }


        }

        /* Method: Main
         * Purpose: Determine if Salary should be raised. Raises value of dSalary from passing of reference if true
         * otherwise returns false
         * Limitations: none
         */
        static bool GiveRaise(string name, ref double salary)
        {

            //raise is determined if their name is equal to my name. If so, raise their salary and return true. 
            if(name == "Andrew Black")
            {
                salary += 19999.99;
                return true;
            }

            //if no raise return false
            return false;
        }
    }
}
