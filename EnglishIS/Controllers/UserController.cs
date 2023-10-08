using EnglishIS.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Models.Database;
using Models.Providers;
using System.Security.Claims;
using Data.Providers;
using Static.Enum;

namespace EnglishIS.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IUsersProvider _usersProvider;
        public UserController(IUsersProvider usersProvider)
        {
            _usersProvider = usersProvider;
        }
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                Users? user = await _usersProvider.GetAsync(loginModel.Phone, loginModel.Password);
                if (user != null)
                {
                    await Authenticate(loginModel.Phone); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View();
        }

        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Users? user = await _usersProvider.CheckUserAsync(model.Phone, model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    _usersProvider.Create(
                        new Users(model.FirstName,
                            model.LastName,
                            model.Phone,
                            model.Password,
                            (byte) EnglishLevel.A1,
                            (byte) Roles.User,
                            model.Email,
                            model.Birthday
                        ));

                    await Authenticate(model.Phone); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string login)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims,
                "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "User");
        }

    }
}
