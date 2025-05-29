using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Generics
{
    internal class CS_Generics
    {
        public void Main(string[] args)
        {

            var r = GenericMethod<string>("10");
            int a = 20, b = 30;

            Console.WriteLine($"Before SWAP: {a} - {b}");
            GenericSwap<int>(ref a, ref b);

            string s1 = "B", s2 = "A";

            GenericSwap<string>(ref s1, ref s2);


            Student std1 = new Student() { Id = 101, Name = "std1" };
            Student std2 = new Student() { Id = 102, Name = "std2" };

            GenericSwap<Student>(ref std1, ref std2);

            Console.WriteLine($"After SWAP: {a} - {b}");

            //Generic Collections
            List<int> lstInts = new List<int>() { 1, 2, 3, 4, 5 };
            List<string> lstStrings = new List<string>() { "1", "2", "3", "4" };
            List<Student> students = new List<Student>() { std1, std2 };

            //Non-Generic collection
            ArrayList arrayList = new ArrayList() { 1, "1", true, 2.02f, 1.001 };
            //arrayList.Add(1);
            //arrayList.Add("1");
            //arrayList.Add(true);

            float str1 = (float)arrayList[3];

            float dbt = (float)arrayList[4]; // INVALID CAST EXCEPTION
        }

        public T GenericMethod<T>(T a)
        {
            return a;
        }

        public static void GenericSwap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;                
        }

        public static void GenericSwap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static void GenericSwap(ref string a, ref string b)
        {
            string temp = a;
            a = b;
            b = temp;
        }

        public static void GenericSwap(ref Student a, ref Student b)
        {
            Student temp = a;
            a = b;
            b = temp;
        }
    }

    public class Student
    { 
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
