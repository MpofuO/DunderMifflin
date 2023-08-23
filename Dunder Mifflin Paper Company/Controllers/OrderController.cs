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
        public IActionResult List(string id = "all")//'all' is for salesperson, 'incart' is for Cart, 'isplaced' is for placed orders
        {
            IEnumerable<Order> list;

            if (User.IsInRole("Customer"))
            {
                if (id == "history")
                    list = repository.Order.FindByCondition(order => order.isProcessed && User.Identity.Name.ToLower() == order.CustomerUserName.ToLower());
                else
                    list = repository.Order.FindByCondition(order => order.isPlaced && User.Identity.Name.ToLower() == order.CustomerUserName.ToLower());
            }
            else
                list = repository.Order.FindByCondition(order => order.isPlaced);

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
            repository.Order.Create(new Order
            {
                Products = new Collection<CartProduct>(repository.CartProduct.GetUserCartProductsWithProducts(User.Identity.Name).ToList()),
                CustomerUserName = User.Identity.Name,
                PlacedDate = DateTime.UtcNow

            });

            foreach (CartProduct p in repository.CartProduct.FindAll())
                repository.CartProduct.Delete(p);

            repository.Save();

            return View("List");
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
                    foreach (var p in order.Products)
                    {
                        Product product = repository.Product.GetById(p.ProductID);
                        product.Quantity = product.Quantity + p.PurchaseQuantity;
                        repository.Product.Update(product);
                    }
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
