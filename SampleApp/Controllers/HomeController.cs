using Microsoft.AspNetCore.Mvc;

namespace SampleApp.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}