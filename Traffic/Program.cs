using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    /* Author: Andrew Black since 10/10/23
     * Purpose: Program tests some uses of objects including interfaces and abstract classes
     * Restrictions: Requires reference to previously created Vehicles.dll
     */
    internal class Program
    {
        /* Method: Main
         * Purpose: Create and Pass Vehicles to Function(s)
         * Restricions: None
         */
        static void Main(string[] args)
        {
            Compact co = new Compact();

            FreightTrain ft = new FreightTrain();

            AddPassenger(co);

            //was asked to try passing a non-passengerCarrier to this function. C# compiler outright rejected this
            //and wouldn't compile
            //AddPassenger(ft);

        }

        /* Method: AddPassenger
         * Purpose: Call the LoadPassenger function of any PassengerCarrier and print object to console via toString()
         * Restrictions: None
         */
        static void AddPassenger(PassengerCarrier pc)
        {
            pc.LoadPassenger();
            Console.WriteLine(pc.ToString());
        }
    }
}
