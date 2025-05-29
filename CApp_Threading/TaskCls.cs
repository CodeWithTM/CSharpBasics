using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_Threading
{
    class Student
    {
        public int Id { get; set; }
    }
    internal class TaskCls
    {
        public async void Main(string[] args)
        {
            try
            {

                Console.WriteLine("Main started");

                //Task.Factory.StartNew(SomeAsyncWork).Wait();

                //Task<int> t = Task.Run(() => { return SomeAsyncWork(10); });

                //Main thread will wait until child thread complete its execution

                //t.Wait();

                //Console.WriteLine("SUM: " + t.Result);
                //** t.Result WILL CAUSE MAIN THREAD TO WAIT, UNTILL CHILD THREAD RESULT IS RETURNED


                //New way of returning result from Task


                //Func<int> fn = new Func<int>(() => SumNumbers(10, 20));
                //Task<int> result = Task.Run<int>(fn);

                Action actionFn = new Action(() =>
                {
                    //SomeLongRunningWork();
                });

                Action<int> actionFn2 = new Action<int>(SomeLongRunningWork);

                Console.WriteLine("perform some other operation");

                Console.WriteLine("now make a call to fn");

                actionFn2(100);


                Action actionFn3 = new Action(() => { Console.WriteLine("inline"); });

                Task resl = Task.Run(actionFn3);


                //resl.Wait();

                //result.Wait();

                Func<int, int, int> someFnPtr = new Func<int, int, int>((a, b) => a * b);

                Func<int, int, int> someFnPtr1 = new Func<int, int, int>(SumNumbers);

                int result1 = someFnPtr(10, 20);

                Func<Student> fnStd = new Func<Student>(() => { return new Student() { Id = 101 }; });
                Task<Student> tskStd = Task.Run(fnStd);
                
                tskStd.Wait();

                
                Console.WriteLine(tskStd.Result.Id);

                Console.WriteLine("Main Completed");

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        public int SumNumbers(int q, int r)
        {
            Console.WriteLine("entering sumnumber");

            Thread.Sleep(5000);
            
            Console.WriteLine("leaving sum number");

            return q + r;

        }

        public void StartTaskUsingNew()
        {
            Console.WriteLine("Main started...");
            //Task t = new Task(SomeAsyncWork, new CancellationToken() { }) { };

            ////t.ConfigureAwait(true);

            ////t.GetAwaiter().GetResult();                

            ////
            ////schdule task run now
            ////status -- Created -> WaitingToRun --> RanToCompletion

            //Console.WriteLine("Status: " + t.Status);
            //t.Start();

            //Console.WriteLine("Status: " + t.Status);

            //t.Wait();

            //Console.WriteLine("Main completed!");
            //Console.WriteLine("Status: " + t.Status);
            //Console.ReadLine();
        }

        public int SomeAsyncWork(int max)
        {
            Console.WriteLine("started some work.. on Thread: " + Thread.CurrentThread.ManagedThreadId);
            int sum = 0;

            for (int i = 1; i <= max; i++)
            {
                sum += i;
            }
            Thread.Sleep(5000);
            Console.WriteLine("finished");
            return sum;
        }

        public void SomeLongRunningWork(int a)
        {
            Console.WriteLine("entering SomeLongRunningWork.....");

            Thread.Sleep(5000);

            Console.WriteLine("completed SomeLongRunningWork!");
        }
    }
}
