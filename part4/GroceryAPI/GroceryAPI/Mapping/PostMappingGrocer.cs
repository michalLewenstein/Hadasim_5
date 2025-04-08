using AutoMapper;
using Grocery.Core.Models;
using GroceryAPI.Models;

namespace GroceryAPI.Mapping
{
    public class PostMappingGrocer : Profile
    {
        public PostMappingGrocer() {
            CreateMap<GrocerPostModel, Grocer>();
        }
    }
}
