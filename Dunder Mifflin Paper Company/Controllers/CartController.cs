using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        private readonly IRepositoryWrapper repository;
        public CartController(IRepositoryWrapper _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View(repository.CartProduct.GetUserCartProductsWithProducts(User.Identity.Name).Where(cp => !cp.isOrdered));
        }

        [HttpPost]
        public IActionResult Add(int productId, string source)
        {
            var product = repository.Product.GetById(productId);
            if (product.InStock)
            {
                var cartProduct = repository.CartProduct.GetCartProductWithProduct(productId, User.Identity.Name);

                if (cartProduct != null)
                {
                    cartProduct.PurchaseQuantity++;
                    repository.CartProduct.Update(cartProduct);
                }
                else
                {
                    repository.CartProduct.Create(
                        new CartProduct
                        {
                            ProductID = productId,
                            PurchaseQuantity = 1,
                            CustomerUserName = User.Identity.Name,
                        });
                }
                repository.Save();
                TempData["Message"] = cartProduct != null ? "Product was already in cart and has been updated" : "Product added to cart";
            }
            else
                ModelState.AddModelError("", "This product is currently out of stock");

            return source == "Details" ? RedirectToAction("Details", "Product", new { id = productId })
                : RedirectToAction("List", "Favourites");
        }
        public IActionResult Remove(int productID)
        {
            CartProduct cartProduct = repository.CartProduct.GetCartProductWithProduct(productID, User.Identity.Name);
            if (cartProduct != null)
            {
                repository.CartProduct.Delete(cartProduct);
                repository.Save();
                string action = (string)RouteData.Values["action"];
                TempData["Message"] = action == "Remove" ? "Product removed from cart" : "Product moved to wishlist";
            }

            return RedirectToAction("Index");
        }
        public IActionResult AddToList(int productID)
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

            return RedirectToAction("Index");
        }
        public IActionResult Increment(int productID)
        {
            var cartProduct = repository.CartProduct.GetCartProductWithProduct(productID, User.Identity.Name);

            if (cartProduct != null)
            {
                int newQty = cartProduct.PurchaseQuantity + 1;
                if (newQty < cartProduct.Product.Quantity)
                {
                    cartProduct.PurchaseQuantity++;
                    repository.CartProduct.Update(cartProduct);
                    repository.Save();
                }
                else
                    TempData["Message"] = "Unable to increase the quantity due to limited stock";
            }

            return RedirectToAction("Index");
        }
        public IActionResult Decrement(int productID)
        {
            var cartProduct = repository.CartProduct.GetCartProductWithProduct(productID, User.Identity.Name);

            if (cartProduct != null)
            {
                int newQty = cartProduct.PurchaseQuantity - 1;
                if (newQty > 0)
                {
                    cartProduct.PurchaseQuantity--;
                    repository.CartProduct.Update(cartProduct);
                    repository.Save();
                }
                else
                    return RedirectToAction("Remove", new { productID = productID });
            }

            return RedirectToAction("Index");
        }
    }
}
