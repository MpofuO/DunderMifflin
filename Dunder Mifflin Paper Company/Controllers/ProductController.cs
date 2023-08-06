﻿using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models;
using Dunder_Mifflin_Paper_Company.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

namespace Dunder_Mifflin_Paper_Company.Controllers
{
    [Authorize(Roles = "Sales")]
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
            if (search!=default)
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
            return View("Update",new Product());
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            Product product = repository.Product.GetById(id);
            if (product != null)
                return View(product);
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
