using ALSiteBack.Models;

namespace ALSiteBack.Interfaces
{
    public interface IContactRepository
    {
        ICollection<Contact> GetContacts();
    }
}
