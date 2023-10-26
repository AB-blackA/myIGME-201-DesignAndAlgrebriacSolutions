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

        public Circus(string i)
        {
            this.name = i;
        }
    }





    static class Playground
    {

        public class MyClass
        {
            public int myInt;

            public MyClass(int nVal)
            {
                this.myInt += nVal;
            }
        }

        public class MyClass2 : MyClass 
        {
            public MyClass2(int nVal) : base(nVal)
                {
                this.myInt = (this.myInt + 2) * 4;
                }
        }

        static void Main(string[] args)
        {/*
            Circus c = new Circus("ya boy");
            Console.WriteLine(c.name);*/

            MyClass2 m1 = new MyClass2(42);
            Console.WriteLine(m1.myInt);
        }
    }
   
}

