using AutoMapper;
using Grocery.Core.Models;
using GroceryAPI.Models;

namespace GroceryAPI.Mapping
{
    public class PostMappingOrder : Profile
    {
        public PostMappingOrder() { 
            CreateMap<OrderPostModel, Order>();
        }
    }
}
