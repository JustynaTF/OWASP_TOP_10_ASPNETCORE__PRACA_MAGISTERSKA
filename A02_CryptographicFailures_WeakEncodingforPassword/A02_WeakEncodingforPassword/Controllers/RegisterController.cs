using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace A02_WeakEncodingforPassword.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    // PODATNA WERSJA
    [HttpPost("vulnerable")]
    public IActionResult RegisterVulnerable([FromForm] string username, [FromForm] string password)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var base64Password = Convert.ToBase64String(passwordBytes);

        return Ok($"Zapisano użytkownika: {username}, hasło (Base64): {base64Password}");
    }

    // BEZPIECZNA WERSJA
    [HttpPost("secure")]
    public IActionResult RegisterSecure([FromForm] string username, [FromForm] string password)
    {
        var hasher = new PasswordHasher<string>();
        var hashedPassword = hasher.HashPassword(null, password);

        return Ok($"Zarejestrowano {username} z hashem: {hashedPassword}");
    }
}
