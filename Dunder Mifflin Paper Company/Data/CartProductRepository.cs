using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public class CartProductRepository : RepositoryBase<CartProduct>, ICartProductRepository
    {
        public CartProductRepository(AppDbContext context) : base(context)
        {
        }

        public CartProduct GetCartProductWithProduct(int productId, string UserName)
        {
            return context.CartProducts.Include(cp => cp.Product).FirstOrDefault(cp => cp.ProductID == productId && cp.CustomerUserName == UserName);
        }

        public IEnumerable<CartProduct> GetUserCartProductsWithProducts(string UserName)
        {
            return context.CartProducts.Include(cp => cp.Product).Where(cp => cp.CustomerUserName == UserName);
        }
    }
}
