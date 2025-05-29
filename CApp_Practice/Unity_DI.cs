using Microsoft.Practices.Unity;
using System;

namespace CApp_Practice
{

    //https://www.tutorialsteacher.com/ioc/lifetime-manager-in-unity-container
    public class Unity_DI
    {
        public void Main()
        {
            //Driver d = new Driver(new BMW());

            IUnityContainer unityContainer = new UnityContainer();

            unityContainer.RegisterType<ICar, BMW>(new TransientLifetimeManager());

            
            Driver drv1 = unityContainer.Resolve<Driver>();
            drv1.RunCar();

            Driver drv2 = unityContainer.Resolve<Driver>();
            drv2.RunCar();


            unityContainer.RegisterType<ICar, BMW>();
            unityContainer.RegisterType<ICar, Audi>("LuxuryCar");

            ICar c1 = unityContainer.Resolve<ICar>();   //Returns BMW

            ICar c2 = unityContainer.Resolve<ICar>("LuxuryCar");    //Returns Audi



            unityContainer.RegisterInstance<ICar>(new BMW());

            Driver dr3 = unityContainer.Resolve<Driver>();
            dr3.RunCar();
            dr3.RunCar();


            unityContainer.RegisterType<ICar, BMW>(new ContainerControlledLifetimeManager());

            unityContainer.RegisterType<ICar, Audi>(new HierarchicalLifetimeManager());


            unityContainer.RegisterType<ILoggerService, LoggerService>();
            ServiceConsumer consumer = unityContainer.Resolve<ServiceConsumer>();
            
            //consumer.ROprop = "";

            consumer.LogInfo("DI works!");
            Console.ReadLine();
        }
    }
    public interface ICar
    {
        int Run();
    }

    public class BMW : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }
    }

    public class Audi : ICar
    {
        private int _miles = 0;

        public int Run()
        {
            return ++_miles;
        }

    }
    public class Driver
    {
        private ICar _car = null;

        public Driver(ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
        }
    }

    //Another example

    public interface ILoggerService
    {
        void Log(string message);
    }
    public class LoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class ServiceConsumer
    {
        public readonly ILoggerService _logger;

        public string ROprop { get; }
        public ServiceConsumer(ILoggerService loggerService)
        {
            ROprop = "its read only prop";

            _logger = loggerService;
        }

        public void LogInfo(string message)
        {
            _logger.Log(message);
        }
    }
}
