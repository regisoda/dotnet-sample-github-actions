using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace dotnet_sample_github_actions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnvironmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EnvironmentController(IConfiguration configuration) => _configuration = configuration;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"Configuration Mode: {_configuration["Mode"]}");
        }
    }
}
