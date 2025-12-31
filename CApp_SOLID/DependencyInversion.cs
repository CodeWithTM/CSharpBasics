using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp_SOLID
{

    // SOLID - Dependency Inversion Principle
    // High-level modules should NOT depend on low-level modules. Both should depend on abstractions.
    // Abstractions should not depend on details. Details should depend on abstractions.
    // This principle aims to reduce the coupling between high-level and low-level components by introducing abstractions (e.g., interfaces or abstract classes) that both levels depend on.

    // For example, consider a scenario where a high-level module (e.g., a business logic class) depends on a low-level module (e.g., a data access class).
    // To adhere to the Dependency Inversion Principle, we can introduce an abstraction (e.g., an interface) that both the high-level and low-level modules depend on.
    // and that is the reason in code of WebAPI controllers we use interfaces for services instead of directly depending on concrete implementations.



    /*
     High-level vs. Low-level
        •	High-level module: Contains business logic or core rules (e.g., an OrderService that processes orders).
        •	Low-level module: Handles details like data storage, file access, or sending emails (e.g., a SqlOrderRepository that saves orders to a database).
    
    Without DIP:
    The high-level module directly creates or uses the low-level module, causing tight coupling.
     */


    public class SqlOrderRepository
    {
        public void Save(string order)
        {
            Console.WriteLine("Order saved to SQL database.");
        }
    }

    public class OrderService
    {
        private SqlOrderRepository _repository = new SqlOrderRepository(); // TIGHT COUPLING

        public void ProcessOrder(string order)
        {
            // Business logic...
            _repository.Save(order); // business logic class directly depends on low-level class (i.e. data save)

        }
    }

    // with DI implemented

    public interface IOrderRepository // abstraction
    {
        void Save(string order);
    }

    public class SqlOrderRepositoryDI : IOrderRepository    // concrete implementation
    {
        public void Save(string order)
        {
            Console.WriteLine("Order saved to SQL database.");
        }
    }

    public class FileOrderRepository : IOrderRepository     // concrete implementation
    {
        public void Save(string order)
        {
            Console.WriteLine("Order saved to file.");
        }
    }

    public class OrderServiceDI
    {
        private readonly IOrderRepository _repository;  

        public OrderServiceDI(IOrderRepository repository)
        {
            _repository = repository;
        }

        public void ProcessOrder(string order)
        {
            // Business logic...
            _repository.Save(order);
        }
    }

    // and below is actual DEPENDENCY INJECTION using .NET Core DI container
    // builder.Services.AddSingleton<IOrderRepository, SqlOrderRepositoryDI>();

    internal class DependencyInversion
    {
    }
}
