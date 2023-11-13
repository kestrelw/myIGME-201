using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static PhoneUML.Program;

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

        public PhoneBooth()
        {
            //UsePhone(object obj);
        }

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


        public Tardis()
        {
            //UsePhone(object obj);
        }


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

        public static bool operator ==(Tardis left, Tardis right)
        {
            return left.WhichDrWho == right.WhichDrWho;
        }

        public static bool operator !=(Tardis left, Tardis right)
        {
            return left.WhichDrWho != right.WhichDrWho;
        }

        public static bool operator >=(Tardis left, Tardis right)
        {
            if ((left.WhichDrWho == 10) && (right.WhichDrWho != 10))
            {
                return true;
            }
            else if ((left.WhichDrWho != 10) && (right.WhichDrWho == 10))
            {
                return false;
            }
            else
            {
                return left.WhichDrWho >= right.WhichDrWho;

            }
        }

        public static bool operator <=(Tardis left, Tardis right)
        {
            if ((left.WhichDrWho == 10) && (right.WhichDrWho != 10))
            {
                return false;
            }
            else if ((left.WhichDrWho != 10) && (right.WhichDrWho == 10))
            {
                return true;
            }
            else
            {
                return left.WhichDrWho <= right.WhichDrWho;

            }
        }

        public static bool operator >(Tardis left, Tardis right)
        {
            if((left.WhichDrWho == 10) && (right.WhichDrWho != 10))
            {
                return true;
            }
            else if ((left.WhichDrWho != 10) && (right.WhichDrWho == 10))
            {
                return false;
            }
            else
            {
                return left.WhichDrWho > right.WhichDrWho;

            }
        }

        public static bool operator <(Tardis left, Tardis right)
        {
            if ((left.WhichDrWho == 10) && (right.WhichDrWho != 10))
            {
                return true;
            }
            else if ((left.WhichDrWho != 10) && (right.WhichDrWho == 10))
            {
                return false;
            }
            else
            {
                return left.WhichDrWho > right.WhichDrWho;

            }
        }
    
        

    }

    

    internal class Program
    {
        static void Main(string[] args)
        {
            Tardis tardis = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();

            UsePhone(tardis);
            UsePhone(phoneBooth);
        }

        static void UsePhone(object obj)
        {
            IPhoneInterface iphoneInterface = (IPhoneInterface)obj;

            iphoneInterface.MakeCall();
            iphoneInterface.HangUp();

            if (iphoneInterface is PhoneBooth)
            {
                PhoneBooth phoneBooth = (PhoneBooth)iphoneInterface;
                phoneBooth.OpenDoor();
            }
            else if(iphoneInterface is Tardis)
            {
                Tardis tardis = (Tardis)iphoneInterface;
                tardis.TimeTravel();
            }
        }

    }

}

