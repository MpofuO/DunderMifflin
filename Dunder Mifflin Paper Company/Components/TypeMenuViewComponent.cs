using Dunder_Mifflin_Paper_Company.Data;
using Dunder_Mifflin_Paper_Company.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dunder_Mifflin_Paper_Company.Components
{
    public class TypeMenuViewComponent : ViewComponent
    {
        private IRepositoryWrapper _repository;
        public TypeMenuViewComponent(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var id = RouteData?.Values["id"];
            var model = new ProdTypeListViewModel
            {
                ProductTypes = _repository.ProductType.FindAll(),
                SelectedCategory = id != null ? (string)id : "all"
            };
            return View(model);
        }
    }
}
