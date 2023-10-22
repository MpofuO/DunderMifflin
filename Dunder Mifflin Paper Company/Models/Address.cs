using Dunder_Mifflin_Paper_Company.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Dunder_Mifflin_Paper_Company.Models
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public int CustomerUserName { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string Surburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public bool IsDefault { get; set; }
        public string ShortDescription => $"{HouseNumber} {StreetName}\n{Surburb}, {City}, {PostalCode}";

        public ICollection<Order> Orders { get; set; }
    }
}
