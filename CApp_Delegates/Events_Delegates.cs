using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Delegates
{
    //Using DELEGATES to -
    //Passing function as argument to another function
    //Returning function from another function

    //Remaning - Delegate - covariance, contravariance
    //Events

    internal class Events_Delegates
    {
        public delegate void PrintDel(int a);
        public void Main(string[] args)
        {
            PrintHelper(10, PrintMoney);

            ReturnMoney()(100);
            
        }

        public void PrintNumber(int i)
        {
            Console.WriteLine("Number is {0}", i);
        }

        public void PrintMoney(int j)
        {
            Console.WriteLine("Money is {0}", j);
        }

        public void PrintHelper(int j, PrintDel pd)
        {
            //callback fn
            pd(j);
        }

        public PrintDel ReturnMoney()
        {
            return PrintMoney;
        }
    }
}
