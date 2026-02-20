using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_AdvFeatures
{

    /*
     volatile tells C#:

    “This variable can change anytime by another thread,
    so don’t cache it in a register. Always read the latest value from memory.”

    
    Because in multithreading, this can happen:

        Thread A updates a variable

        Thread B keeps reading an old cached copy

        So Thread B never sees the change



    Thread 1 -- Thread 1 Cache

    Thread 2 -- Thread 2 Cache

    When your program runs, each CPU core (and each thread running on it) tries to be fast.

    So instead of reading a variable from RAM every time (slow), the CPU may: CPU cache (L1/L2/L3), and/or CPU Register

    So a thread might keep using its own copy of the value (i.e. from its own cache).

    in order to overcome this we make that variable as volatile..
     */
    internal class VolatileKeyword
    {
        public volatile bool isLock = true;
        public static int[] arr = new int[] { 1,2,3,4,5};
        public static void Main1(string[] args)
        {

            int val = M1(Convert.ToInt16(Console.ReadLine()));

            Console.WriteLine($"number: {val}");
            //VolatileKeyword p1 = new VolatileKeyword();

            //ParameterizedThreadStart pts = new ParameterizedThreadStart(DoWork);
            //Thread t1 = new Thread(pts);
            //t1.Start(p1.isLock);

            //Thread.Sleep(5000);

            //p1.isLock = false;

            Console.ReadLine();
        }

        public static int M1(int index)
        {
            try
            {
                return M2(index);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        public static int M2(int index)
        {
            try
            {
                return arr[index];
            }
            catch (Exception)
            {
                //return 0;
                throw;
            }
            

        }

        public static void DoWork(object isLock)
        {
            Console.WriteLine("started doing work...");

            while ((bool)isLock)
            {

            }

            Console.WriteLine("completed work!");
        }

    }
}
