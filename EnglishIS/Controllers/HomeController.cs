using Data.Providers;
using EnglishIS.Models;
using Microsoft.AspNetCore.Mvc;
using Models.Database;
using Models.Providers;
using System.Diagnostics;

namespace EnglishIS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersProvider _usersProvider;
        public HomeController(ILogger<HomeController> logger,
            IUsersProvider usersProvider)
        {
            _logger = logger;
            _usersProvider = usersProvider;
        }

        public IActionResult Index()
        {
            //var users = usersProvider.Get();
            var users = _usersProvider.Get();
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