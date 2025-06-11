using Microsoft.AspNetCore.Mvc;

namespace OpenRedirectDemo.Controllers;

public class RedirectController : Controller
{
    // PODATNA WERSJA
    [HttpGet("/redirect/vulnerable")]
    public IActionResult Vulnerable(string redirectUrl)
    {
        return Redirect(redirectUrl);
    }

    // BEZPIECZNA WERSJA
    [HttpGet("/redirect/secure")]
    public IActionResult Secure(string redirectUrl)
    {
        if (!Url.IsLocalUrl(redirectUrl))
        {
            return BadRequest("Invalid redirect URL.");
        }

        return Redirect(redirectUrl);
    }
}
