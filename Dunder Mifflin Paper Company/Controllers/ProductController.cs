using ContosoUniversity.Data.DataAccess;
using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models;
using Dunder_Mifflin_Paper_Company.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    [Authorize(Roles = "Sales, Customer")]
    public class ProductController : Controller
    {
        private readonly IRepositoryWrapper repository;
        public ProductController(IRepositoryWrapper _repository)
        {
            repository = _repository;
        }

        [AllowAnonymous]
        public IActionResult List(string search, string id = "all", bool inStock = false)
        {
            IEnumerable<Product> products;

            if (id == "all")
            {
                products = repository.Product.FindAll();
            }
            else
            {
                var requiredProdType = repository.ProductType.FindAll().FirstOrDefault(p => p.ProductTypeName.ToLower() == id);
                products = repository.Product.FindByCondition(p => p.ProductTypeID == requiredProdType.ProductTypeID);
            }
            if (inStock)
                products = products.Where(p => p.InStock);
            if (search != default)
                products = products.Where(p => p.Name.ToLower().Contains(search.Trim().ToLower()));

            return View(new ProductListViewModel
            {
                Products = products,
                SelectedType = id,
                search = search
            });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Update", new Product());
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult AddToCart(int productId)
        {
            var product = repository.Product.GetById(productId);
            if (product.InStock)
            {
                var order = repository.Order.FindAll().FirstOrDefault(
                    order => order.ProductID == productId && order.CustomerUserName == User.Identity.Name && !order.isPlaced
                    );
                if (order != null)
                    order.ProductQuantity++;
                else
                {
                    order = new Order
                    {
                        ProductID = productId,
                        ProductQuantity = 1,
                        CustomerUserName = User.Identity.Name,
                    };
                }
                repository.Order.Update(order);
                repository.Save();
                TempData["Message"] = order.ProductQuantity > 1 ? "Product was already in cart and has been updated" : "Product added to cart";
            }
            else
                ModelState.AddModelError("", "This product is currently out of stock");

            return RedirectToAction("Details", new { id = productId });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            Product product = repository.Product.GetById(id);
            if (product != null)
            {
                product.ProductType = repository.ProductType.FindAll().FirstOrDefault(p => p.ProductTypeID == product.ProductTypeID);
                return View(new ProductDetailsViewModel
                {
                    Product = product,
                    isFavourite = User.Identity.IsAuthenticated ? repository.Favourite.FindAll().Select(f => f.ProductID).Contains(id) : false
                });
            }
            return View("List");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                Product product = repository.Product.GetById(id);
                if (product != null)
                {
                    repository.Product.Delete(product);
                    repository.Save();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to delete the product");
            }
            return View("List");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Product product = repository.Product.GetById(id);
            if (product != null)
            {
                PopulateTypeDLL(repository.ProductType.GetById((int)product.ProductTypeID));
                return View(product);
            }
            return View("List");
        }
        [HttpPost]
        public IActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (product.ProductID == default)
                        repository.Product.Create(product);
                    else
                        repository.Product.Update(product);
                    repository.Save();
                }
                catch
                {
                    ModelState.AddModelError("", "Unable to add or update product");
                    return View(product);
                }
            }
            return View("List");
        }
        private void PopulateTypeDLL(object selectedType = null)
        {
            ViewBag.ProductTypes = new SelectList(repository.ProductType.FindAll().OrderBy(t => t.ProductTypeName),
                "ProductTypeID", "ProductTypeName", selectedType);
        }
    }
}
