using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_SOLID
{
    // SOLID - Interface Segregation Principle

    // Classes should not be forced to implement interfaces they do not use.

    // This principle aims to keep interfaces small and specific to the clients that use them, rather than having large, general-purpose interfaces.

    // For example, consider an interface that defines methods for both printing and scanning documents.
    // A class that only needs to print documents should not be forced to implement the scanning methods.
    // Instead, we can create separate interfaces for printing and scanning.


    public interface IShapeISP
    {
        double GetArea();
    }

    public class CircleISP : IShapeISP
    {
        public double Radius { get; set; }

        public CircleISP(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Cube : IShapeISP
    {
        public double SideLength { get; set; }
        public double GetArea()     // but in case of Cube this method is not relevant, bcoz for cube we need surface area and volume methods
                                    // so cube is forced to implement this method which is not relevant
        {
            return 0;
        }

        public double GetVolume()   // so to resolve this we can create separate interfaces for 3D shapes
        {
            return SideLength * SideLength * SideLength;
        }
    }

    public interface IShape3DISP
    {
        double GetVolume();
        double GetSurfaceArea();
    }

    public class CubeISP : IShape3DISP
    {
        public double SideLength { get; set; }

        public double GetVolume()
        {
            return SideLength * SideLength * SideLength;
        }

        public double GetSurfaceArea()
        {
            return 6 * SideLength * SideLength;
        }
    }

    internal class InterfaceSeg
    {
    }

    //Suppose you have different types of printers—some can print, some can scan, and some can fax. Instead of one big interface, you split responsibilities.
    //DONT use 1 big interface

    public interface IPrinter
    {
        void Print(string document);
    }

    public interface IScanner
    {
        void Scan(string document);
    }

    public interface IFax
    {
        void Fax(string document);
    }

    // A simple printer only prints
    public class SimplePrinter : IPrinter
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing: {document}");
        }
    }

    // A multi-function printer can print, scan, and fax
    public class MultiFunctionPrinter : IPrinter, IScanner, IFax
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing: {document}");
        }

        public void Scan(string document)
        {
            Console.WriteLine($"Scanning: {document}");
        }

        public void Fax(string document)
        {
            Console.WriteLine($"Faxing: {document}");
        }
    }
}
