using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incremental_3d_array
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: multi d array building and filling
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: fill x, y, and a formula for z into a multi dimensional array (printing for checking)
        // Restrictions: None
        static void Main(string[] args)
        {
            double[,,] incrArr = new double[30,1200, 3];
            int i = 0;
            int j = 0;

            for (double x = -1; x<= 1; x=x+.1)
            {

                Console.Write("{");


                for (double y = 1; y <= 4; y=y+.1)
                {
                    double z = 3.0*Math.Pow(3.0,2)+2.0*x - 1.0;

                    incrArr[j, i, 0] = x;
                    incrArr[j, i, 1] = y;
                    incrArr[j, i, 2] = z;

                    Console.Write("{"+incrArr[j, i, 0]+", "+incrArr[j, i, 1] + ", "+incrArr[j, i, 2]+ "}");
                    i++;
                }
                Console.WriteLine("}");
                j++;
            }

        }
    }
}
