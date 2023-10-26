using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2___Phones
{
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber
        {
            get 
            { 
                return phoneNumber;
            } set 
            { 
                phoneNumber = value; 
            }
        }

        public abstract void Connect();
        public abstract void Disconnect();
    }

    //interface without a leading I in its name? :c
    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    public class RotaryPhone: Phone, PhoneInterface
    {

        public void Answer() { }
        public void MakeCall() { }
        public void HangUp() { }

        public override void Connect() { }
        
        public override void Disconnect() { }

    }

    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;

        public double exteriorSurfaceArea;
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

        public void TimeTravel() { }
    }

    public class PushButtonPhone: Phone, PhoneInterface
    {

        public void Answer() { }
        public void MakeCall() { }
        public void HangUp() { }
        public override void Connect() { }
        public override void Disconnect() { }

    }

    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;

        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor() { }
        public void CloseDoor() { }

    }


}
