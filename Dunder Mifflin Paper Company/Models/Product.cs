using System.ComponentModel.DataAnnotations;

namespace Dunder_Mifflin_Paper_Company.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter the product name.")]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the product description.")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the product price.")]
        [Range(0, double.MaxValue)]
        [Display(Name = "Product price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter the product quantity if the product. Specify 0 if there is none")]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; } = 0;
        public bool InStock => Quantity > 0;

        [Required(ErrorMessage = "Please select product type")]
        [Display(Name = "Product type")]
        public int? ProductTypeID { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Favourite> Favourites { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
