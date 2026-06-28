using ALSiteBack.Data;
using ALSiteBack.Interfaces;
using ALSiteBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ALSiteBack.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Contact>> GetContacts()
        {
            return await _context.Contacts.OrderBy(c => c.Id).ToListAsync();
        }
    }
}
