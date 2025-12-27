using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAttributes
{
    internal class SelfRelationship
    {
    }

    public class Employee
    {
        public string EmpName { get; set; }
        public Employee Manager { get; set; }

        public Employee(string name, Employee employee = null)
        {
            EmpName = name;
            Manager = employee;
        }
    }
}
