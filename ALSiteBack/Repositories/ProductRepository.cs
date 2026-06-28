using ALSiteBack.Data;
using ALSiteBack.Dto.Pagination;
using ALSiteBack.Interfaces;
using ALSiteBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ALSiteBack.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Product>> GetProducts(int page, int pageSize)
        {
            var query = _context.Products.AsNoTracking().OrderBy(p => p.Id);

            var totalCount = await query.CountAsync();

            var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            return new PagedResult<Product>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}
