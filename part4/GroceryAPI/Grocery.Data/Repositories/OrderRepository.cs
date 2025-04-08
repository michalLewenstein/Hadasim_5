using Grocery.Core.Models;
using Grocery.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Supplier)
                .Include(p=>p.Product)
                .ToList();
        }

        public void AddOrder(Order order)
        {
            var supplier = _context.Suppliers.Find(order.SupplierId);
            if (supplier == null)
            {
                throw new Exception("Supplier not found");
            }
            var product = _context.Products.Find(order.ProductId);
            if (product == null)
            {
                throw new Exception("product not found");
            }

            order.Supplier = supplier;
            order.Product = product;
            order.Status = Estatus.PendingApproval;
            order.Date = DateTime.Now;

            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void OrderConfirmation(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null) 
            {
                order.Status = Estatus.InProgress;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Order not found");
            }
        }

        public void OrderCompleted(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                order.Status = Estatus.Completed;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Order not found");
            }
        }
    }
}
