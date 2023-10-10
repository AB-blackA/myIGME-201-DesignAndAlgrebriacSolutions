using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Andrew Black
 * Purpose: Classes used for Vehicle references
 */
namespace Vehicles
{
    public abstract class Vehicle
    {
        public virtual void LoadPassenger()
        {

        }
    }

    public abstract class Car : Vehicle
    {

    }

    public interface PassengerCarrier
    {
        void LoadPassenger();
    }

    public interface HeavyLoadCarrier
    {

    }

    public abstract class Train
    {

    }

    public class Compact : Car, PassengerCarrier
    {

    }

    public class SUV : Car, PassengerCarrier
    {

    }

    public class Pickup: Car, PassengerCarrier, HeavyLoadCarrier
    {

    }

    public class PassengerTrain : Train, PassengerCarrier
    {
        void PassengerCarrier.LoadPassenger()
        {
            throw new NotImplementedException();
        }
    }

    public class FreightTrain : Train, HeavyLoadCarrier
    {

    }

    public class _424DoubleBogey : Train, HeavyLoadCarrier
    {

    }
}
