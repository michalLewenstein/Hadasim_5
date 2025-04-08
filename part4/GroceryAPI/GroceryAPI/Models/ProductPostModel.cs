namespace GroceryAPI.Models
{
    public class ProductPostModel
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int minQuantityOrder { get; set; }
    }
}
