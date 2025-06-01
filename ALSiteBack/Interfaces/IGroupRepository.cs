using ALSiteBack.Models;

namespace ALSiteBack.Interfaces
{
    public interface IGroupRepository
    {
        public ICollection<Group> GetMainGroups();
        public Group GetGroup(int id);
    }
}
