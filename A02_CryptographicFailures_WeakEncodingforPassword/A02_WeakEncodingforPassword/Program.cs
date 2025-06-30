var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();

app.MapGet("/", () =>
    "Witaj w demonstracji A02 - Weak Encoding for Password.\n\n" +
    "Testuj metodą POST:\n" +
    " - podatna: http://localhost:5000/register/vulnerable\n" +
    " - bezpieczna: http://localhost:5000/register/secure");

app.MapControllers();
app.Run();
