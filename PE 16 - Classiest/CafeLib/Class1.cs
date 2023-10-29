using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace CafeLib
{
    interface ITakeOrder
    {
        void TakeOrder();
    }

    interface IMood
    {
        string Mood
        {
            get;
        }
       
    }

    public abstract class HotDrink
    {
        private string brand;

        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        public virtual void AddSugar(byte amount)
        {
        }

        public abstract void Steam();

        public HotDrink()
        {
        }
        public HotDrink(string brand)
        {
            //this.brand = brand;
        }

    }

    public class Waiter: IMood
    {
        public string name;

        /*public Waiter()////////////////////////////////////////
        {

        }
        */

        public string Mood
        {
            get;
        }

        public void ServeCustormer(HotDrink cup)
        {

        }
    }

    public class Customer: IMood
    {
        public string name;
        public string creditCardNumber;

        /*public Customer()
        {

        }
        */

        public string Mood
        {
            get;
        }
    }

    public class CupOfCoffee: HotDrink, ITakeOrder
    {
        public string beanType;
        public string brand;

        public CupOfCoffee(string sbrand) : base(sbrand)
        {
            //this.brand = sbrand;
        }
        public override void Steam()
        {
            
        }

        public void TakeOrder()
        {

        }
    }

    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;
        public bool customerIsWealthy;

        public CupOfTea(bool bCustomerIsWealthy)
        {
            //this.customerIsWealthy = bCustomerIsWealthy;
        }
        public override void Steam()
        {

        }

        public void TakeOrder()
        {

        }
    }

    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;
        private string source;

        public CupOfCocoa() : this(false)
        {

        }

        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand")
        {
            this.marshmallows = marshmallows;//
        }

        public string Source
        {
            set
            {
                this.source = value;//
            }
        }

        public override void Steam()
        {

        }

        public override void AddSugar(byte amount)
        {

        }

        public void TakeOrder()
        {

        }
    }
}
