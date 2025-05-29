using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    public class AbstractInterface
    {
    }

    public interface IAnimal
    {
        //string Name { get; set; }

        void MakeSound();

        //interface can have properties but no fields
        int MyProperty { get; set; }
    }

    public class Animal : IAnimal
    {
        //we may or may not provide implementation for getter and setter

        //public int MyProperty { get; set; }
        public int MyProperty { get { return MyProp; } set { MyProp = value; } }

        private int MyProp;        

        public void MakeSound() { } 
    }

    public class Dog : Animal
    {
        public new void MakeSound()
        {

        }
    }
}
