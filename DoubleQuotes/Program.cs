using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleQuotes
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: surrounds each word in ""
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: takes string input, adds "" around each word
        // Restrictions: None
        static void Main(string[] args)
        {
            string result = "";

            Console.WriteLine("Input a sentance");
            string userInput = Console.ReadLine();

            // split the input into separate words
            string[] words = userInput.Split(' ');

            foreach (string word in words)
            {
                if (word == words[0])// not needed? || word == "." || word == "," || word == "?" || word == "!"
                {
                    result += ("\""+word+ "\"");
                }
                else
                {
                    result += ("\" " + word + "\"");
                }
            }
            Console.WriteLine(result);
        }
    }
}
