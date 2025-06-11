using Microsoft.AspNetCore.Mvc;

namespace A01_BrokenAccessControl_IDOR.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Witaj w demonstracji podatności IDOR!");
        }
    }
}
