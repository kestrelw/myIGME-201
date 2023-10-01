using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * 3.	Create a console application that uses a delegate to impersonate the Math.Round(double, int) function.  (Refer to "Math Delegate", "MemoryGame" or the attached "Number Sorter" application for delegate code examples).  1 extra point will be given for each additional implementation you can demonstrate using abbreviated notation, anonymous methods, the lambda operator and/or the generic template type. (Up to 5 extra points are available!)
 */
namespace DelegateRound
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: create a delegate replica of math.round
    // Restrictions: None
    class Program
    {
        // declare the delegate function variable type MyReadLine
        // which must match the function signature of the target function (Console.ReadLine())
        // the signature of Console.ReadLine() is: string ReadLine()
        delegate double MyRoundNum(double param1, int param2);
        static void Main(string[] args)
        {
            // create a variable of type MyReadLine which we can call like a function
            MyRoundNum myRoundNum;
            // contruct the delegate function reference to point to Console.ReadLine()
            myRoundNum = new MyRoundNum(Math.Round());
            // call our new function
            string sString = myRoundNum();
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

/*
using System;
namespace ReadLineDelegate
{
    class Program
    {
        // declare the delegate function variable type MyReadLine
        // which must match the function signature of the target function (Console.ReadLine())
        // the signature of Console.ReadLine() is: string ReadLine()
        delegate string MyReadLine( );

        static void Main(string[] args)
        {
            // create a variable of type MyReadLine which we can call like a function
            MyReadLine myReadLine;
            // contruct the delegate function reference to point to Console.ReadLine()
            myReadLine = new MyReadLine(Console.ReadLine);
            // call our new function
            string sString = myReadLine( );
        }
    }
}
*/