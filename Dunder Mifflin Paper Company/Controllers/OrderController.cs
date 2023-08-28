using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    [Authorize(Roles = "Customer, Sales")]
    public class OrderController : Controller
    {
        private readonly IRepositoryWrapper repository;
        public OrderController(IRepositoryWrapper _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        public IActionResult List(string id = "all")
        {
            IEnumerable<Order> list;

            if (User.IsInRole("Customer"))
            {
                if (id == "history")
                    list = repository.Order.GetUserOrdersWithProducts(User.Identity.Name).Where(order => order.isProcessed);
                else
                    list = repository.Order.GetUserOrdersWithProducts(User.Identity.Name).Where(order => order.isPlaced);
            }
            else
                list = repository.Order.FindAll().Where(order => order.isPlaced);

            return View(list);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Order order = repository.Order.GetById(id);
            if (order != null)
                return View(order);
            return View("List");
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult Add()
        {
            List<CartProduct> cartProducts = repository.CartProduct.GetUserCartProductsWithProducts(User.Identity.Name).Where(cp => !cp.isOrdered).ToList();

            repository.Order.Create(new Order
            {
                Products = new Collection<CartProduct>(cartProducts),
                CustomerUserName = User.Identity.Name,
                PlacedDate = DateTime.UtcNow

            });

            foreach (CartProduct cp in cartProducts)
            {
                cp.isOrdered = true;
                repository.CartProduct.Update(cp);
            }

            repository.Save();

            return RedirectToAction("List", "Product", new { id = "all" });
        }
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult Delete(int id)
        {
            try
            {
                Order order = repository.Order.GetById(id);
                if (order != null)
                {
                    repository.Order.Delete(order);
                    repository.Save();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to cancel the order");
            }
            return View("List");
        }

        [HttpPost]
        [Authorize(Roles = "Sales")]
        public IActionResult ProcessOrder(int id, [Required] string processId)//processId is approve/disapprove
        {
            Order order = repository.Order.GetById(id);
            if (order != null)
            {
                if (processId == "approve")
                {
                    IEnumerable<CartProduct> products = repository.CartProduct.GetUserCartProductsWithProducts(User.Identity.Name);
                    foreach (var p in products)
                    {
                        Product product = repository.Product.GetById(p.ProductID);
                        product.Quantity = product.Quantity - p.PurchaseQuantity;
                        repository.Product.Update(product);
                    }

                    order.isApproved = true;
                }
                else
                    order.isApproved = false;

                order.ProcessedDate = DateTime.UtcNow;
                repository.Order.Update(order);
                repository.Save();
            }

            return View("List");
        }
    }
}
