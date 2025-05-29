using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Delegates
{
    //Declaring Delegate
    public delegate void PrintDel(string m);

    public delegate int CalcSumDelegate(int a, int b);
    internal class Program
    {
        public static Func<Student> stdFunc;

        static void Main(string[] args)
        {
            try
            {
                Events_Delegates events_Delegates = new Events_Delegates();
                events_Delegates.Main(args);

                //stdFunc.GetMethodInformation();

                Program p = new Program();
                // Normal metho invocation
                p.Print("normal calling");

                //Creating instance of delegate (like class object)
                PrintDel del = new PrintDel(p.Print); //instance method



                //Method invocation using Delegate
                del("calling instance method using delegate");

                del.Invoke("calling using Invoke method..");

                del.BeginInvoke("using begin invoke..", new AsyncCallback(CallBack), null);

                var invoList = del.GetInvocationList();
                MethodInfo mi = del.GetMethodInfo();


                PrintDel del1 = new PrintDel(PrintStatic);
                del1 += p.Print;

                del1("calling static method using delegate");


                Student s1 = new Student(null);
                s1.PrintScore(del);

                //stdFunc = new Func<Student>(GetStudent);
                //or
                stdFunc = GetStudent;

                stdFunc();

                CalcSumDelegate calcSumDelegate = new CalcSumDelegate(Sum);
                int sumResult = calcSumDelegate(10, 20);

                //using 'delegate' keyword
                calcSumDelegate = delegate (int a, int b) { return a + b; };

                //using lambda expression
                calcSumDelegate = (n1, n2) => n1 + n2; ;
                int sumR = calcSumDelegate(50, 50);


                //inbuild Generic delegate --
                //Func: which returns something
                //Action: which doesnt return anything

                stdFunc = delegate () { return new Student(null) { Name = "s1", Score = 100 }; };

                Student s = stdFunc();

                s.GetStudentName(); // <-- Extension method on student object

                //EXTENSION METHOD ON DELEGATE

                stdFunc.GetMethodInfo();
                //stdFunc.GetMethodInformation();

                //on delegate object we have existing extension method as : GetMethodInfo
                //which returns info regarding the method to which delegate is pointing to

                //we can create our own custom extension method and call as below -->
                del.GetMethodInformation();

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        private static void PrintStatic(string message)
        {
            Console.WriteLine(message);
        }

        private static Student GetStudent()
        {
            return new Student(null);
        }

        private static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public static void CallBack(IAsyncResult ar)
        {
            Console.WriteLine("call back method called");
        }


    }


    public class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }

        //Use of delegate - Passing function/method as parameter to another function
        //which would not possible otherwise..
        //delegate also helps in decouling of code..

        public void PrintScore(PrintDel del)
        {
            //CANNOT DIRECTLY CALL METHOD DUE TO ITS ACCESS LEVEL
            //Program.PrintStatic("student score");

            //SO WE WILL MAKE USE OF DELEGATE
            del("student score");

            //We can control the method to which delegate del is pointing to from Program class...
        }

        public Student(Func<Student> fn)
        {
            if(fn != null) // null check on delegate.. as it may not point to any function/method
                fn();
        }
    }

    public static class ExtensionHelper
    {
        public static MethodInfo GetMethodInformation(this Delegate del)
        {

            if (del == null)
                throw new ArgumentNullException("del1");

            return del.Method;

        }

        public static string GetStudentName(this Student std)
        {
            if (std == null)
                throw new ArgumentNullException("STUDENT is null");

            return std.Name;
        }
    }
}
