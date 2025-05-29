using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Generics
{
    internal class Generics_Advance
    {
        public void Main(string[] args)
        {
            //string[] strArray = new string[] { "A", "Z", "D","C" };

            int[] intArray = new int[] { 2, 4, 1, 5, 3 };

            Employee[] empArray = new Employee[] {
                                                    new Employee(){ Id=101, Name = "E1" },
                                                    new Employee(){ Id=103, Name = "E3"},
                                                    new Employee(){ Id=102, Name = "E2"}
            };

            SortArray sortArray = new SortArray();

            //sortArray.BubbleSort(empArray);

            foreach (object obj in empArray)
                Console.WriteLine(((Employee)obj).ToString()); //this will call overriden ToString method instead of ToString virtual method of Object class


            SortArray<Employee> sortArray1 = new SortArray<Employee>();
            sortArray1.BubbleSort(empArray);

            SortArray<int> sortArray2 = new SortArray<int>();
            sortArray2.BubbleSort(intArray);

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
            return this.Id + "-" + this.Name;
        }

        //overriding below virtual method from Object class--

        //[__DynamicallyInvokable]
        //public virtual string ToString()
        //{
        //    return GetType().ToString();
        //}

    }

    public class SortArray
    {
        public void BubbleSort(object[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < (n - 1); i++)
            {
                for (int j = 0; j < (n - i - 1); j++)
                {
                    //Int32 class implements IComparable & IComparable<Int32> interface
                    //String class implements IComparable interface
                    //Custom class Employee also implements IComparable interface and provide its own implementation for CompareTo method

                    //we can typecase object of int/string/employee class to interface type
                    //as these classes inherit / implement from interface type-IComparable
                    if (((IComparable)arr[j]).CompareTo(arr[j + 1]) > 0)
                    {
                        swap(arr, j);
                    }
                }
            }

        }

        private void swap(object[] arr, int j)
        {
            object temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
        }
    }

    public class SortArray<T> where T : IComparable<T>
    {
        public void BubbleSort(T[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < (n - 1); i++)
            {
                for (int j = 0; j < (n - i - 1); j++)
                {
                    if ((arr[j]).CompareTo(arr[j + 1]) > 0)
                    {
                        swap(arr, j);
                    }
                }
            }

        }

        private void swap(T[] arr, int j)
        {
            T temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
        }
    }
}
