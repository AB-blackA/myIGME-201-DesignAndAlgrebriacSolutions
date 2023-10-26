using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UT2___DiningClass;

/* Author: Andrew Black
 * Purpose: Implementation of self-created Dining Class for Practical Question on Unit Test 2
 * Limitations: Requires use of DiningClass library
 */
namespace UT2___DiningCreations
{
    internal class Program
    {
        //public instances of interface objects to be used in later function
        public static IServing myIServe;
        public static IRestocking myIRestocker;

        /* Method: Main
         * Purpose: Create various Restaurants and Send to Method(s)
         * Limitations: none
         */
        static void Main(string[] args)
        {

            //create two restaurants
            //The Red Fern is where I work irl! 
            IndianRestaurant numberOneIndian = new IndianRestaurant("1 Oxford Street, Rochester NY, 14607", "South Indian", "Number One Indian", "9:00 am", "10:00 pm");
            HumbleVeganRestaurant theRedFern = new HumbleVeganRestaurant("283 Oxford Street, Rochester NY, 14607", "Vegan Comfort", "The Red Fern", "9:00 am", "11:00 pm");

            //send to MyMethod to have their various methods be called upon
            MyMethod(numberOneIndian);
            MyMethod(theRedFern);

        }

        /* Method: MyMethod
         * Purpose: Accept objects and test if they're Restaurants. If so, call some of their methods
         * Limitations: None
         */
        static void MyMethod(object obj)
        {
            //try to ensure we're getting passed a restaurant
            try
            {
                //create a Restraurant from the object
                Restaurant restaurant = (Restaurant)obj;

                //blank spaces output to console throughout program for neatness
                Console.WriteLine();
                
                //start calling methods.
                restaurant.AnnounceHolidayTimes();
                restaurant.DisplayInfo();
                Console.WriteLine();

                //if to ensure objects are of types that support interfaces to then call those interface methods
                if (obj.GetType() == typeof(HumbleVeganRestaurant) || obj.GetType() == typeof(IndianRestaurant))
                {
                    //set our prior made Interface instances to our object and call some of their methods
                    myIServe = (IServing)obj;
                    myIServe.ServeFood();

                    Console.WriteLine();

                    myIRestocker = (IRestocking)obj;
                    myIRestocker.OrderProduce("Basmatti Rice");
                }

            }
            //if passed object is not a restaurant, inform user
            catch
            {
                Console.WriteLine("Passed object is not a restaurant");
            }
        }
    }
}
