using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Given the formula z = 4y3 + 2x2 - 8x + 7 implement a multidimensional array, the necessary for() loops and the code to store the values of z for the following ranges of x and y into the array:
•	-1 <= y <= 1 in 0.1 increments 
•	0 <= x <= 4 in 0.1 increments.
 */
namespace DelegateRound
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: create a delegate replica of math.round and uses on multi d array
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: impliments rounding on a multi array
        delegate double MyRoundNum(double param1, int param2);

        static void Main(string[] args)
        {

            // create a variable of type MyReadLine which we can call like a function
            MyRoundNum myRoundNum;
            // contruct the delegate function reference to point to Console.ReadLine()
            myRoundNum = new MyRoundNum(Math.Round);
            // call our new function

            double[,,] multiD = new double[21,861,3];

            int yArr = 0;
            int xArr = 0;

            for (double y = -1; y <= 1; y=y+.1)
            {
                for (double x = 0; x <=4; x=x +.1)
                {
                    double z = 4*Math.Pow(y,3) + 2*Math.Pow(x,2) - 8*x + 7;

                    multiD[yArr,xArr, 0] = myRoundNum(x,1);
                    multiD[yArr, xArr, 1] = myRoundNum(y, 1);
                    multiD[yArr, xArr, 2] = myRoundNum(z, 1);

                    

                    Console.WriteLine("x: "+ multiD[yArr, xArr, 0] + " y: "+ multiD[yArr, xArr, 1] + " z: "+ multiD[yArr, xArr, 2]);

                    xArr++;
                }    

                yArr++;
            }

        }
    }

}
