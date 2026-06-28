using ALSiteBack.Data;
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
                .Include(g => g.Products)
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
    }
}
