using AutoMapper;
using Grocery.Core.Models;
using GroceryAPI.Models;

namespace GroceryAPI.Mapping
{
    public class PostMappingProduct: Profile
    {
        public PostMappingProduct()
        {
            CreateMap<ProductPostModel, Product>();
        }
    }
}
