using Semaine_7___Recap_async_await___Northwind_API.Entities;
using Semaine_7___Recap_async_await___Northwind_API.Repositories;

namespace Semaine_7___Recap_async_await___Northwind_API.UnitsOfWork
{
    public class UnitOfWorkNorthwindSQL : IUnitOfWorkNorthwind
    {
        BaseRepositorySQL<Employee> _employeesRepository;
        BaseRepositorySQL<Order> _ordersRepository;

        public UnitOfWorkNorthwindSQL(NorthwindContext context)
        {
            _employeesRepository = new BaseRepositorySQL<Employee>(context);
            _ordersRepository = new BaseRepositorySQL<Order>(context);
        }

        public IRepository<Employee> EmployeesRepository { get { return _employeesRepository; } }
        public IRepository<Order> OrdersRepository { get { return _ordersRepository; } }
    }
}
