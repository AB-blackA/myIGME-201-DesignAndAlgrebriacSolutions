using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int var1 = 11;
            int var2 = 1;

            bool b = (var1 > 10) ^ (var2 > 10);

            Console.WriteLine(b);
        }
    }
}
