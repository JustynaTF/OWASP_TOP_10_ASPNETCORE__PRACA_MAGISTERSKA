using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace A05.Controllers;

[Route("cookie")]
public class CookieDemoController : Controller
{
    [HttpGet("vulnerable/login")]
    public async Task<IActionResult> VulnerableLogin()
    {
        var claims = new List<Claim> { new(ClaimTypes.Name, "user-vulnerable") };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        return Content("Zalogowano (wersja podatna).");
    }

    [HttpGet("secure/login")]
    public async Task<IActionResult> SecureLogin()
    {
        var claims = new List<Claim> { new(ClaimTypes.Name, "user-secure") };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        var props = new AuthenticationProperties
        {
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
        };

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);
        return Content("Zalogowano (wersja bezpieczna).");
    }

    [HttpGet("")]
    public IActionResult Info()
    {
        return Content("Wersje: /cookie/vulnerable/login i /cookie/secure/login");
    }
}
