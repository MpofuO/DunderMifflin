using System.ComponentModel.DataAnnotations;

namespace Dunder_Mifflin_Paper_Company.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderNumber => $"{PlacedDate.Day}{OrderID}{PlacedDate.Month}{PlacedDate.Hour}";
        public bool isPlaced => PlacedDate != default && ProcessedDate == default;
        public decimal Cost => Products.Sum(p => p.totalPrice);
        public bool isProcessed => ProcessedDate != default;
        public string CustomerUserName { get; set; }
        public DateTime PlacedDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public bool isApproved { get; set; }
        public ICollection<CartProduct> Products { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
    }

    public enum DeliveryMethod { Delivery, Collection}
}
