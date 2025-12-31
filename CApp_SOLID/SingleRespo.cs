using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_SOLID
{

    // SOLID - Single Responsibility Principle
    // A class should have only one reason to change, meaning it should have only one job or responsibility.

    // lets take an example of Circle class which is responsible for calculating area of circle, printing the area
    //etc.

    // then we will modify this code to align to Single Responsibility Principle.

    public class CircleCls
    {
        public double Radius { get; set; }

        public CircleCls(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public void PrintArea()
        {
            Console.WriteLine("Area of Circle: " + GetArea());
        }
    }   



    internal class SingleRespo
    {
        public void SingleRespoMain()
        {
            CircleCls circle = new CircleCls(5);

            circle.GetArea();
            circle.PrintArea();

            CircleSRP circleSRP = new CircleSRP(7);
            CirclePrinter printer = new CirclePrinter();
            printer.PrintArea(circleSRP);

        }
    }

    // below is the modified code to align to Single Responsibility Principle.

    public class CircleSRP
    {
        public double Radius { get; set; }

        public CircleSRP(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class CirclePrinter
    {
        public void PrintArea(CircleSRP circle)
        {
            Console.WriteLine("Area of Circle: " + circle.GetArea());
        }
    }


}
