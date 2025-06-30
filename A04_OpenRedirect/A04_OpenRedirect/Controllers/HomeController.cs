using Microsoft.AspNetCore.Mvc;

namespace OpenRedirectDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
