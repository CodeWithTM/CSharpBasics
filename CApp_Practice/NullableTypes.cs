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
            j = null;

            //now j is nullable(can store/accept 'null' value) value type

            Student s = new Student();
            Student s1 = null;

            int k;


            if (s1 == null) { 
            
            }
        }
    }

    public class Student
    {

    }
}
