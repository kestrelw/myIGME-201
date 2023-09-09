using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang_FPE4FlowControl
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: Logic table exercise?
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: recieve two user integer inputs that are not both over 10
        // Restrictions: None
        static void Main(string[] args)
        {
            int firstInput = -1;
            int secondInput = -1;
            bool firstGreaterThanTen = false;
            bool secondGreaterThanTen = false;
            bool bothGreaterThanTen = true;

            while(bothGreaterThanTen == true)
            {
                Console.WriteLine("Please input a positive integer");
                while (firstInput < 0)//untill num isn't -1
                {
                    try
                    {
                        firstInput = Convert.ToInt32(Console.ReadLine());//convert to int so it can check if positive
                    }
                    catch
                    {
                        Console.WriteLine("Invalid entry. Please input a positive integer");//repeat instructions if person incorrectly doing
                    }
                }
                Console.WriteLine("Please input a second positive integer");//getting a second int. same as previous few lines with 1 var change
                while (secondInput < 0)
                {
                    try
                    {
                        secondInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Invalid entry. Please input a positive integer");
                    }
                }

                Console.WriteLine("Inputs: "+firstInput+", "+secondInput);

                if (firstInput > 10)
                {
                    firstGreaterThanTen = true;
                }
                if (secondInput > 10)
                {
                    secondGreaterThanTen = true;
                }

                bothGreaterThanTen = firstGreaterThanTen && secondGreaterThanTen;
                Console.WriteLine("Results: " + (firstGreaterThanTen ^ secondGreaterThanTen));

                if (bothGreaterThanTen)
                {
                    Console.WriteLine("Both integers were greater than 10.\nPlease try again.");
                    firstInput = -1;
                    secondInput = -1;
                    firstGreaterThanTen = false;
                    secondGreaterThanTen = false;

                    Console.WriteLine();
                }


            }
            
            



        }
    }
}
