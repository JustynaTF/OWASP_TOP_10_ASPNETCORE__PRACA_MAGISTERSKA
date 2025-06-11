// Controllers/HomeController.cs
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using A03_Injection_CSRF_Antiforgery.Models;

// using AntiforgeryDemo.Models; // Jeśli używasz FormModel, odkomentuj to

namespace A03_Injection_CSRF_Antiforgery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // --- WERSJA BEZPIECZNA ---
        [HttpPost]
        [ValidateAntiForgeryToken] // Ten atrybut chroni przed CSRF
        public IActionResult Submit(string message)
        {
            ViewBag.Response = $"Wiadomość otrzymana: \"{message}\"";
            _logger.LogInformation($"Bezpieczne przesłanie: {message}");
            return View("Index"); // Wróć do widoku Index
        }

        // --- WERSJA PODATNA ---
        [HttpPost]
        // UWAGA: BRAK [ValidateAntiForgeryToken] - to sprawia, że ta akcja jest PODATNA na CSRF
        public IActionResult SubmitVulnerable(string message)
        {
            ViewBag.VulnerableResponse = $"[PODATNOŚĆ] Wiadomość otrzymana: \"{message}\"";
            _logger.LogInformation($"Podatne przesłanie: {message}");
            return View("Index"); // Wróć do widoku Index
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}