using System.ComponentModel.DataAnnotations;

namespace Dunder_Mifflin_Paper_Company.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerUserName { get; set; }
        public bool isPlaced => PlacedDate != default && ProcessedDate == default;
        public DateTime PlacedDate { get; set; }
        public bool isProcessed => ProcessedDate != default;
        public DateTime ProcessedDate { get; set; }
        public bool isApproved { get; set; }
        public decimal Cost => Products.Sum(p => p.totalPrice);
        public ICollection<CartProduct> Products { get; set; }
    }
}
