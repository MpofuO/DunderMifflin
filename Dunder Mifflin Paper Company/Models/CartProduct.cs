using Microsoft.EntityFrameworkCore;

namespace Dunder_Mifflin_Paper_Company.Models
{
    [PrimaryKey("ProductID", "CustomerUserName")]
    public class CartProduct
    {
        public string CustomerUserName { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int ProductQuantity { get; set; }
    }
}
