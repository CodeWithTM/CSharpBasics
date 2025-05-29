using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Practice
{
    public class DI_Prac
    {
        public void Main()
        {
            Scope s1 = new Scope();
            Scope s2 = new Scope();

            //Transient provider
            //each time a new instance if login service is created
            //LoginService ls1 = s1.TransientProvider.GetInstance();
            //LoginService ls2 = s1.TransientProvider.GetInstance();
            //LoginService ls3 = s2.TransientProvider.GetInstance();
            //LoginService ls4 = s2.TransientProvider.GetInstance();

            //Singletone provider
            //only one instance of login service is created
            //even if scope changes i.e. request is coming from 2 different http requests
            //LoginService ls1 = s1.SingletoneProvider.GetInstance();
            //LoginService ls2 = s1.SingletoneProvider.GetInstance();
            //LoginService ls3 = s2.SingletoneProvider.GetInstance();
            //LoginService ls4 = s2.SingletoneProvider.GetInstance();

            //Scopped provider
            //only one instnce of login service is created for a defined scope.
            //if scope changes again new instance of login service is creaated.
            //e.g. for 1 http request if we use login service multiple times then same instance of login service will be used
            //if request comes for another http request then same instance of login service is used for that http request
            LoginService ls1 = s1.ScopedProvider.GetInstance();
            LoginService ls2 = s1.ScopedProvider.GetInstance();
            LoginService ls3 = s2.ScopedProvider.GetInstance();
            LoginService ls4 = s2.ScopedProvider.GetInstance();


            Console.WriteLine(ls1.ID);
            Console.WriteLine(ls2.ID);
            Console.WriteLine(ls3.ID);
            Console.WriteLine(ls4.ID);


            Console.ReadLine();
        }
    }


    public class Scope
    {
        public IServiceProvider TransientProvider { get; }
        public IServiceProvider SingletoneProvider { get; }
        public IServiceProvider ScopedProvider { get; }

        public Scope() {
            TransientProvider = new TransientProvider();
            SingletoneProvider = new SingletonProvider();
            ScopedProvider = new ScopedProvider();
        }
    }

    public interface IServiceProvider
    {
        LoginService GetInstance();
    }

    public class TransientProvider : IServiceProvider
    {
        public LoginService GetInstance()
        {
            return new LoginService();
        }
    }
    public class SingletonProvider : IServiceProvider
    {
        public static LoginService LoginService = null;
        public LoginService GetInstance()
        {
            if (LoginService == null)
                LoginService = new LoginService();

            return LoginService;
        }
    }

    //Also look at below lazy initialization of object property
    //public class SingletonProvider : IServiceProvider
    //{
    //    //private static readonly Lazy<LoginService> LazyLoginService = new Lazy<LoginService>(() => new LoginService());

    //    private static readonly Lazy<LoginService> LazyLoginService = new Lazy<LoginService>(
    //        delegate ()
    //        {
    //            return new LoginService();
    //        }
    //    );

    //    public LoginService GetInstance()
    //    {
    //        return LazyLoginService.Value;
    //    }
    //}

    public class ScopedProvider : IServiceProvider
    {
        //its exact same as singleton only difference is static keyword is removed from property..
        public LoginService LoginService = null;
        public LoginService GetInstance()
        {
            if (LoginService == null)
                LoginService = new LoginService();

            return LoginService;
        }
    }


    public class LoginService
    {
        public Guid ID { get; }
        public LoginService()
        {
            ID = Guid.NewGuid();
        }
    }
}
