namespace Dunder_Mifflin_Paper_Company.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly AppDbContext context;
        private IOrderRepository _order;
        private IProductRepository _product;
        private IProductTypeRepository _productType;

        public RepositoryWrapper(AppDbContext context)
        {
            this.context = context;
        }
        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                    _order = new OrderRepository(context);
                return _order;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                    _product = new ProductRepository(context);
                return _product;
            }
        }

        public IProductTypeRepository ProductType
        {
            get
            {
                if (_productType == null)
                    _productType = new ProductTypeRepository(context);
                return _productType;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
