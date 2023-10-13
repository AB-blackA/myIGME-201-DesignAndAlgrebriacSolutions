using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes; 

/* Author: Andrew Black since 10/12/23
 * Purpose: Main program demonstrates basic use of Classes
 * Limitations: requires access to Classes library
 */
namespace PE12___MyDerivedClass
{
    static class Program
    {
    
        /* Method: Main
         * Purpose: Create Derived class object and call on its parent's functions
         * Limitations: none
         */
        static void Main(string[] args)
        {
            //not specified if user should enter string they want. If necessary change is easy
            MyDerivedClass myDerivedClass = new MyDerivedClass("test");

            //output to console result of string. MyDerivedClass doesn't hold a string but its parent does
            //but it does override GetString and appends text declaring so. Application works if output
            //matches that expectation
            Console.WriteLine(myDerivedClass.GetString());


        }
    }
}
