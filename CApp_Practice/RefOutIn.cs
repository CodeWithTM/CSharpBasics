using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CApp_Practice
{

    public class RefType
    {
        public int MyProperty;
    }
    internal class RefOutIn
    {
        public static void MyMain()
        {
            int p = 10; 
            //int? p=null;

            //Console.WriteLine("Param outside before: " + p);

            RefMethod(ref p);   // ref parameter has to be initialized before passing it to method

            //RefMethod(10);

            Console.WriteLine("Param outside after: " + p);

            RefType refType = new RefType();
            refType.MyProperty = p;

            //PrintMemoryAddressOfObject(refType);
            
            RefM(refType);

            int x;
            M1(out x); //even if we initialize some value to x, it will be ignored inside the method..
        }

        public static int returnInt()
        {
            return 10;
        }

        public static void RefM(RefType rtype)
        {

            //rtype = new RefType(); this will still point to same mem location

            rtype.MyProperty = 100;

            //PrintMemoryAddressOfObject(rtype);
        }

        public static void RefMethod(ref int param1)
        {
            param1++;
        }

        //cannot be overloaded with ref and out
        //this is bcoz after compilation all these methods(with ref/out/int) has signature like:
        //public static void RefMethod(int32& param1) --> that is address/pointer variable
        //so as the signature is same, we cannot overload
        
        //public static void RefMethod(out int param1)
        //{
        //    param1 = 100;
        //    param1++;
        //}

        public static void NullableInputMethod(int? param1)
        {

            param1 = param1 + 10;       // this will return null

            param1 = param1.GetValueOrDefault() + 10;   //this will return 10

            Console.WriteLine("Param inside: " + param1);
        }

        //method overloading is possible with ref in the method signature
        //so method without ref is considered as another signature of method
        public static void RefMethod1(int param1)
        {
            
        }

        public static int RefMethod(double param1)
        {
            return 10;
        }

        public static void M1(out int i)
        {
            //we need to assign value to out parameter before control leaves the method, as its an OUTput value from the method
            //event we cannot use out parameter in any of the expression before its initialization
            //e.g. Console.WriteLine(i);
            
            i = 10;

            
            M2(in i);
            //M2(i); in keyword is optional in method call..
            i++;

            Console.WriteLine(i);
        }

        public static void M2(in int j)
        {
            //we cannot modify j inside the method, as its only used to pass INput values to the method
            //in paramter is kind of readonly inside a method..
            Console.WriteLine(j);
        }

        private static void PrintMemoryAddressOfObject(RefType myObject)
        {
            // Allocate a GCHandle for the object
            GCHandle handle = GCHandle.Alloc(myObject, GCHandleType.Pinned);

            try
            {
                // Get the address of the object
                IntPtr address = handle.AddrOfPinnedObject();

                // Print the address
                Console.WriteLine($"Memory address of myObject: {address}");
            }
            finally
            {
                // Free the handle to allow the object to be garbage collected
                handle.Free();
            }
        }
    }
}
