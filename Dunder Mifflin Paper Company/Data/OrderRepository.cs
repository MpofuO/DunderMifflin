using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetOrderWithProduct(int id)
        {
            return context.Set<Order>().Where(order=>order.OrderID == id).Include(order => order.Product);
        }

        public IEnumerable<Order> GetUserOrdersWithProduct(string UserName)
        {
            return context.Set<Order>().Where(order=>order.CustomerUserName == UserName)
                .Include(order => order.Product);
        }
    }
}
