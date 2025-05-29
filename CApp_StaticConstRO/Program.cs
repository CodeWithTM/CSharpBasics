using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_StaticConstRO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SavingAccount account = new SavingAccount();

            

            //Console.WriteLine(SavingAccount.InterestRate);

            SavingAccount.SetInterestRate();

        }
    }

    public class SavingAccount
    {
        public class BalanceDetails
        {
            public int minimumBal = 1000;
        }

        public static double InterestRate = 0.4;

        public int AccountNo;

        public const string BranchCode = "SBIN00001";

        public readonly string BranchName;

        public BalanceDetails _bd = new BalanceDetails();
        public SavingAccount()
        {
            BranchName = "MR";

            //BalanceDetails bd = new BalanceDetails();

        }
        public static void SetInterestRate()
        {
            InterestRate = 0.5;
            
            
            SavingAccount sa = new SavingAccount();
            sa.AccountNo = 1000111;

        }
    }
}
