using Microsoft.AspNetCore.Mvc;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    public class AddressController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
