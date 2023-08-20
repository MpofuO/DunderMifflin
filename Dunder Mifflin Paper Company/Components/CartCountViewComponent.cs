using Dunder_Mifflin_Paper_Company.Data;
using Microsoft.AspNetCore.Mvc;

namespace Dunder_Mifflin_Paper_Company.Components
{
    public class CartCountViewComponent : ViewComponent
    {
        private IRepositoryWrapper _repository;
        public CartCountViewComponent(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_repository.CartProduct.GetUserCartProductsWithProducts(User.Identity.Name).Count());
        }
    }
}
