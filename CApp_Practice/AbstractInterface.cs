using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    // Interface - What you can do
    // Abstract - What you are


    // Interface - If you claim you are an IPrinter, you MUST have Print().
    // Abstract - You are a Vehicle. You share some common logic, but you still have to implement some parts yourself.

    /*
     Use an interface when:

        ✅ you want a “plug-in point”
        ✅ you want multiple unrelated classes to share a capability
        ✅ you want loose coupling
        ✅ you want dependency injection-friendly design
    
    Use an abstract class when:
        ✅ you want to share common code
        ✅ you want to enforce a base workflow
        ✅ you want shared state + helper methods
        ✅ you want partial implementation

     */
    public class AbstractInterface
    {
    }

    public interface IPaymentService
    {
        Task Pay(decimal amt);
    }

    public class PaypalPaymentService : IPaymentService
    {
        public Task Pay(decimal amt)
        {
            throw new NotImplementedException();
        }
    }

    public class GPayService : IPaymentService
    {
        public Task Pay(decimal amt)
        {
            throw new NotImplementedException();
        }
    }

    //Because PayPal and Gpay are not “the same type of object” in real life.

    //But they support the same capability: Pay.


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

        public void MakeSound() { }         // related / similar functionality
    }

    public class Dog : Animal
    {
        public new void MakeSound()
        {
            
        }
    }

    public class Cat : Animal
    {
        public new void MakeSound()
        {

        }
    }


    /*
     File processing pipeline:

    Imagine you want a standard workflow:

        1. Validate

        2. Read file

        3. Process file data

        4. Save output
     */

    public abstract class FileProcessor
    {
        public void Run(string path)
        {
            Validate(path);
            var data = Read(path);
            Process(data);
            Save(data);
        }

        protected virtual void Validate(string path) { }    // optional, you may or may not validate a file
        
        // but you have to follow all the below steps
        protected abstract string Read(string path);
        protected abstract void Process(string data);
        protected abstract void Save(string data);
    }

    public class CSVFileProcessor : FileProcessor
    {
        protected override void Process(string data)
        {
            throw new NotImplementedException();
        }

        protected override string Read(string path)
        {
            throw new NotImplementedException();
        }

        protected override void Save(string data)
        {
            throw new NotImplementedException();
        }
    }

    public class XMLFileProcessor : FileProcessor
    {
        protected override void Process(string data)
        {
            throw new NotImplementedException();
        }

        protected override string Read(string path)
        {
            throw new NotImplementedException();
        }

        protected override void Save(string data)
        {
            throw new NotImplementedException();
        }
    }

}
