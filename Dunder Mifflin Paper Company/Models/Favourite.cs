using System.ComponentModel.DataAnnotations;

namespace Dunder_Mifflin_Paper_Company.Models
{
    public class Favourite
    {
        [Key]
        public int FavouriteID { get; set; }
        public string CustomerUserName { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
