using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number = 2;
            switch (number)
            {
                case 1:
                    Console.WriteLine("Just");
                    break;
                case 2:
                    goto default;
                    
                case 4:
                    Console.WriteLine("an");
                    break;

                default:
                    Console.WriteLine("example");
                    break;
            }


        }
    }
}
