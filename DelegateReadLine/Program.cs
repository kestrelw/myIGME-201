using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateReadLine
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: create a delegate replica of readline
    // Restrictions: None
    static class Program
    {
        delegate string processDelegate();

        // Method: Main()
        // Purpose: create a delegate that accomplishes readline
        // Restrictions: Doesn't actually return user input but returns an empty string
        static void Main(string[] args)
        {
            processDelegate process;

            Console.WriteLine("enter an input");
            process = new processDelegate(ReadUserInput);
            Console.WriteLine("Result: {0}", process());
        }

        static string ReadUserInput()
        {
            return "";
        }

    }

}

/*
 * class Class1
 {
     delegate double processDelegate(double param1, double param2);
     static double Multiply(double param1, double param2)
     {
         return param1 * param2;
     }
     
     static double Divide(double param1, double param2)
     {
         return param1 / param2;
     }
     
     static void Main(string[] args)
     {
         processDelegate process;
         Console.WriteLine("Enter 2 numbers separated with a comma:");
         string input = Console.ReadLine();
         int commaPos = input.IndexOf(',');
         double param1 = Convert.ToDouble(input.Substring(0, commaPos));
         double param2 = Convert.ToDouble(input.Substring(commaPos + 1,input.Length - commaPos - 1));

         Console.WriteLine("Enter M to multiply or D to divide:");
         input = Console.ReadLine();
         if (input == "M")
            process = new processDelegate(Multiply);
         else
            process = new processDelegate(Divide);
         Console.WriteLine("Result: {0}", process(param1, param2));
     }
 }
*/