using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Playground
{

    class Program { 

        static void Main(string[] args)
        {

            SortedList<string, DateTime> friendBirthdays = new SortedList<string, DateTime>();

            friendBirthdays.Add("Kyle", new DateTime(1996, 9, 7));
            friendBirthdays.Add("Meg", new DateTime(2000, 1, 1));
            friendBirthdays.Add("Greg", DateTime.Now);

            foreach(var kvp in friendBirthdays)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine(kvp.Value.ToString("MM/dd/yyyy"));
            }


        }
    }
   
}

