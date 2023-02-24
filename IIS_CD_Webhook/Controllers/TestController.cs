using Microsoft.AspNetCore.Mvc;

namespace IIS_CD_Webhook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Content("connection success!");
        }
    }
}
