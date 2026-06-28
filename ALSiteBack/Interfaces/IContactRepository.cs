using ALSiteBack.Models;

namespace ALSiteBack.Interfaces
{
    public interface IContactRepository
    {
        Task<ICollection<Contact>> GetContacts();
    }
}
