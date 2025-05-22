using ALSiteBack.Models;

namespace ALSiteBack.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
    }
}
