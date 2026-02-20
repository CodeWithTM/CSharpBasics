using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    // Private constructor
    // Only ONE instance of Logger should exist
    // So you prevent outside code from creating objects.


    internal class PrivateCtor
    {

        public static void MainPriC()
        {

            //ConsoleLogger consoleLogger = new ConsoleLogger();

            ConsoleLogger logger1 = ConsoleLogger.GetInstance();

            logger1.LogToConsole("Debug Log");

            ConsoleLogger logger2 = ConsoleLogger.GetInstance();

            Console.WriteLine("Same instance: (is singleton) " + object.ReferenceEquals(logger1, logger2));

            ConfigCache inMemeryCache = ConfigCache.GetInstance();

            inMemeryCache.AddEntry("BgColor", "Blue");

            Console.WriteLine(inMemeryCache.Get("Theme"));


            Console.WriteLine("Bank balance: " + GetBankAccountBalance(new FakeBankAccount()));

            
        }

        public static decimal GetBankAccountBalance(BankAccount accnt)
        {
            return accnt.GetAccountBalance();
        }
    }


    //“No one can create me”
    //“No one can extend me”
    public class ConsoleLogger
    {

        private static ConsoleLogger instance;

        private ConsoleLogger()
        {
            Console.WriteLine("Private ctor called!");
        }

        public static ConsoleLogger GetInstance()
        {
            if (instance == null)
                instance = new ConsoleLogger();

            return instance;
        }

        public void LogToConsole(string msg)
        {
            Console.WriteLine($"Messaged logged to console: {msg}");
        }

    }

    //public class ExtendedConsoleLogger : ConsoleLogger
    //{
    //}


    // anothe example of singleton
    class ConfigCache
    {
        private static ConfigCache _instance;

        private Dictionary<string, string> _cache;

        // 🔒 private constructor
        private ConfigCache()
        {
            Console.WriteLine("Loading config from database...");

            // simulate DB load
            _cache = new Dictionary<string, string>
            {
                { "Theme", "Dark" },
                { "PageSize", "20" }
            };
        }

        // public access point
        public static ConfigCache GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ConfigCache(); // created only once
            }
            return _instance;
        }

        public string Get(string key)
        {
            return _cache.ContainsKey(key) ? _cache[key] : null;
        }

        public void AddEntry(string key, string val)
        {
            _cache.Add(key, val);
        }
    }


    // There is a workaround where we can create instance of class with private ctor and also we can create instance of it
    // i.e. NESTED class as below:
    // so although normal inheritance is not allowed, but nested class can inherit and create instance of it
    // how to fix this? Mark class as sealted :)
    // public sealed class Office
    public class Office
    {
        private Office()
        {

        }

        public class Employee : Office
        {
            public Employee()
            {
                new Office();
            }
        }
    }

    //public class GovermentOffice : Office
    //{

    //}

    public static class StaticOffice
    {

    }

    //static class is also like a singleton, only one instance should exist
    //so static classes also restricted from inheritance, i.e. it is always sealed

    //public class GovOffice : StaticOffice
    //{

    //}



    // How to completly restrict inheritance to a class having a private constructor.
    // by defalut class with private ctor CANNOT be inherited
    // but if someone modified this class and add a public ctor then it can be inherited 
    // in order to restrict class from inheritance just mark it as sealted
    // public sealed class SealedClass
    public class SealedClass
    {
        SealedClass() { }           // private ctor

        public SealedClass(int i) { }       // someone has added public ctor, bcoz of which now this class can be inherited
    }

    public class ExtendingClass : SealedClass
    {
        public ExtendingClass() : base(3)
        {
            
        }
    }

    // Purpose of sealed class.

    // lets take below example of BankAccount, as it is not sealed, someone can inherit it and override GetAccountBalance method and return some other value, which is not expected, so in order to avoid this we can mark BankAccount class as sealed, so that no one can inherit it and override its method
    // this will cause security issue as instead of returning acount balance as 1000, it will return 9000, so in order to avoid this we can mark BankAccount class as sealed, so that no one can inherit it and override its method



    public class BankAccount
    {
        public virtual decimal GetAccountBalance()
        {
            return 1000m;
        }

        public virtual void AddBalance()
        {

        }
    }

    public class FakeBankAccount : BankAccount
    {
        public override decimal GetAccountBalance()
        {
            return 9000;
        }

        public override void AddBalance()
        {
            base.AddBalance();
        }
    }
}
