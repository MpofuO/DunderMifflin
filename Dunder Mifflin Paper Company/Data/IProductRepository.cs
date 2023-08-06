using Dunder_Mifflin_Paper_Company.Models;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        public IEnumerable<Product> GetProductsInStock();
        public IEnumerable<Product> GetProductsNotInStock();
    }
}
