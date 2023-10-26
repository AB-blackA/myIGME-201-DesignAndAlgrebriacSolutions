using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private double openTime;
        private double closingTime;

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

        public double OpenTime
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

        public double CloseTime
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

        public Restaurant(string location, string cuisine, string name, double openTime, double closingTime)
        {
            this.location = location;
            this.cuisine = cuisine;
            this.name = name;
            this.openTime = openTime;
            this.closingTime = closingTime;
        }

        public virtual void DisplayInfo()
        {

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

    public class IndianGrill : Restaurant, IServing, IRestocking
    {
        public IndianGrill(string location, string cuisine, string name, double openTime, double closingTime) : base(location, cuisine, name, openTime, closingTime)
        {
        }

        public override void AnnounceHolidayTimes()
        {
            throw new NotImplementedException();
        }

        public Supply OrderBulk(string name)
        {
            throw new NotImplementedException();
        }

        public Food OrderProduce(string name)
        {
            throw new NotImplementedException();
        }

        public Food ServeFood()
        {
            throw new NotImplementedException();
        }

        public void TakeOrder(string orderInfo)
        {
            throw new NotImplementedException();
        }

        public void OpenBuffet() { }
    }

    public class TheRedFern : Restaurant, IServing, IRestocking
    {
        public TheRedFern(string location, string cuisine, string name, double openTime, double closingTime) : base(location, cuisine, name, openTime, closingTime)
        {
        }

        public override void AnnounceHolidayTimes()
        {
            throw new NotImplementedException();
        }

        public Supply OrderBulk(string name)
        {
            throw new NotImplementedException();
        }

        public Food OrderProduce(string name)
        {
            throw new NotImplementedException();
        }

        public Food ServeFood()
        {
            throw new NotImplementedException();
        }

        public void TakeOrder(string orderInfo)
        {
            throw new NotImplementedException();
        }

        public void HoldCharityEvent() { }
    }
}
