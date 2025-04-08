using AutoMapper;
using Grocery.Core.Models;
using GroceryAPI.Models;

namespace GroceryAPI.Mapping
{
    public class PostMappingSupplier : Profile
    {
        public PostMappingSupplier() {
            CreateMap<SupplierPostModel, Supplier>();
        }
    }
}
