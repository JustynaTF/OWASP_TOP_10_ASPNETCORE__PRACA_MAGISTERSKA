var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();
app.MapGet("/", () => "Witaj w demonstracji podatności A02 – Hardcoded Secret.\n\n" +
                      "Aby przetestować wersję podatną przejdź do: http://localhost:5000/crypto/vulnerable\n" +
                      "Aby przetestować wersję bezpieczną przejdź do: http://localhost:5000/crypto/secure");

app.Run();
