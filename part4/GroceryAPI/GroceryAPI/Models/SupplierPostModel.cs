using Grocery.Core.Models;

namespace GroceryAPI.Models
{
    public class SupplierPostModel
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string RepresentativeName { get; set; }
        public List<ProductPostModel> products { get; set; } 

    }
}
