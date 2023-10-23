using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    public class AddressController : Controller
    {
        private readonly IRepositoryWrapper repository;

        public AddressController(IRepositoryWrapper _repository)
        {
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(string source = "About")
        {
            TempData["Source"] = source;
            return View(new Address
            {
                CustomerUserName = User.Identity.Name,
            });
        }
        public IActionResult Update(Address address)
        {
            if (ModelState.IsValid)
            {
                if (address.AddressID == 0)
                {
                    repository.Address.Create(address);
                }
                else
                    repository.Address.Update(address);

                repository.Save();

                return TempData["Source"].ToString() == "Checkout" ? RedirectToAction("Checkout", "Cart") 
                        : RedirectToAction("Index");
            }
            return View(address);
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
