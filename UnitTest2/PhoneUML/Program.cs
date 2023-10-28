using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhoneUML
{
    interface IPhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                this.phoneNumber = value;
            }
        }

        public abstract void Connect();
        public abstract void Disconnect();
    }


    internal class Program
    {
        static void Main(string[] args)
        {

        }

    }

    public class RotaryPhone : Phone, IPhoneInterface
    {
        public void Answer()
        {
        }
        public void MakeCall()
        {
        }
        public void HangUp()
        {
        }

        public override void Connect()
        {
        }

        public override void Disconnect()
        {
        }
    }

    public class PushButtonPhone : Phone, IPhoneInterface
    {
        public void Answer()
        {
        }
        public void MakeCall()
        {
        }
        public void HangUp()
        {
        }

        public override void Connect()
        {
        }

        public override void Disconnect()
        {
        }
    }

    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor()
        {
        }

        public void CloseDoor()
        {
        }
    }

    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double extreriorSurfaceArea;
        public double interiorVolume;

        public byte WhichDrWho
        {
            get
            {
                return this.whichDrWho;
            }
        }

        public string FemaleSideKick
        {
            get
            {
                return this.femaleSideKick;
            }
        }

        public void TimeTravel()
        {
        }
    }
}

