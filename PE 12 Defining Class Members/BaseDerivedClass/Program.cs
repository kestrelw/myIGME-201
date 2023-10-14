using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDerivedClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class MyClass
    {
        private string myString;

        public virtual string GetString()
        {
            //get
            //{
                return myString;
            //}
            //set
            //{
            //    myString = value;
            //}
        }
    }

    public class MyDerivedClass : MyClass
    {
        public MyDerivedClass(string initialValue) : base(initialValue)
        {
        }

        public override string GetString()
        {
            string baseString = base.GetString(); // Call the base class's implementation
            return baseString + " (output from the derived class)";
        }
    }
}

