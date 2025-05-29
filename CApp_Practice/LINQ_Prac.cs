using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_Practice
{
    public class LINQ_Prac
    {
        public void Main()
        {
            int[] numArray = { 1, 2 };

            int c = numArray.Count();
            //Count() is an Extension method on IEquatable<T>
            //and as int class inherits from IEquatable<int>, it has use this method
            //public struct Int32 : IComparable, IFormattable, IConvertible, IComparable<int>, IEquatable<int> {}

            int len = numArray.Length;

            //Length is a property on Array class
            //when you create an array of integers, such as int[] numArray = new int[5];,
            //the numArray variable is actually an instance of the System.Array class.

            //so if u check all the properties/methods inside numArray using numArray. then they are
            // -> Either coming from IEnumerable as extension methods
            // -> or from Array class

            string[] strArray = new string[] { "1", "2", "3" };

            List<int> numberLst = new List<int>() { 1, 2, 3, 4, 5 };


            int lc = numberLst.Count;       // O(1) operation
            //here Count is a property of List class
            //It is a simple getter that returns the value of a private field _size that keeps track of the number of elements in the list.
            //Accessing Count does not incur any additional overhead, as it simply returns the value of the private field.
            
            numberLst.Count();      // O(n) operation
            //here Count() is a extension method on Enumerable
            //Accessing Count() incurs additional overhead, as it creates an enumerator and iterates over the sequence to count the elements.


            //In general, if you have a List<int> and you need to get the count of elements, it is more efficient to use the Count property. However,
            //if you have a sequence that does not implement ICollection<T> (such as an array or a LINQ query), you may need to use the Count() method.
            //List<int> largeNumberLst = new List<int>();

            //for (int i = 0; i < 5000000; i++)
            //{
            //    largeNumberLst.Add(i);
            //}

            //LogTimeToConsole(() => { int count = largeNumberLst.Count; });

            //LogTimeToConsole(() => { largeNumberLst.Count(); });


            workingWithEnumerable(new int[] {1,1});


            

            SortedList sl= new SortedList();
            sl.Add("2", 3);
            sl.Add("1", 5);
            sl.Add("3", 1);

            Console.ReadLine();
        }

        public void workingwithArrays()
        {
            int[] numbersArray = { 1, 2, 3, 4, 5 };

            int[] numbersArray2 = new int[3];

            int[] numbersArray3 = new int[] { 1, 2, 3, 4, 5 };

            int[] numbersArray4 = new int[2] { 2, 2 };

            var e = numbersArray.AsEnumerable();

        }

        public void workingWithEnumerable(int[] ints)
        {
            string str = "ABCD";
            foreach (var s in str)
            {
                Console.WriteLine(s);
            }


            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 4, 3, 2, 10, 10 };

            list.ForEach(s => Console.WriteLine(s));

            //ForEach method is availble only in List.


            IEnumerable<int> distinctList = list.Distinct<int>();

            IEqualityComparer<int> eqComparer = new CustomeEqualityComparer();

            var dist = list.Distinct(eqComparer);

            var s1 = list.Select(a => a);
            var s2 = list.Select(a => a > 2);

            //list.SelectMany<int, int>((a,b) => a);
            

            //int first = ints.First(a => a > 10);

            int firstorDefault = ints.FirstOrDefault();

            firstorDefault = ints.FirstOrDefault(a => a > 10);

            //int single = ints.Single(); //Exception - sequence contains more than 1 element

            int single = list.Single(a => a == 5);

            //single = list.SingleOrDefault(a => a == 10); // Exception - as 2 elements/items matching this criteria


            //aggregate
            bool any = list.Any(a => a == 50); // if Any 1 element matches this condition it returns true

            bool all = list.All(a => a > 0); // only if all the elements match this condition then it returns true

            list.Find(a => a == 50);

            
        }

        public void LogTimeToConsole(Action longRunningOperation)
        {
            Stopwatch sw = new Stopwatch(); 
            sw.Start();
            
            longRunningOperation();
            
            sw.Stop();
            TimeSpan elapsedTime2 = sw.Elapsed;
            Console.WriteLine("Elapsed: " + elapsedTime2.TotalMilliseconds);
        }


    }

    public class CustomeEqualityComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            if(x > 4)
                return false;

            return x == y;
        }

        public int GetHashCode(int obj)
        {
            return obj;
        }
    }
}
