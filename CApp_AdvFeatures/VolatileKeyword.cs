using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CApp_AdvFeatures
{
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
