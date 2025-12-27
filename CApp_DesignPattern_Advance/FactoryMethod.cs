using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_DesignPattern_Advance
{

    //Another example of FACTORY METHOD DESIGN PATTERN
    //which is used inside webAPIProj with CarController

    //This is actual project object
    public class Car
    {
        public string Name { get; set; }

    }

    //Creator interface

    public interface ICarCatalog
    {
        Car[] GetCars();
    }

    //Concrete Creators->

    public class PetrolCarCatalog : ICarCatalog
    {
        public Car[] GetCars()
        {
            return new[] { new Car { Name = "PETROL" } };
        }
    }

    public class DiseselCarCatalog : ICarCatalog
    {
        public Car[] GetCars()
        {
            return new[] { new Car { Name = "DIESEL" } };
        }
    }


    public class FactoryMethod
    {
        public void ClientMethod()
        {

            Waiter waiter = new Waiter();
            IPizza pizza = waiter.GetPizza("V");

            pizza.Eat();

        }
    }

    public class Waiter
    {
        public IPizza GetPizza(string type)
        {
            IPizzaChef chef = null;

            switch (type)
            {
                case "V":
                    chef = new VegPizzaChef();
                    break;
                case "NV":
                    chef = new NonVegPizzaChef();
                    break;
            }
            return chef.PreparePizza();
        }
    }

    public interface IPizzaChef
    {
        IPizza PreparePizza();
    }

    public class VegPizzaChef : IPizzaChef
    {
        public IPizza PreparePizza()
        {
            return new VegPizza();
        }
    }

    public class NonVegPizzaChef : IPizzaChef
    {
        public IPizza PreparePizza()
        {
            return new NonVegPizza();
        }
    }

    public interface IPizza
    {
        void Eat();
    }

    public class VegPizza : IPizza
    {
        public void Eat()
        {
            Console.WriteLine("Eating veg pizza");
        }
    }

    public class NonVegPizza : IPizza
    {
        public void Eat()
        {
            Console.WriteLine("Eating nonveg pizza");
        }
    }
}
