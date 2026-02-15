using Microsoft.EntityFrameworkCore;
using RazorWebApp.Models;

namespace RazorWebApp
{
    public class EmployeeDBContext : DbContext  
    {
        //dbset of employee
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("EmpDB");
        }
    }
}
