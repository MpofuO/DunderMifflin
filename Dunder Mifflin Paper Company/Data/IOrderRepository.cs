using Dunder_Mifflin_Paper_Company.Models;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        public IEnumerable<Order> GetUserPlacedOrdersWithProducts(string UserName);
        public IEnumerable<Order> GetUserOrderHistoryWithProducts(string UserName);
        public Order GetOrderWithDetails(int id);
        public Order GetOrderWithProducts(int id);
        public IEnumerable<Order> GetPlacedOrders();
    }
}
