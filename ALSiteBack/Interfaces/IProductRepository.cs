using ALSiteBack.Dto.Pagination;
using ALSiteBack.Models;

namespace ALSiteBack.Interfaces
{
    public interface IProductRepository
    {
        Task<PagedResult<Product>> GetProducts(int page, int pageSize);
        Task<PagedResult<Product>> GetGroupProducts(int groupId, int page, int pageSize);
    }
}
