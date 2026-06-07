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

        public ICollection<Group> GetMainGroups()
        {
            return _context.Groups
                .Where(g => g.ParentId == null)
                .Include(g => g.Children)
                .ToList();
        }

        public Group GetGroup(int id)
        {
            return 
                _context
                .Groups
                .Where(g => g.Id == id)
                .Include(g => g.Children)
                .Include(g => g.Products)
                .First();
        }
    }
}
