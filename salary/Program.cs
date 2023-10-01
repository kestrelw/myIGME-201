using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace salary
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: tell a person their salary
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: if their name matches mine they get a raise
        // Restrictions: None
        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;

            while (true)
            {
                Console.Write("What is your name-> ");
                sName = Console.ReadLine();

                if (sName.Length > 0)
                {
                    break;
                }
            }

            if (GiveRaise(sName, ref dSalary))
            {
                Console.WriteLine("Congratulations on your raise. Your salary is now " + dSalary);
            }
            else
            {
                Console.WriteLine("Your salary is " + dSalary);
            }




        }

        private static bool GiveRaise(string name, ref double salary)
        {
            if (name == "Melodie")
            {
                salary = salary + 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
