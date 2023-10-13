using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Playground
{



    internal class Playground {     
    
        public static void Main(string[] args)
        {
            double[][] dArray = new double[2][]; //cannot implicitly convert int to double
            dArray[1] = new double[2];
            dArray[0] = new double[1]; //missing semicolon AND index out of bounds

            dArray[0][0] = 15;
            dArray[1][1] = 5.67; //index of out bounds

            for(int i = dArray.Length - 1; i >= 0; i--)
            {
                for(int  j = dArray[i].Length - 1; j >= 0; j--) { Console.WriteLine(dArray[i][j]); }
            }







        }

    }


}

