using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    // Ref with class type

    //When you pass a class object to a method, you pass a copy of the reference (like a copy of an address/pointer) — NOT a copy of the object itself.

    //With ref you pass the original piece of paper itself — not a photocopy. So when the method writes a new address, it changes YOUR paper.
    public class Person
    {
        public string Name { get; set; }
    }

    /*

        ## Visually

        **Before:**
        ```
        person ──────────────► [ Person: "Alice" ]
        ```

        **After `ref` replacement:**
        ```
        person ──────────────► [ Person: "Bob" ]

                               [ Person: "Alice" ]  ← nobody points here!
                                                      GC will collect this
    
     */
    internal class RefVsOut
    {

        public static void MainRef()
        {

            var person = new Person { Name = "Alice" };

            GCHandle handle = GCHandle.Alloc(person, GCHandleType.Normal);
            IntPtr aliceAddress = GCHandle.ToIntPtr(handle);
            Console.WriteLine($"Alice handle: {aliceAddress}");

            ChangeName(person);
            Console.WriteLine(person.Name); // John



            var person1 = new Person { Name = "Alice" };

            GCHandle handle1 = GCHandle.Alloc(person1, GCHandleType.Normal);
            IntPtr aliceAddress1 = GCHandle.ToIntPtr(handle1);
            Console.WriteLine($"Alice handle: {aliceAddress1}");

            ReplacePerson(person1);
            Console.WriteLine(person1.Name); // Still "Alice" !!


            var person2 = new Person { Name = "Alice" };

            GCHandle handle2 = GCHandle.Alloc(person2, GCHandleType.Normal);
            IntPtr aliceAddress2 = GCHandle.ToIntPtr(handle2);
            Console.WriteLine($"Alice handle: {aliceAddress2}");

            ReplacePersonWithRef(ref person2);
            Console.WriteLine(person2.Name);

            handle.Free();
            handle1.Free();
            handle2.Free();
        }


        static void ChangeName(Person p)
        {
            p.Name = "John"; // ✅ this WORKS — modifies the original object

            GCHandle handle = GCHandle.Alloc(p, GCHandleType.Normal);
            IntPtr aliceAddress = GCHandle.ToIntPtr(handle);
            Console.WriteLine($"John handle: {aliceAddress}");
        }

        static void ReplacePerson(Person p)
        {
            p = new Person { Name = "Bob" }; // ❌ only changes LOCAL copy of reference


            GCHandle handle = GCHandle.Alloc(p, GCHandleType.Normal);
            IntPtr aliceAddress = GCHandle.ToIntPtr(handle);
            Console.WriteLine($"John handle: {aliceAddress}");
        }

        static void ReplacePersonWithRef(ref Person p)
        {
            p = new Person { Name = "Bob" }; // ✅ replaces the ORIGINAL reference

            GCHandle handle = GCHandle.Alloc(p, GCHandleType.Normal);
            IntPtr aliceAddress = GCHandle.ToIntPtr(handle);
            Console.WriteLine($"John handle: {aliceAddress}");
        }

    }
}
