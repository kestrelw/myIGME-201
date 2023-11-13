using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    // Class: Program
    // Author: Melodie Wang
    // Purpose: references vehicles
    // Restrictions: None

    class Traffic
    {
        // Method: Main
        // Purpose: create new existing objects and pass to function
        // Restrictions: None
        static void Main(string[] args)
        {
            Compact compact = new Compact();
            FreightTrain freightTrain = new FreightTrain();

            AddPassenger(compact);
            //AddPassenger(freightTrain); //cant pass because doesnt inherit IPassengerCarrier interface
        }
    public static void AddPassenger(IPassengerCarrier vehicleObject)
    {
        //call method
        vehicleObject.LoadPassenger();
        //use ToString() method
        Console.WriteLine(vehicleObject.ToString());
    }
}

}
