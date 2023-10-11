using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace _424DoubleBogey
{
    //Vehicle class hierarchy
    public abstract class Vehicle
    {
        public virtual void LoadPassenger()
        {

        }
    }


    public abstract class Car
    {
        
    }

    public abstract class Train
    {

    }

    //PassengerCarrier interface
    public interface IPassengerCarrier
    {
        void Passenger()
        {

        }
    }


    // IHeavyLoadCarrier interface
    public interface IHeavyLoadCarrier
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

}