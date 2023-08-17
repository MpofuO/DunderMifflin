using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    [Authorize(Roles ="Customer")]
    public class CartController : Controller
    {
        private readonly IRepositoryWrapper repository;
        public CartController(IRepositoryWrapper _repository)
        {
            repository = _repository;
        }

        public IActionResult List()
        {
            return View(repository.Order.FindByCondition(order => !order.isPlaced
                                                               && User.Identity.Name.ToLower() == order.CustomerUserName.ToLower()));
        }

        [HttpPost]
        public IActionResult Add(int productId)
        {
            var product = repository.Product.GetById(productId);
            if (product.InStock)
            {
                var cartProduct = repository.CartProduct.GetCartProductWithProduct(productId, User.Identity.Name);

                if (cartProduct != null)
                    cartProduct.ProductQuantity++;
                else
                {
                    cartProduct = new CartProduct
                    {
                        ProductID = productId,
                        ProductQuantity = 1,
                        CustomerUserName = User.Identity.Name,
                    };
                }
                repository.CartProduct.Update(cartProduct);
                repository.Save();
                TempData["Message"] = cartProduct.ProductQuantity > 1 ? "Product was already in cart and has been updated" : "Product added to cart";
            }
            else
                ModelState.AddModelError("", "This product is currently out of stock");

            return RedirectToAction("Details", new { id = productId });
        }
    }
}
