namespace Dunder_Mifflin_Paper_Company.Models.ViewModels
{
    public class ProdTypeListViewModel
    {
        public IEnumerable<ProductType> ProductTypes { get; set; }
        public string SelectedCategory { get; set; }
        public string CheckActiveCategory(string category) =>
            category == SelectedCategory ? "active" : "";
    }
}
