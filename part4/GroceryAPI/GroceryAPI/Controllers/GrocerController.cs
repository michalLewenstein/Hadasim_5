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
    public class GrocerController : ControllerBase
    {
        private readonly IGrocerService _grocerService;
        private readonly IMapper _mapper;

        public GrocerController(IGrocerService grocerService, IMapper mapper)
        {
            _grocerService = grocerService;
            _mapper = mapper;
        }


        // GET api/<GrocerController>/5
        [HttpGet("{id}")]
        public ActionResult GetGrocer(int id)
        {
            try
            {
                var grocer = _grocerService.GetGrocer(id);
                return Ok(grocer);
            }
           catch (Exception ex)
            {
                return Conflict(new { error = "grocer not exists!" });
            }
        }

        // POST api/<GrocerController>
        [HttpPost]
        public IActionResult SignUp([FromBody] GrocerPostModel grocer)
        {
            try
            {
                _grocerService.SignUp(_mapper.Map<Grocer>(grocer));
                return Ok(new { message = "grocer registered successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                if (ex.Message == "grocer already exists!")
                {
                    return Conflict(new { error = "grocer already exists!" });
                }
                return BadRequest(new { error = ex.Message });
            }
        }

        // POST api/<GrocerController>
        [HttpPost("login")]
        public IActionResult LogIn([FromBody] GrocerLogInPostModel grocer)
        {
            try
            {
                _grocerService.LogIn(_mapper.Map<Grocer>(grocer));
                return Ok(new { message = "grocer login successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

    }
}
