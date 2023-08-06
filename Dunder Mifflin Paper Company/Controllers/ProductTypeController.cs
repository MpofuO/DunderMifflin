using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    [Authorize(Roles ="RegionalManager")]
    public class ProductTypeController : Controller
    {
        private readonly IRepositoryWrapper repository;
        public ProductTypeController(IRepositoryWrapper _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        public IActionResult List()
        {
            return View(repository.ProductType.FindAll());
        }
        public IActionResult Add()
        {
            return View("Update", new ProductType());
        }
        public IActionResult Details(int id)
        {
            ProductType productType = repository.ProductType.GetById(id);
            if (productType != null)
                return View(productType);
            return View("List");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                ProductType productType = repository.ProductType.GetById(id);
                if (productType != null)
                {
                    repository.ProductType.Delete(productType);
                    repository.Save();
                }
            }
            catch
            {
                ModelState.AddModelError("", "Unable to delete the type");
            }
            return View("List");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ProductType productType = repository.ProductType.GetById(id);
            if (productType != null)
                return View(productType);
            return View("List");
        }
        [HttpPost]
        public IActionResult Update(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (productType.ProductTypeID == default)
                        repository.ProductType.Create(productType);
                    else
                        repository.ProductType.Update(productType);
                    repository.Save();
                }
                catch
                {
                    ModelState.AddModelError("", "Unable to add or update productType");
                    return View(productType);
                }
            }
            return View("List");
        }
    }
}
