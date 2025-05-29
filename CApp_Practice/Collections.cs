using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    public class TODO { }
    public class Collections
    {

        public DbSet<TODO> _todos;
        public IEnumerable<int> GetData()
        {
            Console.WriteLine("Num1");
            yield return 1;

            Console.WriteLine("Num2");
            yield return 2;

            Console.WriteLine("Num3");
            yield return 3;

            Console.WriteLine("Num4");
            yield return 4;
        }
        public void Main()
        {

            //At this point GetData() method will not get called
            //rather it will get called once we start iterating over the collection i.e. below foreach statement
            var Num = GetData().Where(w1 =>
            {
                Console.WriteLine("check: {0}", w1.ToString());
                return w1 > 0;
            }).Select(s1 =>
            {
                Console.WriteLine("select: {0}", s1.ToString());
                return s1;
            });

            //.ToList(); VVV Imp
            //if we just call ToList() - then GetData will get called there and there only..


            //Also do remember that .Where and .Select extension methods will get called for each value
            //i.e. once number 1 is yield returned, then that 1 is paased to Where and then to Select method and so on..

            foreach (var item in Num)                               //This will call GetData() method
            {
                Console.WriteLine("Iterate: {0}", item.ToString());
            }


            //IEnumerable - non Generic version
            //IEnumerable<T> - Generic version
            IEnumerable myEnumerable = new MyEnumerable();

            IEnumerable myEnumerable2 = new MyEnumerable() { _val = 2 };

            foreach (var number in myEnumerable2) //myEnumerable2 should have method with name GetEnumerator
            {

            }

            ArrayList aList = new ArrayList();
            aList.Add(1);
            aList.Add("2");

            var e = aList.GetEnumerator();

            var strList = aList.Cast<string>();


            Hashtable ht = new Hashtable();
            ht.Add(1, "1");
            ht.Add("2", "2");

            Queue q1 = new Queue();         // FIFO -- this is from System.Collections namespace
            q1.Enqueue("1");
            q1.Enqueue(2);

            Queue<int> q2 = new Queue<int>();       // this is from System.Collections.Generic namespace

            q2.Enqueue(1);
            //q2.Enqueue("2");

            //Stack and Stack<int>      // LIFO

            List<int> list = new List<int>();
            list.Add(1);


            MyCollection myCollection = new MyCollection();

            foreach (var c in myCollection)
            {
                Console.WriteLine(c);
            }

            IEnumerable<int> ints = new List<int>() { 5, 2, 3, 4, 1 };


            var orderedints = ints.OrderBy(a => a);


            ICollection<int> ints1 = new List<int>() { 1, 2, 3, 4, 5 };

            GenericDisplay2(ints1);
            //GenericDisplay1(ints1); // NOT allowed

            IList<int> ints2 = new List<int>() { 1, 3, 2, 4, };

            GenericDisplay1(ints2);
            GenericDisplay2(ints2); // Allowed

            int i = ints2[0];

            ints2.Add(5); // Add() method is availble/inherited from ICollection interface
            ints2.Average(); // Average() is an extension method on IEnumerable interface and its availble on variable of type IList and IList inherits from IEnumerable


            MyComparer comparer = new MyComparer();
            //int r = comparer.Compare(2,2);

            IList<int> numbers = new List<int> { 3, 1, 4, 2, 5 };

            //numbers.Sort();

            var newList = numbers.ToList();

            newList.Sort(0, 3, comparer);

            newList.Sort(comparer);

            //OR
            newList.Sort(CustomComparer.Default);

            Console.WriteLine(string.Join(", ", numbers));

            foreach (var c in ints1)
            {

            }

            List<string> strings = new List<string>() { "1", "3", "2" };

            strings.Sort();

            strings.Sort(Comparer<string>.Default); // Default is a static prop on Comparer<T> class which applied defaulting sorting for Type - T


            foreach (var c in ints2)
            {

            }

            IQueryable<int> qints = (new List<int>() { 1, 2, 4, 3 }).AsQueryable();

            IQueryable<bool> filtered = qints.Select(x => x > 3);
            foreach (var c in filtered)
            {

            }
            IEnumerable<int> eints = new List<int>() { 1, 2, 3, 4, 5 };

        }

        public void GenericDisplay1(IList<int> c)
        {
            foreach (var item in c)
            {
                Console.WriteLine( item);
            }
        }

        public void GenericDisplay2(ICollection<int> c)
        {
            foreach (var item in c)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class MyComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }

    public class CustomComparer : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            
            return y.CompareTo(x);
        }
    }



    public class MyEnumerable : IEnumerable
    {
        public int _val;
        public MyEnumerable(int i = 0)
        {
            _val = i;
        }
        public List<int> intNumbers = new List<int>() { 1, 2, 3, 4, 5 };

        public IEnumerator GetNumbers() => intNumbers.GetEnumerator();

        //public IEnumerator GetNumbers() { return intNumbers.GetEnumerator(); }
        public IEnumerator GetData()
        {
            Console.WriteLine("1");
            yield return 1;

            Console.WriteLine("2");
            yield return 2;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(_val);
        }
    }

    public class MyEnumerator : IEnumerator
    {
        public List<int> _intNumbers;

        public int _val = 1;
        public object Current => _val++;

        public MyEnumerator() { }
        public MyEnumerator(int initialVal = 0)
        {
            _val = initialVal;
        }
        public bool MoveNext()
        {
            if (_val <= 5)
                return true;
            return false;
        }

        public void Reset()
        {
            _val = 1;
        }


    }

    public class MyCollection : IEnumerable
    {
        public IEnumerable<int> list = new List<int>() { 1, 2, 3, 4, 5 };
        public IEnumerator GetEnumerator()
        {
            foreach (var c in list)
            {
                yield return c;
            }
            //yield return list;
            //return list.GetEnumerator();
        }
    }
}
