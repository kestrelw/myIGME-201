using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _3Questions
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: asks 3 weird questions
    // Restrictions: None
    internal class Program
    {
        static Timer timeOutTimer;
        static bool bTimeOut = false;
        static string sAgain;

        static string[] questions = { "What is your favorite color?", "What is the answer to life, the universe and everything?", "What is the airspeed velocity of an unladen swallow?" };
        static string[] answers = { "black", "42", "What do you mean? African or European swallow?" };
        static int nQuestion = 0;//if valid will become this.

        // Method: Main
        // Purpose: question, user input, weird answer right or wrong, play again
        // Restrictions: None
        static void Main()
        {


            string sQuestion;//which question to ask
            string sResponse;
            
            bool bValid = false;//question choice valid?


            start:

            do
            {
                Console.Write("Choose your question (1-3): ");
                sQuestion = Console.ReadLine();

                try
                {
                    nQuestion = int.Parse(sQuestion);
                    bValid = true;
                }
                catch
                {
                    Console.WriteLine("Please enter an integer.");
                    bValid = false;
                }

                if (nQuestion > 0 && nQuestion < 4)
                {
                    nQuestion = nQuestion-1; 
                    continue;
                }
                else
                {
                    goto start;
                }

            } while (!bValid);

            Console.WriteLine("You have 5 seconds to answer the following question:");

            do
            {
                Console.WriteLine(questions[nQuestion]);

                timeOutTimer = new Timer(5000);
                timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);
                timeOutTimer.Start();

                sResponse = Console.ReadLine();
                timeOutTimer.Stop();

                if (bTimeOut)
                {
                    break;
                }

                if (sResponse == answers[nQuestion])
                {
                    Console.WriteLine("Well done!");
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong! The answer is: "+ answers[nQuestion]);
                    break;
                }
                

            } while (!bValid);

            do
            {
                // prompt if they want to play again
                Console.Write("Play again? ");

                sAgain = Console.ReadLine();

                if (sAgain.ToLower().StartsWith("y"))
                {
                    Console.WriteLine();
                    goto start;
                }
                else if (sAgain.ToLower().StartsWith("n"))
                {
                    break;
                }
            } while (true);


        }

        static void TimesUp(object sender, ElapsedEventArgs e)
        {
            // let the user know their time is up
            Console.WriteLine("Your time is up!");

            // set the time out flag
            bTimeOut = true;

            // stop the timer, otherwise it will start over
            timeOutTimer.Stop();

            Console.WriteLine("The answer is: " + answers[nQuestion]);

            // ask them to press enter to get out of the Console.ReadLine() at line #68
            Console.WriteLine("Please press Enter.");

        }
    }
}
