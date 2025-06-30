using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "AuthCookie";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Informacja o dostępnych wersjach
app.MapGet("/", () =>
    "Wersje logowania:\n" +
    "/login        -> podatna wersja (bez daty wygasania)\n" +
    "/secure-login -> bezpieczna wersja (z datą wygasania)"
);

// Podatna wersja logowania (brak daty wygasania)
app.MapGet("/login", async (HttpContext context) =>
{
    var claims = new[] { new Claim("name", "user-vulnerable") };
    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var principal = new ClaimsPrincipal(identity);

    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    await context.Response.WriteAsync("Zalogowano! (wersja podatna)");
});

// Bezpieczna wersja logowania (ustawiona data wygasania)
app.MapGet("/secure-login", async (HttpContext context) =>
{
    var claims = new[] { new Claim("name", "user-secure") };
    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var principal = new ClaimsPrincipal(identity);

    var authProps = new AuthenticationProperties
    {
        IsPersistent = true,
        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(20)
    };

    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProps);
    await context.Response.WriteAsync("Zalogowano! (wersja bezpieczna)");
});

app.Run();
