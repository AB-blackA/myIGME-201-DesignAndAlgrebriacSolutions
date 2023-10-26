using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Andrew Black since 10/25/23
 * UML Designer: Professor David Schuh since unknown
 * Purpose: Implementation of Various Classes from UML for Design Practice
 * Limitations: None
 */
namespace PE16___Classiest
{
    public interface IMood
    {
        string Mood
        {
            get;
        }
    }

    public class Waiter : IMood
    {
        public string name;

        public string Mood
        {
            get;
        }

        public void ServeCustomer(HotDrink cup) { }
    }

    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;

        public string Mood
        {
            get;
        }
    }

    public interface ITakeOrder
    {
        void TakeOrder();
    }

    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        public string size;
        private byte sugar;

        public Customer customer;

        public HotDrink() { }

        public HotDrink(string brand) { }

        public virtual void AddSugar(byte amount) { }

        public abstract void Steam();
    }

    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;

        public CupOfCoffee(string brand) : base(brand) { }

        public override void Steam()
        {
            throw new NotImplementedException();
        }

        public void TakeOrder() { }

    }

    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;

        public CupOfTea(bool customerIsWealthy) { }

        public override void Steam() { }

        public void TakeOrder() { }
    }

    public class CupOfCocoa: HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;

        private string source;

        public CupOfCocoa() : this(false) { }

        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand") { }

        public string Source
        {
            set { source = value; }
        }

        public override void Steam() { }

        public override void AddSugar(byte amount) { }

        public void TakeOrder() { }
    }
}
