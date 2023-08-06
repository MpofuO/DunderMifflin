using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    [Authorize(Roles ="CEO, Manager")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            string role = User.IsInRole("CEO") ? "Manager" : "Sales";
            return View(await userManager.GetUsersInRoleAsync(role));
        }
        [HttpGet]
        public IActionResult Add()
        {
            TempData["UserAdded"] = User.IsInRole("CEO") ? "Manager" : "Salesperson";
            return RedirectToAction("Register", "Account"); 
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);
            if (user != null)
                await userManager.DeleteAsync(user);
            return View("List");
        }
    }
}
