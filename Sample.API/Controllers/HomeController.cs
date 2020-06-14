using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration) => _configuration = configuration;

        [HttpGet("/healthy")]
        public IActionResult Get()
        {
            return Ok("OK");
        }
    }
}
