using Microsoft.AspNetCore.Mvc;

namespace A03_Injection_XSS.Controllers;

public class XssDemoController : Controller
{
    public IActionResult Index(string? input)
    {
        ViewData["Message"] = input ?? "Brak danych";
        return View();
    }

    public IActionResult Secure(string? input)
    {
        ViewData["Message"] = input ?? "Brak danych";
        return View();
    }
}
