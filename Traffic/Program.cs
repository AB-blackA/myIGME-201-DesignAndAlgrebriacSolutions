using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Compact co = new Compact();

            FreightTrain ft = new FreightTrain();

            AddPassenger(co);
            //AddPassenger(ft);

        }

        static void AddPassenger(PassengerCarrier pc)
        {
            Console.WriteLine("I was called");
            pc.LoadPassenger();
            Console.WriteLine(pc.ToString());
        }
    }
}
