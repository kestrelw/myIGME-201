using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang_SquashTheBugs
{// Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            //int i = 0  //needs a ; at the end. Compile-time---------------------------------------------------------------------------------------
            int i = 0;//replacement
            string allNumbers = null;//replacement line

            // loop through the numbers 1 through 10
            //for ( i = 1; i < 10; ++i )//logical error. only runs up through 9---------------------------------------------------------------------
            for (i = 1; i <= 10; ++i)//replacement
            {
                // declare string to hold all numbers
                //string allNumbers = null;//needs to exist outside of for loop. compile time

                // output explanation of calculation
                //Console.Write(i + "/" + i - 1 + " = ");//compile-time. needs () so that it doesnt use the + for mathamatical addition------------
                Console.Write(i + "/" + (i - 1) + " = ");

                try//added
                {
                    // output the calculation based on the numbers
                    Console.WriteLine(i / (i-1));//run time error when divides by zero. needs try--------------------------------------------------
                }//I can't tell if it was suppose to output as decimals instead of nearly all outputing as 1 but since i don't see that in any comment i guess its fine?
                catch
                {
                    Console.WriteLine("error");//added resultfor /0
                }
                

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                //i = i + 1;//logic error. the for loop incriments the i already. by doing this it will jump by 2 each time------------------------
            }

            // output all numbers which have been processed
            //Console.WriteLine("These numbers have been processed: " allNumbers);//syntax error. missing "+"
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}
