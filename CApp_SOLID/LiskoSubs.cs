using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_SOLID
{
    // SOLID - Liskov Substitution Principle
    // Objects of a superclass should be replaceable with objects of its subclasses without affecting the correctness of the program.


    // Derived classes must be substitutable for their base classes.
    // Child must be substitutable for parent like in real world
    // wherever we have parent that should be replacable by their children


    public class RectangleLSP               //parent class
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    public class SquareLSP : RectangleLSP       //child class
    {
        public override int Width
        {

            get { return base.Width; }
            set
            {
                base.Width = value;
                base.Height = value;
            }
        }

        public override int Height
        {
            get { return base.Height; }
            set
            {
                base.Height = value;
                base.Width = value;
            }
        }
    }

    interface IShapeLSP
    {
        int GetArea();
    }

    public class RectangleLSP2 : IShapeLSP
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int GetArea()
        {
            return Width * Height;
        }
    }

    public class SquareLSP2 : IShapeLSP
    {
        public int Side { get; set; }

        public int GetArea()
        {
            return Side * Side;
        }
    }

    internal class LiskoSubs
    {
        public void LiskoSubsMain()
        {
            RectangleLSP rectangle = new SquareLSP();
            //So here we are trying to replace Rectangle(Parent) with Square(Child)

            rectangle.Width = 5;
            rectangle.Height = 10;  // this will set width also to 10 as per Square class logic

            Console.WriteLine("Area of Rectangle (using Square as substitute): " +
                rectangle.GetArea());

            //Output of above will be 100 instead of expected 50
            //100 is area of square with side 10
            //but we expected area of rectangle with width 5 and height 10 = 5*10 = 50

            //This shows that Square class is not substitutable for Rectangle class
            //To fix this issue, we can avoid inheritance here as Rectangle and Square are different shapes


            IShapeLSP shape = new RectangleLSP2();
            shape = new SquareLSP2();   // now both Rectangle and Square implement IShape interface
                                        // so they can be used interchangeably


            // PrintArea(rectangleLSP); --> PrintArea(squareLSP);
        }

        public void PrintArea(RectangleLSP rectangle)
        {
            Console.WriteLine("Area: " + rectangle.GetArea());
        }

        public void PrintArea(IShape rectangle)
        {
            Console.WriteLine("Area: " + rectangle.GetArea());
        }
    }




    //Below is another example where chiild can be replaced with parent without using
    //an interface

    public class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("The animal makes a sound.");
        }
    }

    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("The dog barks.");
        }
    }

    // Example usage:
    class ProgramLSP
    {
        static void MainLSP()
        {
            Animal myAnimal = new Dog(); // Child replaces parent
            myAnimal.Speak(); // Output: The dog barks.
        }
    }
}
