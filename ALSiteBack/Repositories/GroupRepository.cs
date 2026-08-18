using ALSiteBack.Data;
using ALSiteBack.Dto.Pagination;
using ALSiteBack.Interfaces;
using ALSiteBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ALSiteBack.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DataContext _context;

        public  GroupRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Group>> GetMainGroups()
        {
            return await _context.Groups
                .Where(g => g.ParentId == null)
                .Include(g => g.Children)
                .ToListAsync();
        }

        public async Task<Group> GetGroup(int id)
        {
            return await
                _context
                .Groups
                .Where(g => g.Id == id)
                .Include(g => g.Children)
                .Include(g => g.Products)
                .FirstAsync();
        }
        public async Task<int> GetGroupCount(int id)
        {
            return await _context.Products
                .CountAsync(p => p.Group.Id == id);
        }

        
    }
}
