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
            ViewBag.Action = "Add";
            PopulateTypeDLL();
            return View("Update", new ProductUpdateViewModel { Product = new Product() });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            Product product = repository.Product.GetById(id);
            if (product != null)
            {
                product.ProductType = repository.ProductType.FindAll().FirstOrDefault(p => p.ProductTypeID == product.ProductTypeID);

                ViewBag.Action = "Update";
                return View(new ProductDetailsViewModel
                {
                    Product = product,
                    isFavourite = User.Identity.IsAuthenticated ? repository.Favourite.GetUserFavouritesWithProduct(User.Identity.Name)
                    .Select(f => f.ProductID).Contains(id) : false
                });
            }
            TempData["Message"] = id == 0 ? "Product successfuly added" : "Product successfuly updates";
            return RedirectToAction("List");
        }

        [Authorize(Roles = "Sales")]
        public IActionResult Delete(int id)
        {
            try
            {
                Product product = repository.Product.GetById(id);
                if (product != null)
                {
                    repository.Product.Delete(product);
                    repository.Save();
                    TempData["Message"] = "Product successfuly deleted";
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to delete the product");
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        [Authorize(Roles = "Sales")]
        public IActionResult Update(int id)
        {
            Product product = repository.Product.GetById(id);
            if (product != null)
            {
                PopulateTypeDLL(repository.ProductType.GetById((int)product.ProductTypeID));
                return View(new ProductUpdateViewModel { Product = product });
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        [Authorize(Roles = "Sales")]
        public async Task<IActionResult> Update(ProductUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.imageFile != null)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await model.imageFile.CopyToAsync(memoryStream);
                            model.Product.Image = memoryStream.ToArray();
                        }
                    }

                    if (model.Product.ProductID == default)
                        repository.Product.Create(model.Product);
                    else
                        repository.Product.Update(model.Product);
                    repository.Save();
                }
                catch
                {
                    ModelState.AddModelError("", "Unable to add or update product");
                    return View(model.Product);
                }
            }
            return RedirectToAction("List");
        }
        private void PopulateTypeDLL(object selectedType = null)
        {
            ViewBag.ProductTypes = new SelectList(repository.ProductType.FindAll().OrderBy(t => t.ProductTypeName),
                "ProductTypeID", "ProductTypeName", selectedType);
        }
    }
}
