using ALSiteBack.Models;

namespace ALSiteBack.Interfaces
{
    public interface IGroupRepository
    {
        public Task<ICollection<Group>> GetMainGroups();
        public Task<Group> GetGroup(int id);
    }
}
