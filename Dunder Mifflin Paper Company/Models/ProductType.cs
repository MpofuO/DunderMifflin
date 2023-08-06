using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dunder_Mifflin_Paper_Company.Models
{
    public class ProductType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage ="Please enter the ID for the product type.")]
        public int ProductTypeID { get; set; }

        [Required]
        public string ProductTypeName { get; set; }

        ICollection<Product> Products { get; set;}
    }
}
