using Microsoft.AspNetCore.Mvc;

namespace IIS_CD_Webhook.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Content("connection success!");
        }
    }
}
