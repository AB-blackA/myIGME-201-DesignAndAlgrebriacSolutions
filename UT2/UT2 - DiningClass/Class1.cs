using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

/* Author: Andrew Black since 10/26/23
 * Purpose: Implementation of Self Created Dining Class per Unit Test 2 Practical Question
 * Limitations: none
 */
namespace UT2___DiningClass
{
    public abstract class Restaurant
    {
        private string location;
        private string cuisine;
        private string name;
        private string openTime;
        private string closingTime;

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        public string Cuisine 
        {
            get
            {
                return this.cuisine;
            }
            set
            {
                this.cuisine = value;
            }
        }

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

        public string OpenTime
        {
            get
            {
                return this.openTime;
            }
            set
            {
                this.openTime = value;
            }
        }

        public string CloseTime
        {
            get
            {
                return this.closingTime;
            }
            set
            {
                this.closingTime = value;
            }
        }

        public Restaurant(string location, string cuisine, string name, string openTime, string closingTime)
        {
            this.location = location;
            this.cuisine = cuisine;
            this.name = name;
            this.openTime = openTime;
            this.closingTime = closingTime;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine("\n{0}" +
                "\n{1}" +
                "\n{2}" +
                "\nOpening Hours: {3}" +
                "\nClosing Hours: {4}", this.name, this.cuisine, this.location, this.openTime, this.closingTime);
        }

        public abstract void AnnounceHolidayTimes();
    }

    public class Food
    {
        private string name;
        private int shelfLife;
        private string description;

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

        public int ShelfLife
        {
            get
            {
                return this.shelfLife;
            }
            set
            {
                this.shelfLife = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public Food(string name, int shelfLife, string description)
        {
            this.name = name;
            this.shelfLife = shelfLife;
            this.description = description;
        }
    }

    public class Supply
    {
        private string name;
        private string description;

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

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public Supply(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
    }

    public interface IServing
    {
        void TakeOrder(string orderInfo);

        Food ServeFood();
    }

    public interface IRestocking
    {
        Food OrderProduce(string name);
        Supply OrderBulk(string name);
    }

    public class IndianRestaurant : Restaurant, IServing, IRestocking
    {
        public IndianRestaurant(string location, string cuisine, string name, string openTime, string closingTime) : base(location, cuisine, name, openTime, closingTime)
        {
        }

        public override void AnnounceHolidayTimes()
        {
            Console.WriteLine("No upcoming holiday hours");
        }

        public Supply OrderBulk(string name)
        {
            Console.WriteLine("{0} added to order", name);
            return new Supply(name, "");
        }

        public Food OrderProduce(string name)
        {
            Console.WriteLine("Added {0} to order", name);
            return new Food(name, 0, "");
        }

        public Food ServeFood()
        {
            Console.WriteLine("Serving naan!");
            return new Food("generic food", 0, "");
           
        }

        public void TakeOrder(string orderInfo)
        {
            Console.WriteLine("Preparing {0}", orderInfo);
        }

        public void OpenBuffet() 
        {
            Console.WriteLine("Buffet's open!");
        }
    }

    public class HumbleVeganRestaurant : Restaurant, IServing, IRestocking
    {
        public HumbleVeganRestaurant(string location, string cuisine, string name, string openTime, string closingTime) : base(location, cuisine, name, openTime, closingTime)
        {
        }

        public override void AnnounceHolidayTimes()
        {
            Console.WriteLine("No upcoming holiday hours");
        }

        public Supply OrderBulk(string name)
        {
            Console.WriteLine("{0} added to order", name);
            return new Supply(name, "");
        }

        public Food OrderProduce(string name)
        {
            Console.WriteLine("Added {0} to order", name);
            return new Food(name, 0, "");
        }

        public Food ServeFood()
        {
            Console.WriteLine("Serving tofu!");
            return new Food("generic food", 0, "");

        }

        public void TakeOrder(string orderInfo)
        {
            Console.WriteLine("Preparing {0}", orderInfo);
        }

        public void HoldCharityEvent() 
        {
            Console.WriteLine("For this month only, 10% of all proceed go towards a humane animal society");
        }
    }
}
