using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public Order GetOrderWithProducts(int id)
        {
            return context.Orders.Include(order => order.Products).FirstOrDefault(order=>order.OrderID == id);
        }

        public IEnumerable<Order> GetUserOrdersWithProducts(string UserName)
        {
            return context.Orders.Include(order => order.Products).Where(order=>order.CustomerUserName == UserName);
        }
    }
}
