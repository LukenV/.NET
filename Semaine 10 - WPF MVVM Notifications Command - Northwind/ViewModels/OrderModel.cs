using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfEmployee.Models;

namespace WpfEmployee.ViewModels
{
    public class OrderModel
    {
        private readonly Order _order;
        private readonly decimal _total;

        public OrderModel(Order order, decimal total)
        {
            _order = order;
            _total = total;
        }

        public Order Order { get { return _order; } }

        public int OrderId { get { return _order.OrderId; } }
        public string OrderDate { get { return _order.OrderDate.Value.ToShortDateString(); } }
        public decimal OrderTotal { get { return _total; } }
    }
}
