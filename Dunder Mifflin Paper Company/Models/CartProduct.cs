using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Dunder_Mifflin_Paper_Company.Models
{
    public class CartProduct
    {
        [Key]
        public int CartProductID { get; set; }
        public string CustomerUserName { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public bool isOrdered { get; set; }
        public int PurchaseQuantity { get; set; }
        public decimal totalPrice => Product.Price * PurchaseQuantity;

        public ICollection<Order> Orders { get; set; }
    }
}
