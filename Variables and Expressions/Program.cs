using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables_and_Expressions
{





    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = new int[4];

            Console.WriteLine("You will be asked to enter Four integer values one at a time.");
            Console.WriteLine("If an input is not accepted as an integer you will be asked to enter another");

            int i = 0;
            while (i<4)
            {
                Console.WriteLine("Please enter an integer value");
                try 
                {
                    numArr[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please try again");
                }

                if (numArr[i]!=0)
                {
                    i++;
                }
            }
            

            Console.WriteLine("Results: "+ numArr[0] + ", "+ numArr[1] +", " + numArr[2] + ", " + numArr[3]);
            
        }
    }
}
