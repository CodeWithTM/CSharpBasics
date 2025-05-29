using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_Threading
{
    internal class ContuniationTsk
    {
        public void Main(string[] args)
        {
            //Task t1 = Task.Run(() => { Operation1(); });

            //t1.ContinueWith((t) => { Operation2(t); });

            //t1.Start();

            Task<int> task1 = Task.Run(() =>
                                        {
                                            return Add5(10);    //add num to 5
                                        })
                                        .ContinueWith((r1) =>
                                        {
                                            return Add10(r1.Result); //add to previous task result
                                        })
                                        .ContinueWith((r2) =>
                                        {
                                            return multiply(r2.Result);
                                        });

            //task1.Wait();

            task1.ContinueWith((r3) =>
            {
                Console.WriteLine("Final Result is: " + r3.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Console.WriteLine("Final result: " + task1.Result); // Whenever we use Result, IT WILL BLOCK THE MAIN THREAD..
            Console.WriteLine("Main finished");
            Console.ReadLine();
        }

        public void Operation1()
        {
            Console.WriteLine("entering Operation1 on Thread: " + Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);

            Console.WriteLine("leaving Operation1");
        }

        public void Operation2(Task prevTask)
        {
            if(prevTask.Status == TaskStatus.RanToCompletion)
            {
                Console.WriteLine("Prev Task Completed!");
            }

            Console.WriteLine("entering Operation2 on Thread: " + Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);

            Console.WriteLine("leaving Operation2");
        }

        public int Add5(int num)
        {

            return num + 5;
        }

        public int Add10(int num)
        {
            return num + 10;
        }

        public int multiply(int num)
        {
            return num * num;
        }
    }
}
