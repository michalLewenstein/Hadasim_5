using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public enum Estatus
    {
        PendingApproval=0, 
        InProgress=1,     
        Completed=2        
    }
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public Estatus Status { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int QuantityOrder { get; set; }
    }
}
