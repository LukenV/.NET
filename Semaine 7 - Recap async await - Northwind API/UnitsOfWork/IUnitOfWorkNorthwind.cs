using Semaine_7___Recap_async_await___Northwind_API.Entities;
using Semaine_7___Recap_async_await___Northwind_API.Repositories;

namespace Semaine_7___Recap_async_await___Northwind_API.UnitsOfWork
{
    public interface IUnitOfWorkNorthwind
    {
        IRepository<Employee> EmployeesRepository { get; }
        IRepository<Order> OrdersRepository { get; }
    }
}
