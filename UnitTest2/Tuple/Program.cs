using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<(double, double, double), double> formula = new SortedList<(double, double, double), double>();

            for (double w = -2; w<=0; w = w +.2)
            {
                for (double y = -1; y <= 1; y = y + .1)
                {
                    for (double x = 0; x <= 4; x = x + .1)
                    {
                        w = Math.Round(w, 1);
                        y = Math.Round(y, 1);
                        x = Math.Round(x, 1);

                        double z = 4 * Math.Pow(y, 3) + 2 * Math.Pow(x, 2) - 8 * w + 7;
                        formula[(w, y, x)] = z;

                        z = Math.Round(z, 3);

                        Console.WriteLine("w:"+w+"\nx:"+x+"\ny:"+y+"\nz:"+z+"\n");
                    }
                }
            }
        }
    }
}
