using System.ComponentModel.DataAnnotations;

namespace Dunder_Mifflin_Paper_Company.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Display(Name ="Customer username")]
        public string CustomerUserName { get; set; }
        public bool isPlaced { get; set; } = false;

        [Display(Name ="Order Date")]
        public DateTime PlacedDate { get; set; }

        [Display(Name ="Date Processed")]
        public DateTime ProcessedDate { get; set; }

        [Display(Name ="Process Result")]
        public bool isApproved { get; set; }

        [Display(Name ="Quantity Ordered")]
        [Range(1, int.MaxValue, ErrorMessage ="The quantity ordered must be at least 1")]
        public int ProductQuantity { get; set; }


        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
