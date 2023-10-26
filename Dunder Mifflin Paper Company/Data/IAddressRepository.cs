using Dunder_Mifflin_Paper_Company.Models;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        public int CollectionID { get; }
        public IEnumerable<Address> GetUserAddresses(string username);
    }
}
