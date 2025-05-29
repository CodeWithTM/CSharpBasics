using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{

    //INTANCE --> base to derived
    //STATIC --> derived to base
    public class ConstructorOrder
    {
        public void Main()
        {
            //Base b = new Base();

            Base b = new Derived();

            Derived d = new Derived();

            Base de = new Derived();

            (de).GetPrice();

            Base ab = new AnotherDerived();

            ab.GetPrice();

            ((Derived)ab).GetPrice();

            //derivedCls derivedCls = new derivedCls(1);
        }
    }

    public class Base
    {
        public int bVal = 1;    //instance member variable - each and every obj will get its own copy

        //Hidden Default cntr..

        public Base()
        {
            //once we define our own default cntr, hidden default cntr is not called..
        }

        public Base(int i)
        {

        }

        public static int bSVal = 10;   //static instance variable - one copy is shared amongst all the objects
        static Base() // static cntr - NO access modifier, NO parameter
        {
            bSVal += 1;
        }

        public virtual decimal GetPrice()
        {
            return 10.0m;
        }
    }

    //Order:
    //1 static instance variables
    //2 static constructor
    //3 instance variable
    //4 constructor

    public class Derived : Base
    {
        public int dVal = 20;
        public Derived() : base(1)
        {

        }

        public static int dSVal = 200;
        static Derived()
        {

        }
        public override decimal GetPrice()
        {
            return base.GetPrice() + 2.0m;
        }
    }

    public class AnotherDerived : Derived
    {
        public override decimal GetPrice()
        {
            return base.GetPrice() + 3.0m;
        }

    }

    //Order:
    //1 static instace variable of derived
    //2 static constructor of derived

    //3 static instance variable of base
    //4 static construcotr of base

    //5 instance variable of base
    //6 instance constructor of base

    //7 instance variable of derived
    //8 instance constructor of derived

    //Destructor order:
    //1 derived class Destructor
    //2 base class Destructor

    public class BaseCls
    {
        public BaseCls(int param1)
        {

        }

        //what is the need for explicit default ctr? In case of derived class if we dont add this default ctr,
        //derived class ctr cannot invoke base class default ctr , as user has not provided 1
        //bcoz of which we need to explicitly add default ctr
        public BaseCls()
        {

        }
    }
    public class UserCls : BaseCls
    {
        //if we dont create any ctr in class there is implicit default, parameter less ctr is available

        //once we create any ctr whether it is with parameter or without parameter, then default ctr is not used..

        public UserCls()
        {
            Console.WriteLine("inside default ctr");
        }

        //ctr can has just a return; statement but it cannot return any value.


        //but we can make use of ref and out to return a value in case of 'parameterized' ctr


        //for any ctor to b invoked, we need to create an object with new
        //even if we just specify UserCls user; or UserCls user = null; ctor is not invoked


        //access modifier and paramters are not allowed in static ctor
        //this is bcoz static ctor are invoked by compiler(CLR) and not by user..
        //and in that case compiler dont want any access modifier or parametrs to be passed to static ctor

        //static constructor cannot be overloaded - that is we can not pass any parameters to static ctor, so we cannot overload it.
        static UserCls()
        {

        }

        public void callStaticMethod()
        {
            UserStaticCls.MyProperty = 1;
            UserStaticCls.StaticM();
        }


        public static int staticProp { get; set; }
        public void nonStaticM()
        {
            Console.WriteLine(TOTAL);
            UserCls.staticProp = 1; // non static members can access static members and NOT VICE VERSA..
                                    // way to remember - 'S'tatic - 'S'tricter
        }

        public int nonStaticProp { get; set; }
        public static void staticM()
        {
            //to access non-static members inside static, we need to have obj reference..
            new UserCls().nonStaticProp = 2;
            Console.WriteLine(TOTAL);
        }

        public const int TOTAL = 0; //const are static internally.. we can check in IL code
    }

    //STATIC class - static classes are implicitly SEALED
    public static class UserStaticCls
    {
        public static int MyProperty { get; set; }

        static UserStaticCls()
        {

        }

        public static void StaticM()
        {
            Console.WriteLine("only static members allowed inside static class");
        }


    }

    //we cannot derive a class from static class
    public static class staticderived : Object   //UserStaticCls
    {
    }

    public sealed class SealedCls
    {

    }

    public class derivedCls // : SealedCls
    {
        derivedCls()
        {
            Console.WriteLine("private ctor");
        }

        //public derivedCls() { } there is already a ctor with no i/p params

        //public derivedCls(int i)
        //{

        //}
    }

    //if the class is having ONLY private ctor, then it cannot b inheted

    public class anotherDerivedCls// : derivedCls
    {
        //public anotherDerivedCls() //: base (0) 
        //{

        //}
    }
}
