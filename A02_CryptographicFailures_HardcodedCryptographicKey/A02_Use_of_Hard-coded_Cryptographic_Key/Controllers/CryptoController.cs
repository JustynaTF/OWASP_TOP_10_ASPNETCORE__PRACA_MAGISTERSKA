using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace A02_CryptographicFailures_UseOfHard_codedCryptographicKey.Controllers;

[ApiController]
[Route("[controller]")]
public class CryptoController : ControllerBase
{
    // PODATNA wersja – jawny sekret w kodzie
    [HttpGet("vulnerable")]
    public IActionResult GetVulnerable()
    {
        string apiKey = "HARDCODED-SECRET-12345";
        return Ok($"Sekret (podatny): {apiKey}");
    }

    // BEZPIECZNA wersja – sekret z ENV
    [HttpGet("secure")]
    public IActionResult GetSecure()
    {
        string apiKey = Environment.GetEnvironmentVariable("APP_SECRET") ?? "Brak sekretu!";
        return Ok($"Sekret (bezpieczny): {apiKey}");
    }
}
