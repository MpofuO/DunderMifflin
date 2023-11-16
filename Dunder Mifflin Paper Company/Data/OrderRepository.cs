using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public Order GetOrderWithDetails(int id)
        {
            return context.Orders.Include(order => order.Products).ThenInclude(cp=>cp.Product)
                .Include(order => order.Address).FirstOrDefault(order => order.OrderID == id);
        }

        public IEnumerable<Order> GetPlacedOrders()
        {
            return FindAll().Where(order => order.isPlaced);
        }

        public IEnumerable<Order> GetUserPlacedOrdersWithProducts(string UserName)
        {
            return ((IEnumerable<Order>)context.Orders.Include(order => order.Products).ThenInclude(cp => cp.Product))
                .Where(order => order.CustomerUserName == UserName && order.isPlaced);
        }

        public IEnumerable<Order> GetUserOrderHistoryWithProducts(string UserName)
        {
            return ((IEnumerable<Order>)context.Orders.Include(order => order.Products).ThenInclude(cp => cp.Product))
                .Where(order => order.CustomerUserName == UserName && order.isProcessed);
        }

        public Order GetOrderWithProducts(int id)
        {
            return context.Orders.Include(order => order.Products).FirstOrDefault(order => order.OrderID == id);
        }
    }
}
