using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    [Authorize(Roles = "Customer")]
    public class FavouriteController : Controller
    {
        private readonly IRepositoryWrapper repository;
        public FavouriteController(IRepositoryWrapper _repository)
        {
            repository = _repository;
        }
        public IActionResult List()
        {
            return View(repository.Favourite.GetUserFavouritesWithProduct(User.Identity.Name));
        }

        [HttpPost]
        public IActionResult Add(int productID, string source)
        {
            var favourite = repository.Favourite.GetUserFavouritesWithProduct(User.Identity.Name).FirstOrDefault(f => f.ProductID == productID);
            if (favourite is null)
            {
                repository.Favourite.Create(new Favourite
                {
                    CustomerUserName = User.Identity.Name,
                    ProductID = productID
                });
                repository.Save();
            }
            TempData["Message"] = "Added to wishlist";

            return source == "Details" ? RedirectToAction("Details", "Product", new { id = productID })
                : source == "Details" ? RedirectToAction("List", "Product", new { id = "all" }, productID.ToString())
                : RedirectToAction("Index", "Cart", productID.ToString());
        }
        public IActionResult Remove(int favouriteID)
        {
            Favourite favourite = repository.Favourite.GetById(favouriteID);
            if (favourite != null)
            {
                repository.Favourite.Delete(favourite);
                repository.Save();
                TempData["Message"] = "Removed from wishlist";
            }

            return RedirectToAction("List");
        }
    }
}
