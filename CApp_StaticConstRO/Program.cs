using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_StaticConstRO
{
    // internal means this class is accessible only within the same assembly (project)
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingAccount account = new SavingAccount();

            // Accessing a static member directly using the class name
            // Static members do not require an object
            //Console.WriteLine(SavingAccount.InterestRate);

            // Calling a static method using the class name
            SavingAccount.SetInterestRate();
        }
    }

    public class SavingAccount
    {
        // Nested class (class inside another class) Used to logically group related data
        public class BalanceDetails
        {
            // Instance variable with default value Each object of BalanceDetails will have its own copy
            public int minimumBal = 1000;
        }

        // Static variable
        // Shared across all objects of SavingAccount
        // Can be accessed without creating an object
        public static double InterestRate = 0.4;

        // Instance variable
        // Each SavingAccount object will have its own AccountNo
        public int AccountNo;

        // const variable
        // Value is fixed at compile time and cannot be changed
        // Implicitly static
        public const string BranchCode = "SBIN00001";

        // readonly variable
        // Can be assigned only once, either at declaration or inside constructor
        private readonly string BranchName;

        // Creating an object of the nested BalanceDetails class
        // This becomes part of every SavingAccount object
        public BalanceDetails _bd = new BalanceDetails();

        public SavingAccount()
        {
            // Assigning value to readonly variable
            // Allowed only inside constructor
            BranchName = "MR";

            //BalanceDetails bd = new BalanceDetails();
        }

        // Static method
        // Can access only static members directly
        // Cannot access instance members without creating an object
        public static void SetInterestRate()
        {
            // Modifying static variable
            // This change affects all SavingAccount objects
            InterestRate = 0.5;

            // Creating an object inside a static method
            // Required to access instance members
            SavingAccount sa = new SavingAccount();

            // Accessing instance variable using object reference
            sa.AccountNo = 1000111;
        }
    }

}
