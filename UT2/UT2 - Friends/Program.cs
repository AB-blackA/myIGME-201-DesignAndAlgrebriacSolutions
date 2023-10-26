using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Andrew Black since 10/26/23, started code provided by Professor David Schuh since unknown
 * Purpose: Tasked by Unit Test 2 to change Friend struct to a class and modify main code to maintain the same output as though there were a struct
 * Limitations: none
 */
namespace UT2___Friends
{
    /*struct Friend
    {
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;
    }*/

    public class Friend
    {
        private string name;
        private string greeting;
        private DateTime birthdate;
        private string address;

        public string Name
        {
            get 
            { 
                return this.name; 
            }
            set
            {
                this.name = value;
            }
        }

        public string Greeting
        {
            get
            {
                return this.greeting;
            }
            set
            {
                this.greeting = value;
            }
        }

        public DateTime Birthdate
        {
            get
            {
                return this.birthdate; 
            }
            set
            {
                this.birthdate = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public Friend(string name, string greeting, DateTime birthdate, string address)
        {
            this.name = name;
            this.greeting = greeting;
            this.birthdate = birthdate;
            this.address = address;
        }

        public Friend ShallowCopy()
        {
            return (Friend)this.MemberwiseClone();
        }
    }

    class Program
    {

        /* Method: Main
         * Purpose: Create Friend objects and use some of their fields
         * Limitations: none
         */
        static void Main(string[] args)
        {

            // create my friend Charlie Sheen
            Friend friend = new Friend("Charlie Sheen", "Dear Charlie", DateTime.Parse("1967-12-25"), "123 Any Street, NY NY 12202");

            //enemy to be constructed shortly
            Friend enemy;

            // ORIGINAL STRUCT CREATION BELOW
            // create my friend Charlie Sheen
            /*friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthdate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";*/

            //create enemy as shallowcopy of friend
            enemy = friend.ShallowCopy();

            // ORIGINAL STRUCT CREATION BELOW
            // now he has become my enemy
            //enemy = friend;


            // set the enemy greeting and address without changing the friend variable
            enemy.Greeting = "Sorry Charlie";
            enemy.Address = "Return to sender.  Address unknown.";
            // ORIGINAL STRUCT CREATION BELOW
            /*enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";*/

            //output to console greetings and addresses of enemy and friend
            Console.WriteLine($"{friend.Greeting} => {enemy.Greeting}");
            Console.WriteLine($"{friend.Address} => {enemy.Address}");

            // ORIGINAL OUTPUT BELOW
            /*Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");*/
        }
    }
}

