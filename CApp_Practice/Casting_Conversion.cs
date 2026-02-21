using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//smaller to larger datatypes
// byte --> short --> int --> long --> float(single) --> double
namespace CApp_Practice
{
    public class A
    {
        public virtual void One() { }
        public void Two() { }
    }

    public class B : A
    {
        public override void One() { }
        public new void Two() { }
    }


    public class MSEmployee
    {
        public string Name { get; set; }
        public void Work() => Console.WriteLine($"{Name} is working");
    }

    public class MSDeveloper : MSEmployee
    {
        public void WriteCode() => Console.WriteLine($"{Name} is writing code");
    }

    public class MSManager : MSEmployee
    {
        public void Manage() => Console.WriteLine($"{Name} is managing the team");
    }

    internal class Casting_Conversion
    {

        public void Main()
        {

            MSEmployee mse1 = new MSEmployee() { Name = "Alice" };
            MSEmployee mse2 = new MSDeveloper() { Name = "Bob" }; // upcasting - implicit casting  (Child → Parent)
            MSEmployee mse3 = new MSManager() { Name = "Charlie" }; // upcasting - implicit casting

            // IS A relationship
            // MSDeveloper is a MSEmployee
            // MSManager is a MSEmployee

            mse1.Work();
            //mse1.WriteCode(); // ❌ not available — compiler sees mse1 as Employee only
            //mse1.Manage();    // ❌ not available — compiler sees mse1 as Employee only


            // But as i know mse2 is actually a MSDeveloper, i can cast it to MSDeveloper to access its specific methods
            ((MSDeveloper)mse2).WriteCode(); // downcasting - explicit casting
            // This will work as my assumtion hold true

            // I assume mse3 is actually a MSDeveloper, but its not, its a MSManager, so when i try to cast it to MSDeveloper it will throw an exception at runtime - InvalidCastException
            //((MSDeveloper)mse3).WriteCode(); // downcasting - explicit casting - this will throw an exception at runtime as my assumption is wrong
                                             //Here my assumption GONE WRONG and code will fail at runtime


            // you're telling compiler "trust me this is a Developer"
            // but it's actually a Manager — this will blow up at runtime
            // ❌ InvalidCastException at runtime



            // So C# language provides us safer way — use as and is

            if(mse2 is MSDeveloper dev1)
            {
                dev1.WriteCode(); // safe to access MSDeveloper specific methods
            }

            if(mse3 is MSDeveloper dev2)
            {
                // safe inside here — compiler knows it's a Developer
                dev2.WriteCode();
            }

            if(mse3 is MSManager manager1)
            {
                manager1.Manage();
            }

            MSDeveloper dotnetDev = mse2 as MSDeveloper; // this will return null if mse2 is not a MSDeveloper, but in this case it is a MSDeveloper so it will return the reference to the object

            if(dotnetDev != null)
            {
                dotnetDev.WriteCode();
            }

            MSDeveloper javaDev = mse3 as MSDeveloper; // this will return null as mse3 is not a MSDeveloper
            
            if(javaDev != null)
            {
                javaDev.WriteCode();
            }

            //is [ASK] — I want to ASK/CHECK and then use
            //as [TRY] — I want to TRY and get null if it fails

            //as only works with reference types. You cannot use it with value types like int, bool etc because they can't be null.

            object obj = 42;

            //int num1 = obj as int;   // ❌ compiler error — int can't be null
            int? num2 = obj as int?; // ✅ works with nullable value type

            //IS vs AS
            A a1 = new A();

            B b1 = a1 as B;

            a1.One();
            a1.Two();

            b1.One();
            b1.Two();

            B b = new B();

            b.One();
            b.Two();

            A a = b as A; // its equivalent to A a = b;
            
            a.One();
            a.Two();

            //IS - runtime type is compatible or not?
            object ob1 = "S";

            if(ob1 is string isTrue)
            {
                Console.WriteLine(isTrue);  // true / false
            }

            if(a is B)
            {

            }

            //AS - explicitly converts 

            //Casting 


            PetDog petDog = new PetDog() { Name = "puppy" };

            PetAnimal petAnimal = petDog; // upcasting-implicit casting


            PetDog doggy = (PetDog)petAnimal; //downcasting - explicit casting



            if (petAnimal is PetCat)
            {
                PetCat catty = (PetCat)petAnimal;
            }
            else if (petAnimal is PetDog anotherDog)
            {
                anotherDog.Bark();
            }

            PetDog dog = petAnimal as PetDog;

            if(dog != null)
            {
                dog.Bark();
            }

            // ----------------------


            DBManager dBManager = new DBManager("sa", "dbadmin123");
            //dBManager.Username = "";
            //as the username property has private setter, we cannot set the value from outside

            //dBManager.Password = "password";    //as this property dont have private setter, its accessible from outside world

            DBManager.connectionString = "Server=localhost;Database=MyDB;User Id=sa;Password=dbadmin123;"; // static member can be accessed using class name

            DBManager dbm = new SQLDBMAnager("sa", "sqladmin123", "select id from user");   // here we are doing implicit casting / upcasting - Derived class to base class


            dbm.Connect();  //even though DBManager is pointing to SQLDBMAnager, it can only access methods inside base class(i.e. DBManager)


            //dbm.ExecuteQuery(); // NOT possible

            //if we want to access method inside derived class from base class variable we need to CAST it (casting example)

            //Explicit casting / downcasting - i.e. Base class to derived class

            ((SQLDBMAnager)dbm).ExecuteQuery();

            //u can also access base class methods
            ((SQLDBMAnager)dbm).Connect();

            double d = 100.5645;
            int i = (int)d; // data loss

            int j = Convert.ToInt32(d); // floor 0.5 --> 101 /100
        }
    }

    public class DBManager
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public static string connectionString { get; set; } // static member - shared across all instances of this class
        public DBManager(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public void Connect() => Console.WriteLine("connected to DB");

        public static string GetConnString()
        {
            //we cannot access instance member variable (i.e. non static members) inside static method
            return connectionString;
        }

    }

    public class SQLDBMAnager : DBManager
    {
        public string Query { get; private set; }
        public SQLDBMAnager(string username, string password, string query) : base(username, password)
        {
            this.Query = query;
        }

        public void ExecuteQuery()
        {
            Console.WriteLine("Executing query: " + Query);
        }
    }


    //---------------------------------------------Example-----------------------


    public class PetAnimal
    {
        public string Name { get; set; } = string.Empty;

        public void Speak()
        {
            Console.WriteLine("Animal sound");
        }
    }

    public class PetDog : PetAnimal
    {
        public void Bark()
        {
            Console.WriteLine("Woof!");
        }
    }

    public class PetCat : PetAnimal
    {
        public void Meow()
        {
            Console.WriteLine("Meow!");
        }
    }


}
