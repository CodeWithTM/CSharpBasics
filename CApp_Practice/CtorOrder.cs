using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{


    internal class CtorOrder
    {
        public static void MainOrder()
        {
            Console.WriteLine("---- first touch: new FileLogger() ----");
            new FileLogger();

            Console.WriteLine("\nRegistry contents:");
            foreach (var x in Logger.Registry)
                Console.WriteLine(x);
        }
    }

    class Logger
    {
        public static List<string> Registry;

        public string LoggerName = "Base Logger";

        static Logger()
        {
            Console.WriteLine("Logger static: create registry");
            Registry = new List<string>();
            Registry.Add("ConsoleLogger");
        }

        public Logger()
        {
            Console.WriteLine("Logger instance");
        }
    }

    class FileLogger : Logger
    {



        public string LoggerType = "File";

        static FileLogger()
        {
            Console.WriteLine("FileLogger static: add FileLogger to registry");
            Registry.Add("FileLogger");
        }

        public FileLogger()
        {
            Console.WriteLine("FileLogger instance");
        }
    }
}







