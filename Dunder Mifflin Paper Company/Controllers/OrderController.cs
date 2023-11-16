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
                    list = repository.Order.GetUserOrderHistoryWithProducts(User.Identity.Name);
                else
                    list = repository.Order.GetUserPlacedOrdersWithProducts(User.Identity.Name);
            }
            else
                list = repository.Order.GetPlacedOrders();

            return View(list);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Order order = repository.Order.GetOrderWithDetails(id);
            if (order != null)
                return View(order);
            return RedirectToAction("List");
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult Add(string deliveryMethod, int addressID)
        {
            List<CartProduct> cartProducts = repository.CartProduct.GetUserCartProductsWithProducts(User.Identity.Name).Where(cp => !cp.isOrdered).ToList();

            bool isDelivery = deliveryMethod == "Delivery";

            repository.Order.Create(new Order
            {
                Products = new Collection<CartProduct>(cartProducts),
                CustomerUserName = User.Identity.Name,
                PlacedDate = DateTime.UtcNow,
                DeliveryMethod = isDelivery ? DeliveryMethod.Delivery : DeliveryMethod.Collection,
                AddressID = isDelivery ? addressID : repository.Address.CollectionID

            });

            foreach (CartProduct cp in cartProducts)
            {
                cp.isOrdered = true;
                repository.CartProduct.Update(cp);
            }

            repository.Save();
            TempData["Message"] = "You have successfully placed your order";
            return RedirectToAction("List", "Product", new { id = "all" });
        }

        //Still needs to be reviewed.
        [Authorize(Roles = "Customer")]
        public IActionResult Delete(int id)
        {
            try
            {
                Order order = repository.Order.GetOrderWithProducts(id);
                if (order != null)
                {
                    foreach (CartProduct p in order.Products)
                        repository.CartProduct.Delete(p);

                    repository.Order.Delete(order);
                    repository.Save();
                    TempData["Message"] = $"Order #{order.OrderNumber} has been cancelled";
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to cancel the order");
            }
            return RedirectToAction("List");
        }

        [Authorize(Roles = "Sales")]
        public IActionResult Process(int orderID, string processId)//processId is approve/decline
        {
            Order order = repository.Order.GetOrderWithProducts(orderID);
            if (order != null)
            {
                if (processId == "approve")
                {
                    IEnumerable<CartProduct> products = order.Products;
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
            TempData["Message"] = $"Order #{order.OrderNumber} successfully {processId}d.";

            return RedirectToAction("List");
        }
    }
}
