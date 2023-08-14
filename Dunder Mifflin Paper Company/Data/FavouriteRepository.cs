using ContosoUniversity.Data.DataAccess;
using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public class FavouriteRepository : RepositoryBase<Favourite>, IFavouriteRepository
    {
        public FavouriteRepository(AppDbContext context) : base(context)
        {
        }

        public Favourite GetFavouriteWithProduct(int id)
        {
            return context.Favourites.Include(f => f.Product).FirstOrDefault(f=>f.FavouriteID == id);
        }

        public IEnumerable<Favourite> GetUserFavouritesWithProduct(string UserName)
        {
            return context.Favourites.Include(fav => fav.Product).Where(f => f.CustomerUserName == UserName);
        }
    }
}
