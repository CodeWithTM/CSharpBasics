using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CApp_SOLID
{

    // SOLID - Liskov Substitution Principle

    public interface IFlyable
    {
        void Fly();
    }

    public abstract class Bird
    {
        public virtual bool HasWings { get; }

        public abstract void MakeSound();

        public int Legs { get; private set; } 

        public Bird()
        {
            Legs = 2;   
        }
    }

    public class Sparrow : Bird, IFlyable
    {
        public override bool HasWings => true;
        public void Fly()
        {
            Console.WriteLine("Can fly!");
        }

        public override void MakeSound()
        {
            Console.WriteLine("chiv chiv!");
        }

        public Sparrow()
        {

        }
    }

    public class Penguin : Bird
    {
        override public bool HasWings => true;
        public override void MakeSound()
        {
            Console.WriteLine("qack qack!");
        }

        public Penguin()
        {

        }
    }

    internal class LiskovPractice
    {

        static bool IsBirdHasWings(Bird bird) // Bird is a superclass/parent class
        {
            return bird.HasWings;
        }

        static void BirdSound(Bird bird)
        {
            bird.MakeSound();
        }

        public static void TestLiskov()
        {
            Bird kitty = new Sparrow();

            IsBirdHasWings(kitty);  //child class can be used wherever parent class is expected

            Bird pengy = new Penguin();

            IsBirdHasWings(pengy); //child class can be used wherever parent class is expected

            kitty.MakeSound();
            pengy.MakeSound();

            // So this follows Liskov Substitution Principle

            List<Bird> birds = new List<Bird>
            {
                new Sparrow(),
                new Penguin()
            };

            foreach (var bird in birds)
            {
                Console.WriteLine($"Bird has wings: {bird.HasWings}");
                if (bird is IFlyable flyableBird)
                {
                    flyableBird.Fly();
                }
                else
                {
                    Console.WriteLine($"Has Wings  {bird.HasWings}");

                    if (bird is Penguin peng)
                    {
                        peng.MakeSound();
                    }
                }
            }
        }
    }
}
