using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.AspNetCore.Authorization;
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
            return View(repository.CartProduct.GetUserCartProductsWithProducts(User.Identity.Name));
        }

        [HttpPost]
        public IActionResult Add(int productId)
        {
            var product = repository.Product.GetById(productId);
            if (product.InStock)
            {
                var cartProduct = repository.CartProduct.GetCartProductWithProduct(productId, User.Identity.Name);

                if (cartProduct != null)
                {
                    cartProduct.ProductQuantity++;
                    repository.CartProduct.Update(cartProduct);
                }
                else
                {
                    repository.CartProduct.Create(
                        new CartProduct
                        {
                            ProductID = productId,
                            ProductQuantity = 1,
                            CustomerUserName = User.Identity.Name,
                        });
                }
                repository.Save();
                TempData["Message"] = cartProduct != null ? "Product was already in cart and has been updated" : "Product added to cart";
            }
            else
                ModelState.AddModelError("", "This product is currently out of stock");

            return RedirectToAction("Details", "Product", new { id = productId });
        }
        public IActionResult Remove(int productID)
        {
            CartProduct cartProduct = repository.CartProduct.GetCartProductWithProduct(productID, User.Identity.Name);
            if (cartProduct != null)
            {
                repository.CartProduct.Delete(cartProduct);
                repository.Save();
                TempData["Message"] = "Product removed from cart";
            }

            return RedirectToAction("List");
        }
    }
}
