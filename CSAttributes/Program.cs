
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAttributes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // The PrinterManager class is implemented as a singleton,
            // ensuring that only one instance of it exists throughout the application.
            // The Lazy<T> type is used to create the instance only
            // when it is first accessed, which can improve performance and resource usage.

            PrinterManager.Instance.PrintDoc();

            // This example demonstrates a self-referential relationship in the Employee class,
            // where each Employee can have a Manager who is also an Employee.
            // The Employee class has a property called Manager, which is of type Employee.
            // This allows for a hierarchy of employees, where each employee can report to another employee.
            // The example creates a CEO, a Manager who reports to the CEO, and a Staff member who reports to the Manager.
            // Self-relationship example

            Employee ceo = new Employee("Alice");

            Employee manager = new Employee("Bob", ceo);

            Employee staff = new Employee("Charlie", manager);

            Console.WriteLine($"{staff.EmpName} reports to {staff.Manager.EmpName}, who reports to {manager.Manager.EmpName}.");
        }
    }
}
