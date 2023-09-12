using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parsing_Formatting
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: number guessing game
    // Restrictions: None
    internal class Program
    {
        // Method: Main
        // Purpose: generate a num and direct the user's guesses till either 8 rounds or answer is guessed
        // Restrictions: None
        static void Main(string[] args)
        {
            Random rand = new Random();
            int userGuess = 101;
            int randomNumber = rand.Next(0, 101);
            int roundsToWin = 9;

            Console.WriteLine(randomNumber);



            for (int i = 1; i <= 8; i++)
            {
                Console.Write("Turn #" + i + ": Enter your guess: ");

                while (userGuess < 0 || userGuess > 100 )//untill num isn't -1
                {
                    try
                    {
                        userGuess = Convert.ToInt32(Console.ReadLine());//convert to int so it can check if positive

                        if (userGuess < 0 || userGuess > 100)
                        {
                            Console.WriteLine("Invalid guess – try again");
                            Console.WriteLine("Turn #" + i + ": Enter your guess: ");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid guess – try again");//repeat instructions if person incorrectly doing
                        Console.WriteLine("Turn #" + i + ": Enter your guess: ");
                    }


                }

                
                if (userGuess > randomNumber)
                {
                    Console.WriteLine("Too high");
                    userGuess = 101;
                }
                else if (userGuess < randomNumber)
                {
                    Console.WriteLine("Too low");
                    userGuess = 101;
                }
                else
                {
                    roundsToWin = i; 
                    break;
                }
                
            }

            if (roundsToWin<9)
            {
                Console.WriteLine("\nCorrect! You won in " + roundsToWin + " turns.");
            }
            else
            {
                Console.WriteLine("\nYou ran out of turns. The number was "+ randomNumber + "."); 
            }
        }
    }
}
