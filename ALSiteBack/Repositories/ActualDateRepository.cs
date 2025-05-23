using ALSiteBack.Data;
using ALSiteBack.Interfaces;
using ALSiteBack.Models;

namespace ALSiteBack.Repositories
{
    public class ActualDateRepository : IActualDateRepository
    {
        private readonly DataContext _context; 

        public ActualDateRepository(DataContext context)
        {
            _context = context;
        }
        public ActualDate GetActualDate()
        {
            return _context.ActualDates.OrderBy(ad => ad.Id).Last();
        }
    }
}
