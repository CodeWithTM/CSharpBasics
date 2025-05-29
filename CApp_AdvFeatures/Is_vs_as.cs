using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace CApp_AdvFeatures
{
    internal class Is_vs_as
    {
        public void Main(string[] args)
        {

            object obj = 1;
            object boolValue = false;

            // is - type comparison operator
            // it returns boolean value
            bool b1 = obj is int;

            bool b2 = obj is string;

            bool b3 = boolValue is bool;

            string str2 = "";
            if (str2 is object) //this will evaluate to true
            {

            }

            string str1 = null;
            if (str1 is object) //this will evaluate to false ****  
            {

            }

            int? i = 0;  //older way -- Nullable<int> j = 0;

            i = GetSomeValue(20);
            if (i is int)
            {

            }

            string str3 = "ABC";

            //explicitly convert an expression to given TYPE (value/reference)
            //if conversion isn't possible then it returns null

            object obj3 = str3 as object;

            Car car1 = new Car();
            object obj4 = car1;

            string str4 = (string)obj4;
            string str5 = obj4 as string;


            Vehicle vehicle = new Vehicle();
            Car car = new Car();

            if(car is Vehicle)
            {

            }

            vehicle = car as Vehicle;

        }

        public int? GetSomeValue(int age)
        {
            if (age > 18)
                return age;

            return null;
        }
    }

    public class Vehicle
    { 
    }

    public class Car : Vehicle
    { 
    
    }

}
