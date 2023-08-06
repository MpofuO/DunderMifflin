using Dunder_Mifflin_Paper_Company.Models;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductsInStock()
        {
            return context.Set<Product>().Where(p => p.InStock);
        }
        public IEnumerable<Product> GetProductsNotInStock()
        {
            return context.Set<Product>().Where(p => !p.InStock);
        }
    }
}
