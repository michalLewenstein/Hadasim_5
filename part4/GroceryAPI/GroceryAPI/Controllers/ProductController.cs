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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult GetAllProduct()
        {
            return Ok(_productService.GetAllProduct());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductPostModel product)
        {
            try
            {
                _productService.AddProduct(_mapper.Map<Product>(product));
                return Ok(new { message = "product added successfully" });
            }
            catch (Exception ex)
            {
                if (ex.Message == "product already exists!")
                {
                    return Conflict(new { error = "product already exists!" });
                }
                return BadRequest(new { error = ex.Message });
            }
        }


    }
}
