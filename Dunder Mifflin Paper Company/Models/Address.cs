using Dunder_Mifflin_Paper_Company.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Dunder_Mifflin_Paper_Company.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public string CustomerUserName { get; set; }

        [Required(ErrorMessage ="Please enter a house number")]
        [RegularExpression(@"[\d]*")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Please enter the street name")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Please enter the suburb name")]
        public string Surburb { get; set; }

        [Required(ErrorMessage = "Please enter the city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter the postal code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please select the province")]
        public string Province { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
        public string ShortDescription => $"{HouseNumber} {StreetName}\n{Surburb}, {City}, {PostalCode}";

        public ICollection<Order> Orders { get; set; }
    }
}
