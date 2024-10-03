using DemoProduct.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DemoProduct.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserModel model = new UserModel();
            model.Name = values.Name;
            model.SurName = values.Surname;
            model.Mail = values.Email;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = model.Name;
            user.Surname = model.SurName;
            user.Email = model.Mail;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ModelState.AddModelError("", "Hatalı işlem");
            }
            return View(model);
        }
    }
}
