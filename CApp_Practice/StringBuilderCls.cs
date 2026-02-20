using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    internal class StringBuilderCls
    {

        // string are immutable
        // Its characters can NEVER be changed.
        /*
         String s = "Hello";

                STACK                         HEAP
                -----                         ----
                s  ────────────────▶     [ String Object #1 ]
                                            "Hello"


                s = s + " World";


                STACK                         HEAP
                -----                         ----
                s  ────────────────▶     [ String Object #2 ]
                                           "Hello World"

                                         [ String Object #1 ]
                                           "Hello"

            Eventually, when GC runs, "Hello" may be collected (if no one references it).
         */

        public static void MainSB()
        {
            string s1 = "1";

            string s2 = s1;

            if(s1 == s2)
            {

            }

            string password = "admin123";

            ModifyString(password); // ModifyString method will never change my original pwd

            Hack(ref password); // as we are passing as ref 

            if(s1 == s2)
            {

            }

            //String interning
            //string interning is a technique where the CLR maintains a pool of strings in memory and reuses them to optimize memory usage. When a string literal is created, the CLR checks if an identical string already exists in the pool. If it does, it returns a reference to the existing string instead of creating a new one. This means that multiple variables can reference the same string object in memory, which can save memory and improve performance.
            // string interning is possible because string literals are immutable, so they cannot be changed after they are created. This allows the CLR to safely reuse string objects without worrying about unintended side effects.

            string a = "SOME STRING";

            string b = "SOME STRING";

            string c = "SOME STRING";

            /*
                a ─┐
                   ├──▶ "SOME STRING"
                b ─┘

             */

            //if we modify b = "SOME OTHER STRING" then it will create a new string and original b and c string will remain intact to "SOME STRING"

            StringBuilder stringBuilder = new StringBuilder();


        }

        public static void ModifyString(string pwd)
        {
            pwd = pwd + "!";
        }

        public static void Hack(ref string pwd)
        {
            pwd = pwd + "@"; // This will surely create a new string in memory but as we are passing original variable as reference, it will point to this newly created string
        }
    }
}
