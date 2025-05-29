using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_AsyncProg
{
    public class AsyncAwait
    {
        public async Task Main1(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            //Task<string> clothsTask = WashCloths();

            //string cloths = await WashCloths();

            ////string s = await clothsTask;

            //await DryCloths(cloths);

            //await CleanHouse();

            //await CookFood();

            //Task<string> clths = WashCloths();

            //Task t1 = DryCloths(clths.Result); // AVOID using .Wait() or .Result as it waits syncronously and halts prog execution.. here

            Task t1 = WashAndDryCloths();

            Task t2 = CleanHouse();

            Task t3 = CookFood();

            await Task.WhenAll(t1, t2, t3);

            //Task.WaitAll(t1, t2, t3);

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            Console.WriteLine($"Completed in : {string.Format("{0}:{1}", Math.Floor(ts.TotalMinutes), ts.ToString("ss\\.ff"))}");

            Console.ReadLine();
        }

        private async Task WashAndDryCloths()
        {
            string clths = await WashCloths();

            await DryCloths(clths);            
        }

        private async Task<string> WashCloths()
        {
            Console.WriteLine("Washing cloths!");

            await Task.Delay(3000);

            Console.WriteLine("Completed washing cloths!");

            return "Wet cloths";
        }

        private async Task DryCloths(string cloths)
        {
            Console.WriteLine("Drying cloths!");

            await Task.Delay(1000);

            Console.WriteLine("Completed drying cloths!");
        }

        private async Task CleanHouse()
        {
            Console.WriteLine("Cleaning house!");

            await Task.Delay(4000);

            Console.WriteLine("Completed Cleaning house!");
        }

        private async Task CookFood()
        {
            Console.WriteLine("Cooking food!");

            await Task.Delay(5000);

            Console.WriteLine("Completed Cooking food!");
        }

    }
}
