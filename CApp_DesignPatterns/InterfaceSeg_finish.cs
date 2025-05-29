using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_DesignPatterns1
{
    class InterfaceSeg_finish
    {

        //Employee Employee = new CEO();

        BaseEmployee _employee = new CEO();

    }
    public class CEO : BaseEmployee, IManager
    {
        public override void CalculateHourlyWages(int rank)
        {
            Salary = 100.0M + (rank * 4);
        }

        public void GeneratePerfReview()
        {

        }
    }

    public interface IManager : IEmployee
    {
        void GeneratePerfReview();
    }

    public interface IManaged : IEmployee
    {
        IEmployee Manager { get; set; }
        void AssignManager(IEmployee manager);
    }

    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        decimal Salary { get; set; }
        void CalculateHourlyWages(int rank);
    }
    public class Manager : Employee, IManager
    {
        public override void CalculateHourlyWages(int rank)
        {
            Salary = 20.0M + (rank * 4);
        }

        public void GeneratePerfReview()
        {

        }
    }

    public abstract class BaseEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public virtual void CalculateHourlyWages(int rank)
        {
            Salary = 10.0M + (rank + 2);
        }
    }

    public class Employee : BaseEmployee, IManaged
    {
        public IEmployee Manager { get; set; } = null;

        public virtual void AssignManager(IEmployee manager)
        {
            this.Manager = manager;
        }
    }
}
