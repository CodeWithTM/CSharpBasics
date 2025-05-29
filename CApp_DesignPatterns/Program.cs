using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //we cannot create instance like below
            //SingletonCls singleObj = new SingletonCls();

            SingletonCls singleObj = SingletonCls.GetInstance();

            //if we try to create one more instance, it will return the same global instance
            SingletonCls anothorObj = SingletonCls.GetInstance();


            //Factory design pattern
            FactoryPattrn factoryPattrn = new FactoryPattrn();
            factoryPattrn.Main();


            //Builder design pattern
            IComputerBuilder computerBuilder = new OfficeComputerBuilder();
            ComputerDirector computerDirector = new ComputerDirector(computerBuilder);
            computerDirector.BuildComputer();

            Computer c = computerDirector.GetCompu();

            Console.WriteLine(c);
        }
    }

    public class PersonModel
    {

    }

    public class  EmployeeModel
    {
        
    }
}
