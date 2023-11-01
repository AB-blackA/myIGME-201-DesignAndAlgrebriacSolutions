using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Playground
{
    public sealed class Circus
    {
        public string name;

        public void Test()
        {
            Console.WriteLine("pies");
        }
    }

    class Program { 

        static void Main(string[] args)
        {
            Circus myCircus = new Circus();

            /*SortedList<string, DateTime> friendBirthdays = new SortedList<string, DateTime>();

            friendBirthdays.Add("Kyle", new DateTime(1996, 9, 7));
            friendBirthdays.Add("Meg", new DateTime(2000, 1, 1));
            friendBirthdays.Add("Greg", DateTime.Now);

            foreach(var kvp in friendBirthdays)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine(kvp.Value.ToString("MM/dd/yyyy"));
            }*/


        }
    }
   
}

