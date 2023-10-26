using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Playground
{

    public class Zoo
    {
        private string name;
        public string Name
        {
            get
            {
                //this.name = value;
                return this.name;
            }

            set
            {
                //return this.name;
                this.name = value;
            }
        }
    }

    public sealed class Circus
    {
        public string name;
    }





    static class Playground
    {

        static void Main(string[] args)
        {
            Circus c = new Circus();
            Console.WriteLine(c.name);
        }
    }
   
}

