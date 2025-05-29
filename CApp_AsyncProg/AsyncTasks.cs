using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_AsyncProg
{
    public class AsyncTasks
    {

        public static async void Main1(string[] args)
        {

            Task t1 = Task.Run(() => { Thread.Sleep(5000); Console.WriteLine("T1"); });
            Task t2 = Task.Run(() => { Thread.Sleep(7000); Console.WriteLine("T2"); });

            Console.WriteLine("will wait...");

            await Task.WhenAll(t1, t2);

            Console.WriteLine("wait over!");


            Task<int> numberTask = Task.Run(() => GetNumberAsync());

            //numberTask.Wait();

            //numberTask.GetAwaiter().GetResult();

            //int i = numberTask.Result;
            ////TaskAwaiter<int> awaiter = numberTask.GetAwaiter();

            ////int num = awaiter.GetResult();

            int num = await numberTask;

            //Console.WriteLine(num);

            Console.ReadLine();
        }

        public static Task<int> GetNumberAsync()
        {
            //Thread.Sleep(2000);

            return Task.FromResult(1);
        }

    }
}
