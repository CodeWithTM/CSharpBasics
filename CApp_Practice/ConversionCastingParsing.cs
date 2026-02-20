using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{

    //Type Conversion
    //Type Casting
    //Parsing
    internal class ConversionCastingParsing
    {
        public static void MainCCP()
        {

            // implicit conversion - is done by the compiler. its widening operation. i.e. smaller --> Larger

            int intNumber = 10;

            long longNumber = intNumber;

            double doubleNumber = longNumber;

            //float floatNumber = doubleNumber;
            //wherever it is not possible to do implicit casting compiler will give error.
            //Because double is bigger and more precise than float, so converting double → float can lose data.

            float floatNumber = (float)doubleNumber;        // hey complier - I KNOW WHAT I AM DOING, JUST DO IT

            // read it like this. every int is a long, every float is a double etc.

            // implicit casting in case of reference type 

            Dog d = new Dog();
            Animal a = d;   // ✅ implicit
            // Because every Dog is an Animal.

            Animal a1 = new Animal();
            //Dog d1 = a1;      // ❌ not allowed

            //Explicit cast
            Animal a2 = new Animal();
            Dog d2 = (Dog)a2; // compiles, but may crash at runtime

            //SAFER option:
            Dog d3 = a2 as Dog;   // d3 becomes null if Animal a2 is not a Dog

            /*
                THUMB RULE:

                More specific → more general = implicit (upcast)

                More general → more specific = explicit (downcast)
             */


            // Type Conversion vs Casting
            // Conversions can be implicit or explicit.
            // Casting is one way to do an explicit conversion. i.e. (int), (float) so it is one of the way to do explicit casting

            // now lets take example of below
            int s = Convert.ToInt32("1"); // here also we are doing a conversion but w/o using a cast operator (int)


            object obj = 25;

            //string str1 = (string)obj; This will give runtime exception

            int int1 = (int)obj; // unboxing, boxing applied here..
        }
    }

    /*
    Conversion between non-compatible types is possible, but not by casting.


    Types are non-compatible when the compiler can’t naturally convert them, like:

        string ↔ int

        string ↔ double

        DateTime ↔ string

        object ↔ int (sometimes)

        bool ↔ int

        string s = "123";
        int x = (int)s;   // ❌ impossible

    How do you convert non-compatible types?
    by using -->
    Convert.
    Parse
    ToString

     */

    public class AnimalCls { }


    public class DogCls : AnimalCls
    {

    }
}
