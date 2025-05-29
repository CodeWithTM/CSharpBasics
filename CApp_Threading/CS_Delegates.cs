using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Threading
{
    public delegate int VoidDelegate(int a);
    internal class CS_Delegates
    {
        public void Main(string[] args)
        {
            VoidDelegate voidDel = new VoidDelegate(Method3);

            Func<int, int> funcDel = new Func<int, int>(Method3);
            int result = funcDel(2);

            Func<int, int> fnDel = new Func<int, int>((n) => n*n);
            int dbl = fnDel(5);

            Func<int, int> fn = delegate (int a) { return a*a; };
            int f = fn(10);

            Action<int> actionDel = delegate (int num) { Console.WriteLine(num); };
            actionDel(20);

            StudentDetails.GetScore(voidDel);
        }

        private void Method1()
        {
            Console.WriteLine("method1");
        }

        private void Method2()
        {
            Console.WriteLine("method 2");
        }

        private int Method3(int num) {
            return num * 2;
        }
    }

    public class StudentDetails
    {

        public static void GetScore(VoidDelegate del)
        {
            int result = del(5);
        }
    }
}
