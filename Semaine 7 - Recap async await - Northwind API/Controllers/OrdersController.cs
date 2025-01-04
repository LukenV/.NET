using Microsoft.AspNetCore.Mvc;
using Semaine_7___Recap_async_await___Northwind_API.Entities;
using Semaine_7___Recap_async_await___Northwind_API.Models;
using Semaine_7___Recap_async_await___Northwind_API.UnitsOfWork;

namespace Semaine_7___Recap_async_await___Northwind_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;
        private readonly UnitOfWorkNorthwindSQL _unitOfWorkSQL;

        public OrdersController() {
            _northwindContext = new NorthwindContext();
            _unitOfWorkSQL = new UnitOfWorkNorthwindSQL(_northwindContext);
        }

        [HttpGet]
        public async Task<IList<OrderDTO>> GetAllOrders()
        {
            IList<Order> orders = await _unitOfWorkSQL.OrdersRepository.GetAllAsync();
            return orders.Select(o => OrderToOrderDTO(o)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<OrderDTO?> GetOneOrder(int id)
        {
            IList<Order> orders = await _unitOfWorkSQL.OrdersRepository.SearchForAsync(o => o.OrderId == id);
            OrderDTO? orderFound = orders.Select(o => OrderToOrderDTO(o)).FirstOrDefault();
            return orderFound;
        }

        [HttpPost]
        public async void CreateOneOrder(OrderDTO orderDTO)
        {
            orderDTO.OrderId = 0;
            Order order = OrderDTOToOrder(orderDTO);
            
            await _unitOfWorkSQL.OrdersRepository.InsertAsync(order);
        }

        [HttpPut]
        public async Task UpdateOneOrder(OrderDTO orderDTO)
        {
            Order order = OrderDTOToOrder(orderDTO);

            await _unitOfWorkSQL.OrdersRepository.SaveAsync(order);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteOneOrder(int id)
        {
            IList<Order> orders = await _unitOfWorkSQL.OrdersRepository.SearchForAsync(e => e.OrderId == id);
            Order? orderFound = orders.FirstOrDefault();

            if (orderFound == null) return false;

            await _unitOfWorkSQL.OrdersRepository.DeleteAsync(orderFound);

            return true;
        }

        private OrderDTO OrderToOrderDTO(Order order)
        {
            OrderDTO orderDTO = new OrderDTO
            {
                OrderDate = order.OrderDate,
                EmployeeId = order.EmployeeId,
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
            };

            return orderDTO;
        }

        private Order OrderDTOToOrder(OrderDTO orderDTO)
        {
            Order order = new Order
            {
                OrderDate = orderDTO.OrderDate,
                EmployeeId = orderDTO.EmployeeId,
                OrderId = orderDTO.OrderId,
                CustomerId = orderDTO.CustomerId,
            };

            return order;
        }
    }
}
