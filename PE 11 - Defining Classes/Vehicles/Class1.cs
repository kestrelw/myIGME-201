using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    //Vehicle class hierarchy

    //PassengerCarrier interface
    public interface IPassengerCarrier
    {
        void LoadPassenger();
    }


    // IHeavyLoadCarrier interface
    public interface IHeavyLoadCarrier
    {

    }

    public abstract class Vehicle
    {
        public virtual void LoadPassenger()
        {

        }
    }

    public abstract class Car : Vehicle
    {

    }

    public abstract class Train : Vehicle
    {

    }


    public class Compact : Car, IPassengerCarrier
    {
    }
    public class SUV : Car, IPassengerCarrier
    {

    }

    public class Pickup : Car, IPassengerCarrier, IHeavyLoadCarrier
    {

    }

    public class PassengerTrain : Train, IPassengerCarrier
    {

    }

    public class FreightTrain : Train, IHeavyLoadCarrier
    {

    }


    public class _424DoubleBogey : Train, IHeavyLoadCarrier
    {

    }

}
