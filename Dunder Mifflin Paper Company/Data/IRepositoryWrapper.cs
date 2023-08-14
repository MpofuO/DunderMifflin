namespace Dunder_Mifflin_Paper_Company.Data
{
    public interface IRepositoryWrapper
    {
        public IOrderRepository Order { get; }
        public IProductRepository Product { get; }
        public IFavouriteRepository Favourite { get; }
        public IProductTypeRepository ProductType { get; }
        public void Save();
    }
}
