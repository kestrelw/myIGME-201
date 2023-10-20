using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances of the classes
            IFace firstInstance = new Classy();
            IFace secondInstance = new Classie();

            // Call the MyMethod for both instances
            MyMethod(firstInstance);
            MyMethod(secondInstance);
        }

        public static void MyMethod(object myObject)
        {
            if (myObject is IFace myInterfaceObject)
            {
                // Call the MyMethod using the interface
                myInterfaceObject.FacePaint();
            }
 
        }
    }

    public interface IFace
    {
        void FacePaint();
    }
    public class Classy : IFace
    {
        public void FacePaint()
        {
            Console.WriteLine("words");
    
        }
    }

    public class Classie : IFace
    {
        public void FacePaint()
        {
            Console.WriteLine("other words");
    
        }
    }


}
