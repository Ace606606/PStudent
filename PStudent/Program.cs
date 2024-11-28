using Microsoft.EntityFrameworkCore;
using PStudent.Data;
using PStudent.Components;
using System.Globalization;
using PStudent;
using PStudent.Components.Layout;

var builder = WebApplication.CreateBuilder(args);

// Установить культуру для всего приложения
var cultureInfo = new CultureInfo("ru-RU"); // Используем русскую культуру (dd/MM/yyyy)
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Регистрация DbContext с использованием PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Настроить приложение на использование порта 5000
app.Urls.Add("http://0.0.0.0:5000");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
