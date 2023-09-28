using EnglishIS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Models.Database;

namespace EnglishIS.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Authorize()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    Users user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
            //    if (user != null)
            //    {
            //        await Authenticate(model.Email); // аутентификация

            //        return RedirectToAction("Index", "Home");
            //    }
            //    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            //}
            return View(model);
        }
    }
}
