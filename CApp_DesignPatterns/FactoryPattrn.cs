using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_DesignPatterns
{
    public class FactoryPattrn
    {
        public void Main()
        {
            Waiter waiter = new Waiter();
            IPizza mypizza = waiter.GetPizza("Veg");

            //we can just change the type of pizza e.g. from Veg to NonVeg and i will get that product back from factory
            //am not bothered abt actual obj creation as its taken care by factory..
            mypizza.Eat();

        }
    }


    //client - this provies a layer of abstraction between the actual product consumer and the product creation mechanism..
    public class Waiter
    {
        public IPizza GetPizza(string type)
        {
            IPizzaChef chef = null;
            switch (type)
            {
                case "Veg":
                    //once will create a factory / product creator..
                    chef = new VegPizzaChef();

                    //then will create actual product..                   

                    break;

                case "NonVeg":

                    chef = new NonVegPizzaChef();

                    break;

            }

            return chef.preparePizza(); // creation of actual product
        }
    }

    //product creators / factories

    public interface IPizzaChef
    {
        IPizza preparePizza();
    }

    //product creator A
    public class VegPizzaChef : IPizzaChef
    {
        public IPizza preparePizza()
        {
            return new VegPizza();
        }
    }

    //product creator B
    public class NonVegPizzaChef : IPizzaChef
    {
        public IPizza preparePizza()
        {
            return new NonVegPizza();
        }
    }


    //product

    public interface IPizza
    {
        string Eat();
    }

    //product A

    public class VegPizza : IPizza
    {
        public string Eat()
        {
            return "Eating veg pizza!";
        }
    }

    //product B
    public class NonVegPizza : IPizza
    {
        public string Eat()
        {
            return "Eating non-veg pizza!";
        }
    }

}
