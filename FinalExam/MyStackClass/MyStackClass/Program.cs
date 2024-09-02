using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStackClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class MyStack
    {
        private List<int> list;

        public MyStack()
        {
            list = new List<int>();
        }

        public void Push(int n)
        {
            list.Add(n);
        }

        public int Pop()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Stack empty. Cannot pop element.");
            }

            int lastIndex = list.Count - 1;
            int popped = list[lastIndex];
            list.RemoveAt(lastIndex);

            return popped;
        }

        public int Peek()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("The stack is empty. Cannot peek top element.");
            }

            return list[list.Count - 1];
        }
    }
}
