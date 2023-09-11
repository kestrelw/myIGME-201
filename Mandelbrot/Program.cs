using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;

            double userimagCordStart = -1.2, userimagCordEnd = 1.2;//yes these is intentionally switched
            double userrealCordStart = 1.77, userrealCordEnd = -.06;

            bool succesfulInput;

            while(userimagCordStart<userimagCordEnd)//makes sure start cord ends up higher then end
            {
                succesfulInput = false;

                Console.WriteLine("Please input a Start Y coordinate. Default value: 1.2");
                while (succesfulInput == false)
                {
                    try
                    {
                        userimagCordStart = Convert.ToDouble(Console.ReadLine());//convert to int so it can check if positive
                        succesfulInput = true;

                    }
                    catch
                    {
                        Console.WriteLine("Invalid entry. Please input a new Y start coordinate number");//repeat instructions if person incorrectly doing
                    }
                }

                succesfulInput = false;
                Console.WriteLine("Please input a End Y coordinate. Default value: -1.2");
                while (succesfulInput == false)
                {
                    try
                    {
                        userimagCordEnd = Convert.ToDouble(Console.ReadLine());//convert to int so it can check if positive
                        succesfulInput = true;

                    }
                    catch
                    {
                        Console.WriteLine("Invalid entry. Please input a new Y end coordinate number");//repeat instructions if person incorrectly doing
                    }
                }

                if(userimagCordStart < userimagCordEnd)
                {
                    Console.WriteLine("Y Start coordinate cannot be less than the Y End coordinate. Try Again.\n");
                }
            }

            while (userrealCordEnd < userrealCordStart)//makes sure end cord ends up higher then star
            {
                succesfulInput = false;

                Console.WriteLine("Please input a X Start coordinate. Default value: -0.6");
                while (succesfulInput == false)
                {
                    try
                    {
                        userrealCordStart = Convert.ToDouble(Console.ReadLine());//convert to int so it can check if positive
                        succesfulInput = true;

                    }
                    catch
                    {
                        Console.WriteLine("Invalid entry. Please input a new X start coordinate number");//repeat instructions if person incorrectly doing
                    }
                }

                succesfulInput = false;
                Console.WriteLine("Please input a X End coordinate. Default value: 1.77");
                while (succesfulInput == false)
                {
                    try
                    {
                        userrealCordEnd = Convert.ToDouble(Console.ReadLine());//convert to int so it can check if positive
                        succesfulInput = true;

                    }
                    catch
                    {
                        Console.WriteLine("Invalid entry. Please input a new X end coordinate number");//repeat instructions if person incorrectly doing
                    }
                }

                if (userrealCordEnd < userrealCordStart)
                {
                    Console.WriteLine("X Start coordinate cannot be less than the X End coordinate. Try Again.\n");
                }
            }


            for (imagCoord = userimagCordStart; imagCoord >= userimagCordEnd; imagCoord -= Math.Abs(userimagCordStart-userimagCordEnd)/48)
            {
                for (realCoord = userrealCordStart; realCoord <= userrealCordEnd; realCoord += Math.Abs(userrealCordStart - userrealCordEnd) / 80)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}