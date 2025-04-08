using Grocery.Core.Models;

namespace GroceryAPI.Models
{
    public class OrderPostModel
    {
        public int ProductId { get; set; }
        public int QuantityOrder { get; set; }
        public int SupplierId { get; set; }
    }
}
