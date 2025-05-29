using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_Threading
{
    internal class ARE_MRE_MUTEX_SEMA
    {
        //private Mutex mtx = new Mutex();
        AutoResetEvent are = new AutoResetEvent(true);
        //ManualResetEvent mre = new ManualResetEvent(false);
        public void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(Writing).Start();
            }

            Console.WriteLine("main completed..");
            //mtx.ReleaseMutex();
            Console.ReadLine();
        }

        public void Writing()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "waiting");
            //mtx.WaitOne();
            are.WaitOne();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "writing");
            Thread.Sleep(5000);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "completed");
            //mtx.ReleaseMutex();
            are.Set();
        }
    }
}
