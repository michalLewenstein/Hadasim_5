using AutoMapper;
using Grocery.Core.Models;
using GroceryAPI.Models;

namespace GroceryAPI.Mapping
{
    public class PostMappingGrocerLogin : Profile
    {
        public PostMappingGrocerLogin() {
            CreateMap<GrocerLogInPostModel, Grocer>();
        }

    }
}
