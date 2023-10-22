using Dunder_Mifflin_Paper_Company.Models;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context) { }

        public IEnumerable<Address> GetUserAddresses(string username)
        {
            return FindAll().Where(address => address.CustomerUserName == username);
        }
    }
}
