using Data.Providers;
using EnglishIS.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Models.Providers;
using Static.Static;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new PathString("/   ");
                });
builder.Services.AddControllersWithViews();

var app = builder.Build();

SettingsApp.ConnectionString = app.Configuration["ConnectionStrings"];

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();

var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("en"),
    new CultureInfo("ru-RU"),
    new CultureInfo("ru"),
};

app.UseRequestLocalization(new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture("ru-RU"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures

}); 

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();    // аутентификация
app.UseAuthorization();     // авторизация

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
