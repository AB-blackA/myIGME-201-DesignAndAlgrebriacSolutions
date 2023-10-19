using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Andrew Black
* Purpose: Creation of Interface and Classes for Testing Purposes
* Limitations: None
*/
namespace PE15___Classier
{
     public interface IBall
    {
        void ThrowBall();
    }

    public class BaseBall : IBall
    {

        private string myBallName;

        public BaseBall(string s)
        {
            this.myBallName = s;
        }

        public virtual void ThrowBall()
        {
            Console.WriteLine("{0} was pitched.", this.myBallName);
        }
    }

    public class Football : IBall
    {
        private string myBallName;

        public Football(string s)
        {
            this.myBallName = s;
        }

        public virtual void ThrowBall()
        {
            Console.WriteLine("{0} was passed.", this.myBallName);
        }
    }

    internal static class Program
    {
        /* Method: Main
        * Purpose: Create Balls 
        * Limitations: none
        */
        public static void Main(string[] args)
        {

            Football fb = new Football("grippy");
            BaseBall bb = new BaseBall("stitchy");


            MyMethod(fb);
            MyMethod(bb);
        }

        /* Method: MyMethod (name picked from assignment constraints)
        * Purpose: Recieve and Throw Balls
        * Limitations: none
        */
        public static void MyMethod(IBall myObject)
        {
            myObject.ThrowBall();
        }
    }
}
