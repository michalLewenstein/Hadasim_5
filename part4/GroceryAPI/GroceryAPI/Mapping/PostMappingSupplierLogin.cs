
using AutoMapper;
using Grocery.Core.Models;
using GroceryAPI.Models;

namespace GroceryAPI.Mapping
{
    public class PostMappingSupplierLogin : Profile
    {
        public PostMappingSupplierLogin() {
            CreateMap<SupplierLogInPostModel, Supplier>();
        }


    }
}
