using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    public class MathOp
    {
        private int Operator1 { get; set; }

        public MathOp() { }
        public MathOp(int op1)
        {
            Operator1 = op1;
        }

        public void Increment()
        {
            Operator1 = Operator1 + 1;
        }

    }

    internal class const_readonly
    {
        //compile time constant
        public const string PROC_NAME = ""; // we must assign a value to const variable, else it will give compile time error

        //runtime constant
        public readonly string CONFIG = "appconfig";


        //we can define readonly - ONLY at class level, we cannot define it inside a method
        public static readonly int GLOBAL_VAR; // --> 0

        public readonly int GLOBAL_VAR_MAX;


        //const and readonly variables of class type .. 
        //public const MathOp MATH_CONST = new MathOp(); // As its compile time constant, memory address not available

        public static readonly MathOp MathConst = null; // during runtime memory address will be allocated
        public static int Number { get; set; }

        //runtime constant can be initialized till constructor and NOT after that
        public const_readonly(int initialMaxValue)
        {
            Number = 0;
            GLOBAL_VAR_MAX = initialMaxValue;   // each object/instance copy will hold different value for GLOBAL_VAR_MAX,
                                                // but it CANNOT be modified once initialized

            
        }

        static const_readonly()
        {
            GLOBAL_VAR++;   // --> 1

            MathConst = new MathOp(200);

        }
        public static void MyMain()
        {
            const double PI = 3.14;

            //we cannot modify const / readonly once they are initalized..
            //PI = 3.1467;
            //GLOBAL_VAR = 10;
            
            Console.WriteLine(PI);
            
            Console.WriteLine(GLOBAL_VAR);  //GLOBAL_VAR is declared as static, so object reference is not required

            Console.WriteLine(PROC_NAME);   //but PROC_NAME in NOT declared as static,
                                            //still we can access it inside static method.. that is bcoz const variables are static INTERNALLY

            //MathConst = new MathOp(300);

            Console.WriteLine(Number);

            MathOp mathOp = new MathOp();
            mathOp.Increment();
            mathOp.Increment();

        }
    }
}
