using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_Interfaces
{

    //Interfaces
    //abstract classes
    //virtual override

    internal class Program
    {
        static void Main(string[] args)
        {

            //IEmployee emp1 = new Employee();

            IEmployee emp2 = new CraneOperatorEmployee();

            emp2.Id = 1001;
            emp2.Name = "CO";
            emp2.JobTitle = "Crane Op";
            emp2.JoinDate = new DateTime(2022, 01, 01);

            Console.WriteLine(emp2.GetBasicInfo());

            Console.WriteLine(emp2.GetYearOfExpi());

            CraneOperatorEmployee cEmp = new CraneOperatorEmployee();
            cEmp.GetYearOfExpi();

            IEmployee emp3 = new ElectricianEmployee();

            IEmployee emp4 = new DryWallInstallerEmployee();


            IEmployee emp5 = new ProjectManager();
            emp5.Id = 1005;
            emp5.JobTitle = "PM";


            Console.ReadLine();

        }

        public static void SeedData(List<IEmployee> empData)
        {
            CEO ceo = new CEO();
            ceo.Id = 1010;
            ceo.Name = "CE";
            ceo.JobTitle = "CEO";
            ceo.PersonalAssistId = 1100;

            empData.Add(ceo);

            Manager mgr = new ProjectManager();
            mgr.Id = 1020;
            mgr.Name = "MG";
            mgr.JobTitle = "MGR";

            empData.Add(mgr);

        }
    }

    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }
        string JobTitle { get; set; }
        decimal AnnualSalary { get; set; }
        DateTime JoinDate {  get; set; }
        string GetBasicInfo();
        int GetYearOfExpi();
    }
    public abstract class Employee : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private string jobTitle;
        public string JobTitle
        {
            get
            {
                return jobTitle;
            }
            set
            {
                if (value == "" || value.Length < 2)
                {
                    throw new Exception("Too short");
                }
                else
                {
                    jobTitle = value;
                }
            }
        }
        public virtual decimal AnnualSalary { get; set; }
        public DateTime JoinDate { get; set; }

        public virtual string GetBasicInfo()
        {
            return $"{this.Id}{Environment.NewLine}{this.Name}{Environment.NewLine}{this.jobTitle}";
        }
        public int GetYearOfExpi()
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            TimeSpan timeSpan = DateTime.Now.Subtract(JoinDate);

            int years = zeroTime.Add(timeSpan).Year - 1;
            return years;
        }
    }


    public class CraneOperatorEmployee : Employee
    {
        private decimal GetBonusPay()
        {
            return 0.04m;
        }

        public override decimal AnnualSalary
        {
            get => base.AnnualSalary + (base.AnnualSalary * GetBonusPay());
            set { base.AnnualSalary = value; }
        }
    }

    public class ElectricianEmployee : Employee
    {

    }

    public class DryWallInstallerEmployee : Employee
    {

    }

    public interface IManager
    {
        string OfficeID { get; set; }
        int SecretoryId { get; set; }

    }

    public abstract class Manager : Employee, IManager
    {
        public string OfficeID { get; set; }
        public int SecretoryId { get; set; }

        public override string GetBasicInfo()
        {
            return base.GetBasicInfo() + $"{OfficeID}";
        }
    }

    public class ProjectManager : Manager
    {

    }

    public class SafetyManager : Manager
    {

    }

    public interface ICEO
    {
        int PersonalAssistId { get; set; }
    }
    public class CEO : Manager, ICEO
    {
        public int PersonalAssistId { get; set; }

        public override string GetBasicInfo()
        {
            return base.GetBasicInfo() + $"{PersonalAssistId}";
        }
    }
}
