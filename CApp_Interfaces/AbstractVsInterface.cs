using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Interfaces
{
    internal class AbstractVsInterface
    {
    }

    public abstract class Phone
    {
        public string Brand { get; }

        protected Phone(string brand)
        {
            Brand = brand;
        }

        public void Call(string number)
        {
            Console.WriteLine($"{Brand} calling {number}");
        }

        public abstract void PowerOn();
    }

    public class SmartPhone : Phone
    {
        public SmartPhone(string brand) : base(brand) { }

        public override void PowerOn()
        {
            Console.WriteLine("Booting OS...");
        }

        public void BrowseInternet()
        {
            Console.WriteLine("Browsing...");
        }
    }


    // IS-A relationship

    public interface ICamera
    {
        void TakePhoto();
    }

    public interface IGps
    {
        void Navigate(string destination);
    }

    public abstract class PhoneCls
    {
        public void Call(string number) { }
    }
    public class SmartPhoneCls : PhoneCls, ICamera, IGps
    {
        public void TakePhoto() { }
        public void Navigate(string destination) { }
    }

    // SmartPhoneCls IS-A PhoneCls
    // and SmartPhoneCls CAN TakePhoto ,  SmartPhoneCls CAN Navigate



}
