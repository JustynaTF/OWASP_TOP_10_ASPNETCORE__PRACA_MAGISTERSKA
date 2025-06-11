using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Logger wspólny – bez maskowania
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog(logger);

var app = builder.Build();

app.MapGet("/", () =>
{
    return Results.Text("Dostępne endpointy:\n/log-vulnerable  – podatna wersja\n/log-secure     – bezpieczna wersja (maskowanie)");
});

// 🔓 Podatna wersja – dane logowane w jawnej postaci
app.MapGet("/log-vulnerable", () =>
{
    var user = new
    {
        Username = "anton",
        Password = "password_secret_information",
        CreditCardNumber = "1000-1000-1000-1000"
    };
    // Cały obiekt logowany bez filtracji – ujawnienie haseł i kart kredytowych
    logger.Information("User details (vulnerable): {@User}", user);

    return Results.Text("🔓 Zalogowano! Dane użytkownika zapisane w logu – podatna wersja.");
});

// 🔐 Bezpieczna wersja – maskowanie ręczne
app.MapGet("/log-secure", () =>
{
    var user = new
    {
        Username = "anton",
        Password = "***",
        CreditCardNumber = "***"
    };

    logger.Information("User details (secure): {@User}", user);

    return Results.Text("🔐 Zalogowano! Dane użytkownika zapisane w logu – bezpieczna wersja.");
});

app.Run();


