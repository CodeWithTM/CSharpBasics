using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{

    //Static class
    //Non static class
    //Static ctor
    //non static ctor
    internal class StaticNonStatic
    {

        public static void MainSnS()
        {
            NonStaticClass nonStaticClass = new NonStaticClass();

            nonStaticClass.nonStaticVariable = 10;

            NonStaticClass.staticVariable = 20;

            NonStaticClass.StaticMethod();


            NonStaticClass anotherObj = new NonStaticClass();
            Console.WriteLine(anotherObj.nonStaticVariable);


            AnotherStaticClass staticClass = new AnotherStaticClass();
            // This line will call static constructor first and then the instance constructor
            // reason being .. as we have used type - StaticClass, for the first time it will call static ctor
            // then as we are using new StaticClass(), so to initialize obj field it will call instance ctor


            //Even if we write below statement for the first time , it will cll static ctor before calling the method
            AnotherStaticClass.StaticMethod();

            AnotherStaticClass another_obj = new AnotherStaticClass(); // this will now call only instance ctor

            //StaticClass staticClass1 = new StaticClass();

            StaticClass.StaticMethod();
        }
    }

    public class NonStaticClass
    {
        public static int staticVariable;

        public int nonStaticVariable;

        public static void StaticMethod()
        {
            Console.WriteLine(staticVariable);
        }

    }

    public class AnotherStaticClass
    {
        //NO ACCESS MODIFIER
        //NO PARAMETERS

        //BCOZ - WHO CALLS STATIC CONSTRUCTOR - ITS RUNTIME
        //You never call a static constructor. The runtime does.
        //Static constructor has no access modifier because it is never called by you — only by the runtime.

        //1st and ONLY ONCE
        static AnotherStaticClass()
        {

        }

        //2nd and EVERYTIME
        public AnotherStaticClass()
        {

        }

        public static void StaticMethod()
        {

        }
    }

    public static class StaticClass
    {
        //static class can have only static members
        //static class cannot be instantiated
        //static class cannot have instance constructor
        //static class can have static constructor

        public const int COUNTER = 10;

        public static readonly int READ_COUNTER = 100;

        static StaticClass()
        {
            
        }
        public static void StaticMethod()
        {
            Console.WriteLine(COUNTER); // bcoz const is static internally

            Console.WriteLine(READ_COUNTER);
        }

        //public void NonStaticMethod()
        //{

        //}

    }
    public abstract class VehicleBase
    {

        public abstract void Drive();

    }

    public class CarBase : VehicleBase
    {
        public override void Drive()
        {
            throw new NotImplementedException();
        }
    }
}
