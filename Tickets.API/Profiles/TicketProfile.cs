using AutoMapper;
using Tickets.API.Entities;
using Tickets.API.Models;

namespace Tickets.API.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDto>();

            CreateMap<BoughtTicketDto, Ticket>();

            CreateMap<Ticket, BoughtTicketDto>();

            CreateMap<TicketDto, Ticket>();
        }
    }
}
