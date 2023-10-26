using Dunder_Mifflin_Paper_Company.Models;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context) { }

        public int CollectionID => FindAll().FirstOrDefault(a => a.CustomerUserName == "Collection").AddressID;

        public IEnumerable<Address> GetUserAddresses(string username)
        {
            return FindByCondition(address => address.CustomerUserName == username);
        }
    }
}
