using ALSiteBack.Models;

namespace ALSiteBack.Interfaces
{
    public interface IActualDateRepository
    {
        Task<ActualDate> GetActualDate();
    }
}
