using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_DesignPatterns
{
    //product
    public class Computer
    {
        //too many fields/properties to initialize inside constructor..
        public string CPU { get; set; }

        public string RAM { get; set; }

        public string Storage { get; set; }

        public override string ToString()
        {
            return this.CPU + this.RAM + this.Storage;
        }
    }

    //builder
    public interface IComputerBuilder
    {
        void SetCPU();
        void SetRAM();
        void SetStorage();
        Computer GetComputer();
    }

    //concrete builder

    public class OfficeComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        public void SetCPU() => _computer.CPU = "Inter core i5";
        public void SetRAM() => _computer.RAM = "16GB";
        public void SetStorage() => _computer.Storage = "256GB";
        
        public Computer GetComputer() => _computer;

    }


    //director
    public class ComputerDirector
    {
        IComputerBuilder _computerBuilder;
        public ComputerDirector(IComputerBuilder _builder)
        {
            _computerBuilder = _builder;
        }

        public void BuildComputer()
        {
            _computerBuilder.SetCPU();
            _computerBuilder.SetRAM();
            _computerBuilder.SetStorage();
        }

        public Computer GetCompu() => _computerBuilder.GetComputer();
        
    }
}
