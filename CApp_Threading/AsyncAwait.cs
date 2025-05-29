using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_Threading
{
    internal class AsyncAwait
    {
        public void Main(string[] args)
        {
            //started execution on Main thread
            Method1();

            Console.WriteLine("caller..");

            //control returned to caller meanwhile async method is awating
            Thread.Sleep(3000);

            Console.WriteLine("Rest of the code in main method, Thread ID: " + Thread.CurrentThread.ManagedThreadId);

            //Continue my execution on main thread..
            Thread.Sleep(2000);

            //Continue my execution on main thread..
            Console.WriteLine("Another Rest of the code in main method, Thread ID:" + Thread.CurrentThread.ManagedThreadId);

            Console.ReadLine();
        }

        public async void Method1()
        {
            //async method started executing..
            Console.WriteLine("async method started execution..");

            Task<int> task = new Task<int>(LongRunningOperation);

            task.Start();

            //Once AWAIT keyword is encountered, execution is suspended and control return to caller method.. i.e. Main

            int r = await task; // This operation is now started on another thread..

            //once result has arreived, continue execution on another thread..
            Console.WriteLine("rest of the async method code, Thread ID:" + Thread.CurrentThread.ManagedThreadId);
        }

        public int LongRunningOperation()
        {
            Console.WriteLine("LongRunningOperation on, Thread ID:" + Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);

            return 10;
        }
    }
}
