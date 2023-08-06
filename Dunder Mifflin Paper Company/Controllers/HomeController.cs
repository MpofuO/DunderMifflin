using Microsoft.AspNetCore.Mvc;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
