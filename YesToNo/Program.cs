using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesToNo
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: swaps yes and no
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: takes string input, finds no and inputs yes in its place
        // Restrictions: Don't know how to make yes capital again if no was capital
        static void Main(string[] args)
        {
            string finalStory = "";

            Console.WriteLine("Input a sentance with no");
            string userInput = Console.ReadLine();

            // split the input into separate words
            string[] words = userInput.Split(' ');

            foreach (string word in words)
            {
                string replaceWord = word.ToLower().Replace("no", "yes");
                if (word == words[0])
                {
                    finalStory += replaceWord;
                }
                else
                {
                    finalStory += (" "+replaceWord);
                }
            }
            Console.WriteLine(finalStory);  
        }
    }
}
