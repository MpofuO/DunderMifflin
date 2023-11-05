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

        public IEnumerable<Order> GetUserOrdersWithProducts(string UserName)
        {
            return context.Orders.Include(order => order.Products).ThenInclude(cp => cp.Product).Where(order => order.CustomerUserName == UserName);
        }
    }
}
