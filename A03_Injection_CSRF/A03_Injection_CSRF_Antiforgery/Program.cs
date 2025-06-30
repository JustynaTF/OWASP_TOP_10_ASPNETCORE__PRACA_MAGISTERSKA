// Program.cs
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.WebHost.UseUrls("http://+:8080");
// Dodanie linii
builder.Services.AddAntiforgery(options => options.HeaderName = "XSRF-TOKEN");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAntiforgery(); // Dodaj ten middleware do potoku żądań

app.UseAuthorization(); // To może być przed lub po UseAntiforgery, ale ważne, żeby UseAntiforgery było po UseRouting

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// .WithStaticAssets(); // Ta linia `.WithStaticAssets();` nie jest standardowa w `MapControllerRoute`. Jeśli masz błąd, usuń ją.
                      // Prawdopodobnie chciałaś użyć `app.UseStaticFiles();` co już masz.

app.Run();