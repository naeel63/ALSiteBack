using ALSiteBack.Data;
using ALSiteBack.Interfaces;
using ALSiteBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ALSiteBack.Repositories
{
    public class ActualDateRepository : IActualDateRepository
    {
        private readonly DataContext _context; 

        public ActualDateRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ActualDate> GetActualDate()
        {
            return await _context.ActualDates.OrderBy(ad => ad.Id).LastAsync();
        }
    }
}
