using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EFCore
{
    public class EMSDBContext : DbContext
    {
        public EMSDBContext(DbContextOptions<EMSDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        //public DbSet<Department> Departments { get; set; }


    }

    // help me create employee class
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        //public int DeptId { get; set; }

        // navigational property to department
        //public Department Department { get; set; }
    }

    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    }
}
