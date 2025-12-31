using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_SOLID
{

    // SOLID - Open /Closed Principle

    // Demonstrate an example of Open close principle, with the help of Circle Rectangle classes.
    // The Open/Closed Principle states that software entities (classes, modules, functions, etc.) should be open for extension but closed for modification.


    // lets take below example, where I have a Circle class and Print class.
    // Client is using this classes to get area of circle and print it.
    class Circle
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Print
    {
        public void PrintArea(Circle circle)
        {
            Console.WriteLine("Area of Circle: " + circle.GetArea());
        }
    }

    // Now there is requirement to support 1 more Shape i.e. Rectangle.
    // To support this requirement, we can create a new Rectangle class without modifying the existing Circle and Print classes.

    class Rectangle
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            return Width * Height;
        }
    }   

    internal class OpenClose
    {
        static void MainMethod(string[] args)
        {
            Circle circle = new Circle(5);
            Print print = new Print();
            print.PrintArea(circle);

            Rectangle rectangle = new Rectangle(4, 6);
            Print printRect = new Print();
            // now my existing implementation is modifying the existing Print class to support new shape Rectangle.
            // which is violating the Open/Close principle.
            //printRect.PrintArea(rectangle);

            IShape circleV2 = new CircleV2(5);
            IShape rectangleV2 = new RectangleV2(4, 6);

            PrintV2 printV2 = new PrintV2();
            printV2.PrintArea(circleV2);
            printV2.PrintArea(rectangleV2);


            // now we are aligned to open close principle,
            // as we are able to extend the functionality by adding new shapes without modifying the existing code.
        }
    }

    // in order to align to open close principle, we can create an interface IShape with method GetArea.
    interface IShape
    {
        double GetArea();
    }

    class CircleV2 : IShape
    {
        public double Radius { get; set; }

        public CircleV2(double radius)
        {
            Radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class RectangleV2 : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public RectangleV2(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            return Width * Height;
        }
    }

    class PrintV2
    {
        public void PrintArea(IShape shape)
        {
            Console.WriteLine("Area: " + shape.GetArea());
        }
    }


}
