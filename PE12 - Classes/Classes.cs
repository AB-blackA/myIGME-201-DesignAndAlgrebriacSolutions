using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* @Author: Andrew Black since 10/12/23
 * @Purpose: Creation of various Classes to be used in a Main for Demonstration of Class Knowledge
 * @Limitations: none
 */
namespace Classes

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

        public virtual string GetString()
        {
            return this.myString;
        }


    }

    public class MyDerivedClass : MyClass
    {

        public MyDerivedClass(string myString) : base(myString) { }

        public override string GetString()
        {
            return base.GetString() + " (output from the derived class)";
        }


    }
}
