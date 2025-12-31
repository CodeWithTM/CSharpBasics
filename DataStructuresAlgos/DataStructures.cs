using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAlgos
{

    //Various data strctures in C#

    //List down all the data structures available in C#
    // Array
    // ArrayList
    // List
    // Dictionary
    // HashSet
    // Queue
    // Stack
    // LinkedList
    // ConcurrentDictionary
    // ObservableCollection
    // Hashtable
    // NameValueCollection

    // For each data structure, provide a brief description and a simple example of how to use it.

    // example for Array
    public class ArrayExample
    {
        public void Example()
        {
            // Declare and initialize an array
            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            // Access elements
            int firstNumber = numbers[0];

            // Iterate through the array
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }


            // Arrays have a fixed size, so to add or remove elements, you need to create a new array
            Console.WriteLine();
        }
    }

    public class ArrayListExample
    {
        public void Example()
        {

            // Add respective comments for O(n) O(1)
            // ArrayList is a non-generic collection that can hold elements of any type.

            // Declare and initialize an ArrayList
            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();

            // Add elements
            arrayList.Add(1);
            arrayList.Add("Hello");
            arrayList.Add(3.14);    // Adding different types of elements
            // 

            // Access elements
            var firstElement = arrayList[0];

            // Iterate through the ArrayList
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            // ArrayLists can hold elements of different types
            Console.WriteLine();
        }
    }

    internal class DataStructures
    {
    }
}
