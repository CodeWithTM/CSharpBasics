using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp
{
    internal class Program
    {
        public class MyThread
        {
            public int MyProperty { get; set; }

            public static MyThread _mThread
            {
                get
                {
                    return new MyThread();
                }
            }
        }
        private static int _Sum = 0;
        private static void Main(string[] args)
        {

            //MyThread mt = new MyThread();

            Console.WriteLine("started");

            ThreadStart ts = new ThreadStart(Method1);
            ParameterizedThreadStart pts = new ParameterizedThreadStart(Addition);
            Thread t1 = new Thread(ts);
            t1.Start();

            t1.Join();



            //t1.Suspend();

            Thread.Sleep(5000);

            //t1.Resume();

            

            Thread.Sleep(10000);

            //ThreadStart obj = () => Addition();

            //Thread t1 = new Thread(obj);
            //t1.Start();

            //Thread t2 = new Thread(obj);
            //t2.Start();

            //t1.Join();
            //t2.Join();


            //Console.WriteLine("ended, sum: " + _Sum);
            //Console.WriteLine("main & t1: " + Thread.CurrentThread.IsAlive + t1.IsAlive);
            Console.ReadLine();
        }

        private static void Method1()
        {
            Console.WriteLine("m1");
            Thread.Sleep(5000);
        }

        private static object _lock = new object();

        private static void Addition(object j)
        {
            for (int i = 0; i < 5; i++)
            {
                //Monitor.Enter(_lock);
                lock (_lock)
                {
                    _Sum++;
                }
            }
        }
    }
}