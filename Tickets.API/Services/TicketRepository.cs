using Microsoft.EntityFrameworkCore;
using Tickets.API.DbContexts;
using Tickets.API.Entities;

namespace Tickets.API.Services
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketContext _context;

        public TicketRepository(TicketContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); ;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetTicketsForPointOfInterest(int cityId, int pointOfInterestId)
        {
            return await _context.Tickets
                .Where(t => t.PointOfInterestId == pointOfInterestId && t.CityID == cityId)
                .ToListAsync();
        }

        public async Task NewTicketBought(int cityId, int pointOfInterestId, Ticket ticket)
        {
            var tickets = await GetAllTickets();

            tickets.Add(ticket);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
