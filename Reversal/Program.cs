using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversal
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: reversing user input
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: takes string input, breakes down into characters and outputs backwards
        // Restrictions: None
        static void Main(string[] args)
        {
            string userInput;

            Console.WriteLine("Enter a word");
            userInput = Console.ReadLine();

            char[] characters = userInput.ToCharArray(0,userInput.Length);

            for(int i = characters.Length - 1; i >= 0; i--)
            {
                Console.Write(characters[i]);
            }

            Console.WriteLine();
        }
    }
}
