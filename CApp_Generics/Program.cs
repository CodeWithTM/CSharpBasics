using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Generics
{
    internal class Program
    {
        public static double InterestRate = 0.1;
        public int Count = 0;
        static void Main(string[] args)
        {
            InterestRate = 0.2;

            
            Program p = new Program();
            p.Count++;

            IncrementCount();

            //Generics_Advance adv = new Generics_Advance();
            //adv.Main(args);

            //Generics_Basic gen = new Generics_Basic();
            //gen.Main(args);


            //CS_Generics cS_Generics = new CS_Generics();
            //cS_Generics.Main(args);

        }

        public static void IncrementCount()
        {
            InterestRate = 0.5;

            //Count++;

            Program p1 = new Program();
            p1.Count++;
        }
    }
}
