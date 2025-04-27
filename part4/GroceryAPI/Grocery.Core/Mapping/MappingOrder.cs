using AutoMapper;
using Grocery.Core.Dto;
using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Mapping
{
    public class MappingOrder : Profile
    {
        public MappingOrder()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
        }
    }
}
