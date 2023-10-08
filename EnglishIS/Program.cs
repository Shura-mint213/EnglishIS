using Data;
using Data.Providers;
using EnglishIS.Helpers;
using EnglishIS.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Models.Providers;
using Static.Static;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<Database>();

// Add services to the container.
builder.Services.AddDbProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new PathString("/User/Login");
                });

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Database>();

var app = builder.Build();

LoadingIsConfigured.Download(app);

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

app.UseAuthentication();    // ��������������
app.UseAuthorization();     // �����������

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
