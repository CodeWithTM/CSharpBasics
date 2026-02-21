using CApp_Practice;
using System;



// public, private, protected, internal, protected internal, private protected

// public - accessible from anywhere
// private - accessible only within the class
// internal - accessible within the same assembly
// protected - accessible within the class and its derived classes
// protected internal - accessible within the same assembly and from derived classes in other assemblies
// private protected - accessible within the containing class or types derived from the containing class, but only within its containing assembly


// with access modifiers we achieve ENCAPSULATION, so that misuse of data can b prevented

// default access modifier is internal for class and its members, if no access modifier is specified

//consider  this as code inside another assembly / class library project
namespace AnotherNS
{
    public class A1Modifier
    {
        public void m1()
        {
            PaymentProcessor processor = new CreditCardProcessor("4111111111111234");
            processor.ProcessPayment(99.99m);

            //so in that case as this prop is marked with internal AM, it will be accessible
            AModifier accessModifiers = new AModifier();
            accessModifiers.Name = "";
        }
    }
}

class DefaultAM // default access modifier for class is internal, so it will be accessible within the same assembly, but not from another assembly
{
    int Number { get; set; }    // default access modifier for property is private
    void M()            // then default access modifier for method is private
    {
        AModifier aModifier = new AModifier();
        aModifier.MyProperty = 1;
        aModifier.Name = "a";
    }
}

class ProtectedBase
{
    protected int ProtectedNumber { get; set; }

    private int PrivateNumber { get; set; }
}

class ProtectedDerived : ProtectedBase
{
    public void M()
    {
        //PrivateNumber = 100;
        ProtectedNumber = 10; // accessible because it's protected and we're in a derived class
    }
}

namespace CApp_Practice
{

    //with access modifiers we achieve ENCAPSULATION, so that misuse of data can b prevented

    class AccessModifiers
    {
        public void Main()
        {
            AModifier aModifier = new AModifier();

        }
    }

    public class AModifier
    {
        public AModifier() { }

        public int MyProperty { get; set; }

        internal string Name { get; set; }
        public void M()
        {
        }
    }
    //protected - within a class and its derived class

    public class DModifier : AModifier
    {
        public void M2()
        {
            MyProperty = 1;
            Name = "a";
        }

        //static method needs a obj reference..
        public static void SM()
        {
            AModifier aModifier = new AModifier();
            aModifier.MyProperty = 1;
            aModifier.Name = "a";
        }
    }

    public class D1Modifier : DModifier
    {
        public void M3()
        {
            Name = "b";
        }
    }


    //-----------------------------Examples--------------------------

    internal abstract class PaymentProcessor
    {
        // public — anyone can call this to make a payment
        public bool ProcessPayment(decimal amount)
        {
            if (!ValidateAmount(amount))
                return false;

            LogTransaction(amount);
            return ExecutePayment(amount);
        }

        // protected — child classes MUST implement their own payment logic
        // but outside world can't call this directly
        protected abstract bool ExecutePayment(decimal amount);

        // protected — child classes can use this helper, but no one outside should
        protected void LogTransaction(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount:C}");
        }

        // private — only this class handles validation, children don't need to touch it
        private bool ValidateAmount(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount cannot be zero.");

            return true;
        }
    }

    internal class CreditCardProcessor : PaymentProcessor
    {
        private string _cardNumber;

        public CreditCardProcessor(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        protected override bool ExecutePayment(decimal amount)
        {
            LogTransaction(amount); // can use the parent's protected helper
            Console.WriteLine($"Charging card ending in {_cardNumber}");
            // ... actual credit card logic
            return true;
        }
    }

    internal class PayPalProcessor : PaymentProcessor
    {
        private string _upiId;

        public PayPalProcessor(string email)
        {
            _upiId = email;
        }

        protected override bool ExecutePayment(decimal amount)
        {
            LogTransaction(amount); // same helper, reused
            Console.WriteLine($"Sending PayPal request to {_upiId}");
            // ... actual PayPal logic
            return true;
        }
    }

    /*
        PaymentProcessor processor = new CreditCardProcessor("4111111111111234");
        processor.ProcessPayment(99.99m);  // ✅ works fine

        processor.ExecutePayment(99.99m);  // ❌ compiler error — protected, not accessible here
        processor.LogTransaction(99.99m);  // ❌ compiler error — protected, not accessible here
     */


}


