using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    internal class AbstractVirtual
    {
        public void Main()
        {
            //Cannot create instance of abstract class
            //Vehicle vehicle = new Vehicle();

            Vehicle car = new Car();
            car.Drive();

            Vehicle truck = new Truck();
            truck.StartEngine();
            truck.Drive();


            //abstract class - provides way to implement abstraction in OOPs
            ATM atm = new BankATM();
            atm.WithdrawCash();

            BankATM bATM = atm as BankATM;
            bATM.WithdrawCash();


            BankATM sbi = new BankATM();
            sbi.WithdrawCash();

        }
    }

    public abstract class Vehicle
    {
        //Non abstract member
        public int Wheels { get; set; } = 4;

        public Vehicle()
        {
        }

        //Abstract members
        //Class should be marked as abstract
        public abstract string EngineType { get; set; }
        public abstract void Drive();

        public virtual void StartEngine()
        {
            //start the engine
        }
    }

    public class Car : Vehicle
    {
        //we MUST provide implementation for abstract members
        //overriding virtual member is OPTIONAL
        public override string EngineType { get; set; }

        public override void Drive()
        {
            //throw new NotImplementedException();
        }
    }

    public class Truck : Vehicle
    {
        public override string EngineType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void Drive()
        {
            throw new NotImplementedException();
        }
    }

    //All the classes in c# implicilty inherit from System.ValueType and System.Object
    public class AnyClass : Object
    {
        public int Prop1 { get; set; }
        public int Prop2 { get; set; }

        //we can override all the 3 methods from object class

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return "{0}-{1}" + Prop1 + Prop2;
        }
    }

    public abstract class ATM
    {
        public abstract void WithdrawCash();
    }

    class BankATM : ATM
    {
        public override void WithdrawCash()
        {
            Console.WriteLine("insert card");

            Console.WriteLine("enter PIN");

            Console.WriteLine("withdraw cash");
        }
    }
}
