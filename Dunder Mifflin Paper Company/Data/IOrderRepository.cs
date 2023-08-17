using Dunder_Mifflin_Paper_Company.Models;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        public IEnumerable<Order> GetUserOrdersWithProducts(string UserName); 
        public Order GetOrderWithProducts(int id);
    }
}
