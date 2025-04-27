using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SupplierId { get; set; }
        public Estatus Status { get; set; }
        public int ProductId { get; set; }
        public int QuantityOrder { get; set; }
    }
}
