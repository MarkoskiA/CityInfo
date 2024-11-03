using Microsoft.AspNetCore.Mvc;
using Tickets.API.Entities;
using Tickets.API.Models;

namespace Tickets.API.Services
{
    public interface ITicketRepository
    {

        Task<IEnumerable<Ticket>> GetTicketsForPointOfInterest(int cityId, int pointOfInterestId);

        Task<List<Ticket>> GetAllTickets();

        Task NewTicketBought(int cityId, int pointOfInterestId, Ticket ticket);

        Task<bool> SaveChangesAsync();
    }
}
