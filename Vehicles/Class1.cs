using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _424DoubleBogey
{
    //Vehicle class hierarchy
    public abstract Vehicle
    {

    }   

    //PassengerCarrier interface
    public interface IPassengerCarrier
    {
        void LoadPassenger()
        {

        }
    }


    // IHeavyLoadCarrier interface
    public interface IHeavyLoadCarrier
    {

    }


    public class Compact: IPassengerCarrier, Car
    {

    }

    public class SUV : IPassengerCarrier, Car
    {

    }

    public class Pickup: IPassengerCarrier, Car, IHeavyLoadCarrier
    {

    }

    public class PassengerTrain: IPassengerCarrier, Train
    {

    }

    public class FreightTrain: IHeavyLoadCarrier, Train
    {

    }





    // Car class
  



    // Implement other vehicle classes similarly
    // ...

    // _424DoubleBogey class
    public class _424DoubleBogey : Vehicle, IPassengerCarrier, IHeavyLoadCarrier
    {
        public override void LoadPassenger()
        {
            Console.WriteLine("Passenger loaded in the _424DoubleBogey.");
        }

        public override void LoadCargo()
        {
            Console.WriteLine("Cargo loaded in the _424DoubleBogey.");
        }
    }
}