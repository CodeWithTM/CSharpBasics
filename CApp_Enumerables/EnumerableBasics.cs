using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CApp_Enumerables
{
    internal class EnumerableBasics
    {
        //Linq, Extension methods, Lambda expression
        public void Main(string[] args)
        {

            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            var f = list.Where<int>((n) => n % 2 == 0);

            list.Add(8);

            foreach (var item in f)
            {
                Console.WriteLine(item);
            }
            //List generic collection is available in System.Collections.Generic namespace

            IEnumerable<int> filteredList = list.Where(n => n % 2 == 0);    // AT THIS POINT RESULT IS NOT EVALUATED
            //Where extension method on list variable is available ONLY after we add System.Linq namespace

            IEnumerable<int> filteredListNow = (list.Where(n => n % 2 == 0)).ToList(); //RESULT IS EVALUATED HERE ITSELF

            IEnumerable<int> linqFilteredList = from num in list
                                                where num % 2 == 0
                                                select num;

            list.Add(8);

            //deferred execution
            //once we start iterating over the filtered collection then only above collection is evaluated
            foreach (var item in filteredList)
            {
                Console.WriteLine(item);
            }

            foreach (var item in linqFilteredList)
            { Console.WriteLine(item); }


            List<Employee> employees = new List<Employee>() { new Employee() { Id = 101, Name = "E1" } };

            IEnumerable<Employee> filteredEmp = employees.Where<Employee>((e) => e.CompareTo(e) == 0);

            foreach (var fe in filteredEmp)
            {
                Console.WriteLine(fe.ToString());
            }

            Console.ReadLine();
            
        }
    }


    public class Employee : IComparable<Employee>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(Employee other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public override string ToString()
        {
            return $"{this.Id} -- {this.Name}";
        }
    }

    public static class Extensions
    {
        public static List<T> Where<T>(this List<T> source, Func<T, bool> func) where T : IComparable<T>
        {
            List<T> filteredList = new List<T>();
            foreach (var item in source)
            {
                if (func(item))
                {
                    filteredList.Add(item);
                }
            }
            return filteredList;
        }
    }
}
