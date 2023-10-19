using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryMethod_UT1
{
    /* Author: Andrew Black
     * Purpose: Sequel to SalaryMethod_UT1, Include Structure in Program per Instructions from Unit Test 1
     * Limitations: none
     */
    internal class Program
    {
        struct Employee
        {
            public string name;
            public double salary;

        }        
            
        

        /* Method: Main
         * Purpose: Holds Employee Struct and sets its Variables and Congratulate User If They Get A Raise
         * Limitations: None
         */
        static void Main(string[] args)
        {

            //declare Employee struct and set its salary
            Employee emp;
            emp.salary = 30000;

            //ask employee for name and set their entry to emp.name
            Console.WriteLine("What is your name?");
            emp.name = Console.ReadLine();

            //determine if they get a raise by GiveRaise function. If so, display their new salary
            if (GiveRaise(ref emp))
            {
                Console.WriteLine("Congratulations on your riase! Your salaray is now: ${0}", emp.salary);
            }


        }

        /* Method: Main
         * Purpose: Determine if Salary should be raised. Raises value of emp.salary from passing of Employee struct reference if true
         * otherwise returns false
         * Limitations: none
         */
        static bool GiveRaise(ref Employee e)
        {

            //raise is determined if their name is equal to my name. If so, raise their salary and return true. 
            if (e.name == "Andrew Black")
            {
                e.salary += 19999.99;
                return true;
            }

            //if no raise return false
            return false;
        }
    }
}