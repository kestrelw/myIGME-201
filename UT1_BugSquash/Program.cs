using System;

namespace UT1_BugSquash
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: find exponents of num rrecurse
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: Calculate x^y for y > 0 using a recursive function
        // Restrictions: None

        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //int nY - syntax error no ;
            int nY;
            int nAnswer;

            //Console.WriteLine(This program calculates x^y.); - syntax error - needs "" around stuff to print
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                //Console.ReadLine(); - compile error/runtime? - doesnt assign to anything so when sNumber called nothing there
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } //while (int.TryParse(sNumber, out nX)); logic error assigned to nX rather then nY or compile error since nY is then unassigned and problems
            while (!int.TryParse(sNumber, out nY));

            // compute the exponent of the number using a recursive function
            //nAnswer = Power(nX, nY);

            nAnswer = Power(nX, nY);

            //Console.WriteLine("{nX}^{nY} = {nAnswer}"); //logical error/syntax error. it runs but not as intended because wrong syntax....I think. I'm assuming we'd wanna print the actual values instead of just text??
            Console.WriteLine("{"+nX+"}^{"+nY+"} = {"+nAnswer+"}");
        }


        //int Power(int nBase, int nExponent) - syntax error - needed static
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //returnVal = 0; - logic error - caused everything to become 0 regardless since would multiply by this 
                returnVal = 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //nextVal = Power(nBase, nExponent + 1); logic error that caused runtime errors due to overflow since the exponent would never reach zero
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //returnVal; syntax error - forgot return

            return returnVal;
        }
    }
}
