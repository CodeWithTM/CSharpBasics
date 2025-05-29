using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

//smaller to larger datatypes
// byte --> short --> int --> long --> float --> double
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

    internal class Casting_Conversion
    {

        public void Main()
        {

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


            DBManager dBManager = new DBManager("", "");
            //dBManager.Username = "";
            //as the username property has private setter, we cannot set the value from outside

            dBManager.Password = "password";    //as this property dont have private setter, its accessible from outside world


            DBManager dbm = new SQLDBMAnager("", "", "");   // here we are doing implicit casting / upcasting - Derived class to base class


            dbm.Connect();  //even though DBManager is pointing to SQLDBMAnager, it can only access methods inside base class(i.e. DBManager)

            //if we want to access method inside derived class from base class variable we need to CAST it (casting example)

            //Explicit casting / downcasting - i.e. Base class to derived class
            
            ((SQLDBMAnager)dbm).ExecuteQuery("");

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
        public string Password { get; set; }
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

        public void ExecuteQuery(string query)
        {
            Console.WriteLine("Executing query: " + query);
        }
    }

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
