using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                if (id == "isplaced")
                    list = repository.Order.FindByCondition(order => order.isPlaced
                                                               && User.Identity.Name.ToLower() == order.CustomerUserName.ToLower());
                else if (id == "history")
                    list = repository.Order.FindByCondition(order => order.isProcessed && User.Identity.Name.ToLower() == order.CustomerUserName.ToLower());
                else
                    list = default;
            }
            else
                list = repository.Order.FindByCondition(order=>order.isPlaced);

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
        public IActionResult Add(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (order.OrderID == default)
                    {
                        order.PlacedDate = DateTime.Now;
                        repository.Order.Create(order);
                    }
                    else
                        repository.Order.Update(order);
                    repository.Save();
                }
                catch
                {
                    ModelState.AddModelError("", "Unable to add or update order");
                    return View(order);
                }
            }
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
                    repository.Order.Delete(order);
                    repository.Save();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to delete the order");
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
                    order.isApproved = true;
                else
                    order.isApproved = false;

                order.ProcessedDate = DateTime.Now;
            }

            return View("List");
        }
    }
}
