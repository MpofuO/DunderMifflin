using Dunder_Mifflin_Paper_Company.Models;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public interface IFavouriteRepository : IRepositoryBase<Favourite>
    {
        public IEnumerable<Favourite> GetUserFavouritesWithProduct(string UserName);
        public Favourite GetFavouriteWithProduct(int id);
    }
}
