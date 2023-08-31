using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wang_HelloWorld
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            int numHad = -1;
            int numLost = -1;
            string name = null;

            Console.WriteLine("Please input your name");
            name = Console.ReadLine();//get user input
            Console.WriteLine("Please input a positive integer");
            while (numHad <= 0)//untill num isn't -1
            {
                try{
                    numHad = Convert.ToInt32(Console.ReadLine());//convert to int so it can check if positive
                }catch{
                    Console.WriteLine("Please input a positive integer");//repeat instructions if person incorrectly doing
                }
            }
            Console.WriteLine("Please input a second positive integer");//getting a second int. same as previous few lines with 1 var change
            while (numLost <= 0)
            {
                try
                {
                    numLost = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please input a positive integer");
                }
            }


            if (numHad>=numLost) {//if numbers make sense
                Console.WriteLine(name+" had "+numHad+" apples. "+ name+ " lost "+ numLost+" apples. "+ name+" now has "+(numHad-numLost)+" apples. How very sad...");
            }else{//if numbers don't make sense. yes this is intentially illogical. you will get negative items
                Console.WriteLine(name + " had " + numHad + " apples. " + name + " lost " + numLost + " apples. " + name + " now has " + (numHad - numLost) + " apples. Wait that doesn't make sense...");
            }
            

        }
    }
}
