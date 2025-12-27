using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAttributes
{
    internal class PrinterManager
    {
        //private static readonly Lazy<PrinterManager> _instance = new Lazy<PrinterManager>(() => new PrinterManager());

        private static readonly Lazy<PrinterManager> printerManager = new Lazy<PrinterManager>(
            () => new PrinterManager()
            );

        public static PrinterManager Instance => printerManager.Value;


        private PrinterManager() 
        {
            //add printer manager functionality
            Console.WriteLine("PrinterManager instance created.");

            // Initialize any resources or settings needed for the printer manager
           


        }

        //add generic method to print any type of document

        public void PrintDoc<T>(T document)
        {
            Console.WriteLine($"Printing document of type: {typeof(T).Name}");
            // Add logic to handle printing the document based on its type
        }

        public void PrintDoc()
        {
            Console.WriteLine("printing doc");
        }
    }
}
