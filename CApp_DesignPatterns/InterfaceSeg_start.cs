using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_DesignPatterns
{
    public class InterfaceSeg_start
    {
        public static void Main1(string[] args)
        {
            Employee e = new Manager();
            e.AssignManager(new Manager());

            Employee m = new Manager();
            //m.ProvideReview();

            Employee e1 = new CEO();
            e1.AssignManager(new Employee());
        }
    }

    public class CEO : Employee
    {
        public override void CalculateHourlyWages(int rank)
        {
            Salary = 100.0M + (rank * 4);
        }

        public override void AssignManager(Employee manager)
        {
            throw new InvalidOperationException("no manager");
        }

        public void GeneratePerfReview()
        {

        }
    }

    public class Manager : Employee
    {
        public override void CalculateHourlyWages(int rank)
        {
            Salary = 20.0M + (rank * 4);
        }

        public void GeneratePerfReview()
        {

        }
    }

    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Employee Manager { get; set; } = null;

        public decimal Salary { get; set; }

        public virtual void AssignManager(Employee manager)
        {
            this.Manager = manager;
        }

        public virtual void CalculateHourlyWages(int rank)
        {
            Salary = 10.0M + (rank + 2);
        }

    }
}
