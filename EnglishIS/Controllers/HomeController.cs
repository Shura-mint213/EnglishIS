using Data.Providers;
using EnglishIS.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Database;
using System.Diagnostics;

namespace EnglishIS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            UsersProvider usersProvider = new UsersProvider();
            var users = usersProvider.Get();

            //Users users1 = new() { Age = 23, Name = "Amin" };
            //usersProvider.Create(users1);

            //users = usersProvider.Get();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}