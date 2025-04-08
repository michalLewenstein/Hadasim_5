using Grocery.Core.Models;
using Grocery.Core.Repositories;
using Grocery.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }
        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder( order);
        }
        public void OrderConfirmation(int id)
        {
            _orderRepository.OrderConfirmation(id);
        }
        public void OrderCompleted(int id)
        {
            _orderRepository.OrderCompleted(id);
        }
    }
}
