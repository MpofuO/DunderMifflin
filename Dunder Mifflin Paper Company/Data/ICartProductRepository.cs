using Dunder_Mifflin_Paper_Company.Models;
using System.Linq.Expressions;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public interface ICartProductRepository : IRepositoryBase<CartProduct>
    {
        public IEnumerable<CartProduct> GetUserCartProductsWithProducts(string UserName);
        public CartProduct GetCartProductWithProduct(int productId, string UserName);
    }
}
