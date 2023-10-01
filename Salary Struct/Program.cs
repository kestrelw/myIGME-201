using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace salary
{
    struct Employee
    {
        public string sName;
        public double dSalary;
    }

    // Class: Program
    // Author: Melodie Wang
    // Purpose: tell a person their salary but better variable management
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: if their name matches mine they get a raise
        // Restrictions: None
        static void Main(string[] args)
        {
            string sName;
            Employee MyEmployee;

            MyEmployee.dSalary = 3000;
            MyEmployee.sName = "Melodie";

            while (true)
            {
                Console.Write("What is your name-> ");
                sName = Console.ReadLine();

                if (MyEmployee.sName.Length > 0)
                {
                    break;
                }
            }

            if (GiveRaise(MyEmployee))
            {
                Console.WriteLine("Congratulations on your raise. Your salary is now " + MyEmployee.dSalary);
            }
            else
            {
                Console.WriteLine("Your salary is " + MyEmployee.dSalary);
            }




        }





        private static bool GiveRaise(Employee user)
        {
            if (user.sName == "Melodie")
            {
                user.dSalary = user.dSalary + 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
