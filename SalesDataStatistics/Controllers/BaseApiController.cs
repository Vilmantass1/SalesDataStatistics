using Microsoft.AspNetCore.Mvc;

namespace SalesDataStatistics.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
