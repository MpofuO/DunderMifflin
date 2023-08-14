using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public Order GetOrderWithProduct(int id)
        {
            return context.Orders.Include(order => order.Product).FirstOrDefault(order=>order.OrderID == id);
        }

        public IEnumerable<Order> GetUserOrdersWithProduct(string UserName)
        {
            return context.Orders.Include(order => order.Product).Where(order=>order.CustomerUserName == UserName);
        }
    }
}
