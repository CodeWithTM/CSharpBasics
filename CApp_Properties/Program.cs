using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();

            employee.Id = 1001;
            employee.Name = "TM"; // employee.SetName("TM");

            employee.Department = "Admin";

            //employee.Gender = "F"; // NOT allowed as property setter is marked with private, so it can only be assigned within Employee class
            employee.SetGender("F");
            
            Console.WriteLine($"Emp name: {employee.GetName()}");

            Console.WriteLine($"Dept: {employee.GetDeptName()}");


            //object initialization
            Employee emp2 = new Employee { Id = 1002, Name = "DG", Department = "SF" }; //, Gender = "M" };

            //anonymous object initialization
            var emp3 = new { Firstname = "F", LastName = "L" };

            Console.ReadLine();
        }
    }

    public class Employee
    {
        public int Id { get; set; } // Auto-generated property

        private string name;

        //Older way of getting/setting field with methods
        public string GetName()
        {
            return this.name;
        }
        public void SetName(string _name)
        {
            if (_name.Length < 2)
                throw new Exception("Name too short");

            this.name = _name;
        }
        //Older way of getting/setting field with methods


        //newer way with properties
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null && value.Length < 2)
                    throw new Exception("Name too short");

                name = value;
            }
        }

        public string Department { get; set; } = "IT"; //Auto-property initialization

        public string Gender { get; private set; }

        public void SetGender(string _gender)
        {
            this.Gender = _gender; // private setter can only be assigned value within class
        }

        //public string EmailAddress { get; init; }
        //property with init setter can only be initilied only ONCE and not after that..

        public string GetDeptName() => Department;

        public List<Address> Address { get; set; }

        public class Salary
        {
            public string AccountType { get; set; } = "Savings";
        }
    }

    public class Address
    {
        public string City { get; set; }
    }

}
