using System;
using System.Threading;

namespace CApp_Practice
{
    internal class Program
    {
        //create your own custom delegate like Func i.e. MyFunc
        //this should be declared at namespace level
        public delegate TResult MyFunc<in T1,in T2, out TResult>(T1 arg1, T2 arg2);
        static void Main(string[] args)
        {
            ConstructorOrder constructorOrder = new ConstructorOrder();
            constructorOrder.Main();

            RefOutIn.MyMain();

            object obj = 25;

            int number = (int)obj;

            //string str = (string)obj;

            //const vs readonly & static
            const_readonly.MyMain();    

            //ONLY static and const variables of class we can access by using the class name..
            Console.WriteLine(const_readonly.PROC_NAME);
            Console.WriteLine(const_readonly.Number);
            Console.WriteLine(const_readonly.GLOBAL_VAR);

            const_readonly cr = new const_readonly(100);

            Console.WriteLine(cr.CONFIG); // object reference is required for NON-STATIC field variable


            cr = new const_readonly(200);


            string_String string_String = new string_String();
            string_String.Main();

            /*
            ExceptionHandling exceptionHandling = new ExceptionHandling();
            exceptionHandling.Main();

            Casting_Conversion castingConversion = new Casting_Conversion();
            castingConversion.Main();


            TypesOfConstructors typesOfConstructors = new TypesOfConstructors();
            typesOfConstructors.Main();


            ConstructorOrder constructorOrder = new ConstructorOrder();
            constructorOrder.Main();
            
            BasicConcepts basicConcepts = new BasicConcepts();
            basicConcepts.Main();

            Unity_DI unity_DI = new Unity_DI();
            unity_DI.Main();


            DI_Prac dIPrac = new DI_Prac();
            dIPrac.Main();


            ExtensionMethods extensionMethods = new ExtensionMethods();
            extensionMethods.Main();


            LINQ_Prac lINQ_Prac = new LINQ_Prac();
            lINQ_Prac.Main();

            Collections collections = new Collections();
            collections.Main();

            GenericsAdvance genericsAdvance = new GenericsAdvance();
            genericsAdvance.Main();

            //Func Action 
            Func<int> func = () => { return 1;  };

            //Action<int, int> action = (int a, int b) => { Console.WriteLine("Action!"); };

            //Assign lambda to delegate
            MyFunc<int, int, string> myFn = (int a, int b) => (a + b).ToString();

            string s = myFn(1, 2);

            //assign anonymous fn to delegate
            MyFunc<int, int, string> f1 = delegate (int a, int b ) { return "1"; };




            DelegatesPractice delegatesPractice = new DelegatesPractice();
            delegatesPractice.PlaceOrder();


            //multicast delegates

            INotify pNotify = new PoliceNotification();
            INotify hNotify = new HospitalNotification();

            Action<string> actionDel;
            actionDel = pNotify.sendNotification;
            actionDel += hNotify.sendNotification;

            actionDel("....notification msg....");

            delegatesPractice.Drink("water");


            */

            Console.ReadLine();
        }
    }

    public class DelegatesPractice
    {
        public void PlaceOrder()
        {
            OnlineShop onlineShop = new OnlineShop();
            onlineShop.Invoice(GenerateInvoice);

            onlineShop.OrderFood(ShowStatus);

            //onlineShop.MyGeneric(ShowStatus);
        }

        public void ShowStatus(int s)
        {
            switch (s)
            {
                case 0:
                    Console.WriteLine("Order Placed..");
                    break;
                case 1:
                    Console.WriteLine("Food being prepared..");
                    break;
                case 2:
                    Console.WriteLine("Food Prepared..");
                    break;
                case 3:
                    Console.WriteLine("Handed over to Delivery partner..");
                    break;
                case 4:
                    Console.WriteLine("Delivered!..");
                    break;
            }
        }

        public void Drink(string str) => Console.WriteLine(str);


        public string GenerateInvoice(string invoiceId)
        {

            Console.WriteLine("your invoide: " + "Invoide: " + invoiceId);
            return "Invoide: " + invoiceId;
        }
    }

    public class OnlineShop
    {
        public delegate T StatusDelegate<T>(T status);

        public void OrderFood(Action<int> statusDel)
        {
            for (int i = 0; i < 5; i++) {

                Thread.Sleep(1000);

                statusDel(i);

            }

            _invoiceDel("INV001");

        }

        Func<string, string> _invoiceDel;

        public void Invoice(Func<string, string> invoiceDel)
        {
           
            Thread.Sleep(1000);

            _invoiceDel = invoiceDel;

            StatusDelegate<string> sd1 = new StatusDelegate<string>((string str) => { return "something"; });
            sd1("ABC");
        }

        public void MyGeneric(StatusDelegate<int> sd)
        {
            sd(1);
        }
    }


    interface INotify
    {
        void sendNotification(string message);
    }

    public class PoliceNotification : INotify
    {
        public void sendNotification(string message)
        {
            Console.WriteLine("police notified! " + message);
        }
    }

    public class HospitalNotification : INotify
    {
        public void sendNotification(string message)
        {
            Console.WriteLine("hosp notified! "+ message);
        }
    }
}
