using Autofac;
using System;


namespace CApp_DI
{
    //Types of DI
    //constuctor injection
    //property injection
    //method injection
    public class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Person>().As<IPerson>();
            builder.RegisterType<College>().As<IEducInstitute>();
            builder.RegisterType<Hospital>().As<IHospital>();
            builder.RegisterType<Bunglow>().As<IHome>();

            return builder.Build();
        }
    }
    internal class DI_Basics
    {
        public void Main(string[] args)
        {

            var container = ContainerConfiguration.Configure();
            
            using(var scope = container.BeginLifetimeScope())
            {
                IPerson personObj = scope.Resolve<IPerson>();
                
                personObj.School = scope.Resolve<IEducInstitute>();                

                personObj.Name = "TNM";

                personObj.Stay();
                personObj.Study();

                personObj.Treat(scope.Resolve<IHospital>());

            }



            //Home home = new Home();

            //Person person = new Person(home);
            //person.Name = "TM";

            //person.Stay();
            //person.School = new College();
            ////person.School = new School();

            //person.Study();
            //person.Treat(new Hospital());

            Console.ReadLine();
        }
    }

    public interface IPerson
    {
        string Name { get; set; }
        IEducInstitute School { set; }

        void Stay();
        void Study();
        void Treat(IHospital _hospital);
    }

    public class Person : IPerson
    {
        public string Name { get; set; }

        IHome _home;
        IEducInstitute _school;

        public IEducInstitute School
        {
            set { _school = value; }
        }

        public Person(IHome home)
        {
            _home = home;
        }

        public void Stay()
        {
            _home.Shelter(this);
        }

        public void Study()
        {
            //NULL check is required on property as it maight possible that property is not set..

            _school?.Teach(this);
        }

        public void Treat(IHospital _hospital)
        {
            _hospital.GetTreatment(this);
        }
    }

    public interface IHome
    {
        void Shelter(IPerson person);
    }

    public class Bunglow : IHome
    {
        public void Shelter(IPerson person)
        {
            Console.WriteLine(person.Name + " stay in banglow");
        }
    }

    public class Home : IHome
    {
        public void Shelter(IPerson person)
        {
            Console.WriteLine(person.Name + " stay in home");
        }
    }

    public interface IEducInstitute
    {
        void Teach(IPerson person);
    }

    public class School : IEducInstitute
    {
        public void Teach(IPerson person)
        {
            Console.WriteLine(person.Name + " study in school");
        }

    }

    public class College : IEducInstitute
    {
        public void Teach(IPerson person)
        {
            Console.WriteLine(person.Name + " study in college");
        }
    }

    public interface IHospital
    {
        void GetTreatment(IPerson person);
    }

    public class Hospital : IHospital
    {
        public void GetTreatment(IPerson person)
        {
            Console.WriteLine("get treatment");
        }
    }
}
