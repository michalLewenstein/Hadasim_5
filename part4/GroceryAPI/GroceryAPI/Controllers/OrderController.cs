using AutoMapper;
using Grocery.Core.Models;
using Grocery.Core.Service;
using GroceryAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            return Ok(_orderService.GetAllOrders());
        }


        // POST api/<OrderController>
        [HttpPost("{supplierId}")]
        public IActionResult AddOrder( int supplierId, [FromBody] OrderPostModel order)
        {
            try
            {
                var newOrder =  _mapper.Map<Order>(order);
                _orderService.AddOrder(newOrder);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult OrderConfirmation(int id)
        {
            _orderService.OrderConfirmation(id);
            return Ok();
        }
        // PUT api/<OrderController>/5
        [HttpPut("{id}/complet")]
        public IActionResult OrderCompleted(int id)
        {
            _orderService.OrderCompleted(id);
            return Ok();
        }

    }
}
