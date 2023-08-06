namespace Dunder_Mifflin_Paper_Company.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string SelectedType { get; set; }
        public string search { get; set; }
    }
}
