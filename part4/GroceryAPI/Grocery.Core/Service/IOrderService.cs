using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Service
{
    public interface IOrderService
    {
        public List<Order> GetAllOrders();
        public void AddOrder(Order order);
        public void OrderConfirmation(int id);
        public void OrderCompleted(int id);
    }
}
