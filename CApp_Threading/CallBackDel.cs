using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_Threading
{
    public delegate void SumOfNumDelegate(int num);

    internal class CallBackDel
    {
        public void DispSum(int num)
        {
            Console.WriteLine(num);
        }
        public void Main(string[] args)
        {
            //Thread t2 = new Thread(() =>
            //{
            //    Method2();
            //})
            //{ Name = "Anonmous Method Thread"};

            //t2.Start();

            //Console.WriteLine("started T2");

            //t2.Join();

            Thread T3 = new Thread(() =>
            {
                Console.WriteLine("some code");
            });

            Console.WriteLine("started main");

            Thread t1 = new Thread(Method2) { Name = "T1 Thread" };
            t1.Start();

            t1.Join();

            Console.WriteLine("completed main");
            Console.ReadLine();

            //SumOfNumDelegate sumOfDel = new SumOfNumDelegate(DispSum);
            //NumberHelper nhObj = new NumberHelper(5, sumOfDel);

            //ThreadStart pts = new ThreadStart(nhObj.Method1);
            //Thread t1 = new Thread(pts) { Name = "SumThread" };

            //t1.Start();
        }

        public void Method2()
        {
            Console.WriteLine("inside m2");

            Thread t2 = new Thread(Method3) { Name = "T2 Thread" };
            t2.Start();

            t2.Join();

            Thread.Sleep(5000);

            Console.WriteLine("leaving m2");
        }

        public void Method3() {

            Thread.Sleep(3000);
        }
    }

    public class NumberHelper
    {
        private int _maxNo;
        SumOfNumDelegate _delegate;
        public NumberHelper(int max, SumOfNumDelegate del)
        {
            _maxNo = max;
            _delegate = del;
        }
        public void Method1()
        {
            int sum = 0;
            for (int i = 0; i < _maxNo; i++)
            {
                sum = sum + i;
            }

            if(_delegate != null)
            {
                _delegate(sum);
            }
        }

        public static void DispaySum(int number)
        {

        }
    }
}
