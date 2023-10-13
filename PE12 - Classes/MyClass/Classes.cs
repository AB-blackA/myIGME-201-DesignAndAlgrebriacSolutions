using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass
{
    public class MyClass
    {

        private string myString;

        public MyClass()
        {
            this.myString = string.Empty;
        }

        public MyClass(string myString)
        {
            this.myString = myString;
        }

        public string GetString()
        {
            return this.myString;
        }


    }

    public class MyDerivedClass : MyClass
    {

        public string GetString()
        {
            return base.GetString() + " (output from the derived class)";
        }


    }
}
