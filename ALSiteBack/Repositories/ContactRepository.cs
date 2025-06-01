using ALSiteBack.Data;
using ALSiteBack.Interfaces;
using ALSiteBack.Models;

namespace ALSiteBack.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Contact> GetContacts()
        {
            return _context.Contacts.OrderBy(c => c.Id).ToList();
        }
    }
}
