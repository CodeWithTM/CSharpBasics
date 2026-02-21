using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    internal class NullableTypes
    {
        public void Main()
        {
            int? i = 0;

            i = null;

            // int is non-nullable value type

            Nullable<int> j = new Nullable<int>(); // --> shorthand int? j = null

            // Nullable is a struct that allows value types to be null. It has two main properties: HasValue (indicates if it contains a value) and Value (the actual value if HasValue is true).
            // struct Nullable<T> where T : struct

            j = null;


            if(j.HasValue)
                Console.WriteLine(j.Value);

            //now j is nullable(can store/accept 'null' value) value type

            Student s = new Student();
            Student s1 = null;

            //Nullable Reference Types — Why do they even exist?
            //Here's the thing: reference types (string, classes, arrays) have always been able to hold null. So why does C# 8 introduce string??
            //The answer isn't to allow null — it's to communicate intent and catch bugs at compile time.
            int k;


            if (s1 == null) { 
            
            }

            string name = GetName(); // could this be null? who knows?
            Console.WriteLine(name.Length); // NullReferenceException waiting to happen
        }

        public string GetName()
        {
            return null; // this is allowed, but it can lead to runtime errors if not handled properly
        }
    }

    public class Student
    {

    }
}
