using Dunder_Mifflin_Paper_Company.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        public async Task<IActionResult> Register(RegisterViewModel registerModel, string role = "Customer")
        {
            if (ModelState.IsValid)
            {
                string username = (registerModel.LastName+registerModel.FirstName.Substring(0, 1)).ToLower();
                if (await userManager.FindByNameAsync(username) == null)
                {
                    IdentityUser user = new IdentityUser
                    {
                        UserName = username,
                        Email = registerModel.Email,
                        PhoneNumber = registerModel.PhoneNumber
                    };
                    IdentityResult result = await userManager.CreateAsync(user, registerModel.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        foreach (IdentityError error in result.Errors)
                            ModelState.AddModelError("", error.Description);

                }
            }
            return View(registerModel);
        }
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                await userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.RememberMe, true);
                    if (result.Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Home/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(loginModel);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}





