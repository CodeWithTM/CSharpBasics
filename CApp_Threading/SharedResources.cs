using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_Threading
{
    internal class SharedResources
    {
        public int _Sum = 0;
        public void Main(string[] args)
        {
            
            //Stopwatch stopwatch = Stopwatch.StartNew();

            Console.WriteLine("main started..");

            Thread t1 = new Thread(() => { RideOnTriCycle("kid1"); }) { Name = "T1" };
            t1.Start();

            Thread t2 = new Thread(() => { RideOnTriCycle("kid2"); }) { Name = "T2" };
            t2.Start();

            t1.Join();
            t2.Join();

            //Console.WriteLine("SUM: " + _Sum);

            //stopwatch.Stop();
            //Console.WriteLine("Time taken: " + stopwatch.ElapsedTicks);

            Console.WriteLine("main completed..");
            Console.ReadLine();

        }

        public object _lock = new object();


        private bool isTricycleInUse = false;
        public void RideOnTriCycle(string kidName)
        {
            
            lock (_lock)
            {
                if (isTricycleInUse)
                {
                    Console.WriteLine("Referee to {0}: Cycle in use", kidName);
                    Monitor.Wait(_lock);
                }

                Console.WriteLine("Referee to {0}: riding", kidName);
                isTricycleInUse = true;
            }

            Thread.Sleep(5000);

            lock (_lock)
            {
                Console.WriteLine("refree to {0}: done riding, cycle is free now", kidName);
                isTricycleInUse = false;
                Monitor.Pulse(_lock);
            }

        }
        public void Addition()
        {
            

            for (int i = 1; i<50000; i++)
            {
                //lock (_lock)
                //{
                //    Interlocked.Increment(ref _Sum);
                //    _Sum++;
                //}
                bool isLockTaken = false;

                Monitor.Enter(_lock, ref isLockTaken);
                
                try
                {
                    _Sum++;
                }
                finally
                {
                    if(isLockTaken)
                        Monitor.Exit(_lock);                    
                }

            }

            //Thread.Sleep(5000);
        }
    }
}
