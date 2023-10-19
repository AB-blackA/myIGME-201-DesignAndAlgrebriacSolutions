using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE15___Classier
{
    public interface Ball
    {

        void ThrowBall();


    }

    public class BaseBall : Ball
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

    public class Football : Ball
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



    internal class Program
    {

        public static void Main(string[] args)
        {

            Football fb = new Football("grippy");
            BaseBall bb = new BaseBall("stitchy");


            fb.ThrowBall();
            bb.ThrowBall();





        }

        void MyMethod(Ball myObject)
        {
            myObject.ThrowBall();
        }

    }
}
