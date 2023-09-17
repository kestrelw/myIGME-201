using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Wang_PE7MadLibs
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: mad libs fill in the blank game
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: prompt the user for inputs then output a mad libs story with the user inputs. 
        // Restrictions: None
        static void Main(string[] args)
        {
            int numLibs = 0;
            int cntr = 0;
            int nChoice = 0;

            string finalStory = "";
            string playLibs;
            bool letsPlay = false;
            bool bValid = false;

            StreamReader input;

            // open the template file to count how many Mad Libs it contains
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");
            //input = new StreamReader("c:/templates/MadLibsTemplate.txt");

            string line = null;
            while ((line = input.ReadLine()) != null)
            {
                ++numLibs;
            }

            // close it
            input.Close();

            // only allocate as many strings as there are Mad Libs
            string[] madLibs = new string[numLibs];

            // read the Mad Libs into the array of strings
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            line = null;
            while ((line = input.ReadLine()) != null)
            {
                // set this array element to the current line of the template file
                madLibs[cntr] = line;

                // replace the "\\n" tag with the newline escape character
                madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n");

                ++cntr;
            }

            input.Close();

            
            Console.WriteLine("Would you like to play Mad Libs? Please enter yes or no.");
            do
            {
                playLibs = Console.ReadLine().ToLower();
                if (playLibs == "yes")
                {
                    letsPlay = true;
                }
                else if(playLibs == "no")
                {
                    Console.WriteLine("Have a good day.");
                    Environment.Exit(0);

                }
                else
                {
                    Console.WriteLine("Please enter yes or no");
                }
            } while (!letsPlay);

            bValid = false;
            // prompt the user for which Mad Lib they want to play (nChoice)
            do
            {
                Console.WriteLine("Which Mad Lib would you like to play? Please type a number between 1 and " + numLibs);

                // or try/catch with Parse() or Convert.ToInt32()
                try
                {
                    nChoice = Convert.ToInt32(Console.ReadLine());
                    bValid = true;
                }
                catch
                {
                    Console.WriteLine("Please enter an integer");
                    bValid = false;
                }
            } while (!bValid);

            // split the Mad Lib into separate words
            string[] words = madLibs[nChoice].Split(' ');

            foreach (string word in words)
            {
                // if word is a placeholder
                if (word[0] == '{')
                {
                    string replaceWord = word.Replace("{", "").Replace("}", "").Replace("_", " ");
                    // prompt the user for the replacement
                    Console.Write("Input a {0}: ", replaceWord);
                    // and append the user response to the result string
                    finalStory += (" "+Console.ReadLine());
                }
                // else append word to the result string
                else if (word[0] == '.'|| word[0] == ',')
                {
                    finalStory += (word);
                }
                else
                {
                    finalStory += (" "+word);
                }
            }

            Console.WriteLine(finalStory);
        }
    }
}