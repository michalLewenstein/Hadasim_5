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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        private readonly IMapper _mapper;
        
        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            _supplierService  = supplierService;
            _mapper = mapper;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public ActionResult  GetAllSupplier()
        {
            var suppliers = _supplierService.GetAllSupplier();
            return Ok(suppliers);
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public ActionResult GetSupplierById(int id)
        {
            var suppliers = _supplierService.GetSupplierById(id);
            return Ok(suppliers);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public IActionResult SignUp([FromBody] SupplierPostModel supplier)
        {
            try
            {
                _supplierService.SignUp(_mapper.Map<Supplier>(supplier));
                return Ok(new { message = "supplier registered successfully" }); 
            }
            catch (Exception ex)
            {
                if (ex.Message == "supplier already exists!")
                {
                    return Conflict(new { error = "supplier already exists!" });
                }
                return BadRequest(new { error = ex.Message });
            }
        }

        // POST api/<SupplierController>
        [HttpPost("login")]
        public IActionResult LogIn([FromBody] SupplierLogInPostModel supplier)
        {
            try
            {
               var supplierId =  _supplierService.LogIn(_mapper.Map<Supplier>(supplier));
                return Ok(supplierId);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
