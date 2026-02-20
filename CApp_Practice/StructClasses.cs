using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{

    //Struct are value type in C#
    //Int32, Double these are all struct

    // Structs always have an automatic default constructor created by the runtime. and we are not allowed to create one.
    // and not allowing a custom default constructor makes strcu - predictable, and always safely initialized
    struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        //public Point()
        //{
        //    X = 10;
        //    Y = 20;
        //}
    }
    internal class StructClasses
    {
        public static void MainStruct()
        {

            // All the value types defined below are structs

            Int32 i;
            float f; // --> alias name for Single
            Double d;

            Boolean b;
            bool bl;

            //similarly we can create a struct variable for Point


            // no constructor called
            Point p; // and we expect it should have a default value initialized..

            //if default constructor would have been allowed in C#, then we expect p should have values like X=10 and Y=20
            //but it will have default as 0

            //Struct default constructor was originally disallowed because it could silently not run, leading to inconsistent behavior.

            Point p2 = default;

            Point p3 = new Point();

            Point p4 = new Point(10, 20);


            //int is a struct
            int i1 = new Int32(); // it will get allocated on stack, just using new doesnt mean it is a reference type

            Pointer pt = new Pointer(1,2);



            
        }
    }

    public class Pointer
    {
        public const string NAME = "CONST VAL";
        public int X;

        public int Y;


        //once u default any constructor, default ctor will net get inviked
        public Pointer(int x, int y)
        {

        }
    }


}
