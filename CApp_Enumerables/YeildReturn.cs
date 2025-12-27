using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Enumerables
{
    internal class YeildReturn
    {
        //Yield return is used to provide a value to the enumerator object or iterator object
        //create one sample example to demonstrate yeild return
        public IEnumerable<int> GetEvenNumbers(int max)
        {
            for (int i = 0; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    yield return i; //yield return is used to return the value to the enumerator object
                }
            }
        }

        //create one sample example to demonstrate yeild break
        public IEnumerable<int> GetNumbersUntil(int max, int breakAt)
        {
            for (int i = 0; i <= max; i++)
            {
                if (i == breakAt)
                {
                    yield break; //yield break is used to exit the iterator method
                }
                yield return i;
            }
        }

        //create one sample example to demonstrate yeild return with custom object
        public IEnumerable<Employee> GetEmployees()
        {
            yield return new Employee() { Id = 1, Name = "John" };
            yield return new Employee() { Id = 2, Name = "Jane" };
            yield return new Employee() { Id = 3, Name = "Doe" };
        }

        //show me how to consume above methods
        public void GetYieldReturn()
        {
            Console.WriteLine("Even Numbers up to 10:");

            var evenNumbers = GetEvenNumbers(10); //method is not executed here
            foreach (var num in evenNumbers)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nNumbers until break at 5:");
            foreach (var num in GetNumbersUntil(10, 5))
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nEmployees:");
            foreach (var emp in GetEmployees())
            {
                Console.WriteLine(emp);
            }
        }
    }

    //show me example of defualt interface method for IAccount interface
    public interface IAccount
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);

        //default interface method
        //void DisplayBalance()
        //{
        //    Console.WriteLine("Default Balance: 0");
        //}
    }



}
