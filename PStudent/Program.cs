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

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Регистрация DbContext с использованием PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
