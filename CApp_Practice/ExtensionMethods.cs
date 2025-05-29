using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    public class ExtensionMethods
    {

        public void Main()
        {


            string str = "Hello";

            str.ToString();

            str.Concat("World!");       // string class already has extension method with name as Concat but it will call custom defined by us..
            //string newStr = str.Concat("World!");

            Employee employee = new Employee() { EmpName = "TM" };

            employee.Display();

            //Compiler first look for this method inside Employee class and then into its base class (if any)
            //If it doesnt found it looks for method with matching signature
            employee.DisplayEmp();


            MyEx.DisplayEmp(new Employee() { EmpName = "RK" });


            //First class citizen
            //function can be assigned to variable
            //function can be pass as arg to function
            //function can be returned from function e.g. -->
            //Func<int, int> GetAddOneFunction() => x => x + 1;

            Func<int, int> GetAddOne()
            {
                //return delegate(int x) 
                //{ 
                //    return x + 1; 
                //};

                return (x) => x + 1;
            }

            var fn = GetAddOne();

            int i = fn(2);

            IEmployee e = new FTE() { type = "FTE" };            

            e.DisplayFTE();

            Employee emp = new Employee() { EmpName = "Emp1 " };
            //its possible to overload an extension method,
            //if the same method is defined inside multiple classes / in the same class..
            emp.DisplayEmp("overloaded"); 
        }


    }

    //in order to add additional functionality to Employee class we either need to modify this class
    //or create a derived class and add functionality there
    //but it needs Re-Compilation of code

    //better create Extension method - which doesnt need recompilation

    //even if we mark the class as sealed, we can still ad extension methods to it..
    public sealed class Employee
    {
        public string EmpName { get; set; }
        //public override string ToString() => $"Employee: {EmpName}";
        public void Display() => Console.WriteLine(this);
    }


    public interface IEmployee
    {
        string type {  get; set; }
    }

    public class FTE : IEmployee {
        public string type { get; set; }
    }



    public static class ExployeeExtension
    {
        //public string type { get; set; }

        public static void DisplayEmp(this Employee emp, string param)
        {
            emp.EmpName = param;

        }
    }

    public static class MyEx
    {
        public static string Concat1(this string s1, string s2)
        {
            //s1.Concat(s2);        This will cause infinite loop
            return s1 + " " + s2;
        }

        public static void DisplayEmp(this Employee emp)
        {
            Console.WriteLine(emp.EmpName);
        }

        //overloaded version of extension method..

        public static void DisplayEmp(this Employee emp, string p1, string p2)
        {
            Console.WriteLine(emp.EmpName);
        }

        public static void DisplayFTE(this IEmployee emp)
        {
            Console.WriteLine(emp.type);
        }

        //dont try to override existing methods using Extension method
        //this method will not gets called..
        public static void Display(this Employee e)
        {
            Console.WriteLine(e);
        }

        public static string ToString(this string s)
        {
            return s;
        }


    }
}
