using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Tickets.API.Extensions;
using Tickets.API.Models;
using Tickets.API.Services;

namespace Tickets.API.Controllers
{
    [Route("api/tickets")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ILogger<TicketsController> _logger;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        private readonly ICityInfoService _cityInfoService;
        private readonly IMessageProducer _messageProducer;

        public TicketsController(ILogger<TicketsController> logger,
            ITicketRepository ticketRepository,
            IMapper mapper,
            ICityInfoService cityInfoService,
            IMessageProducer messageProducer
            )
        
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _ticketRepository = ticketRepository ?? throw new ArgumentNullException(nameof(ticketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _cityInfoService = cityInfoService ?? throw new ArgumentNullException(nameof(cityInfoService));
            _messageProducer = messageProducer ?? throw new ArgumentNullException(nameof(messageProducer));
        }

        [HttpGet(Name = "GetTickets")]
        public async Task<ActionResult<List<TicketDto>>> GetAllTickets() 
        {
            var tickets = await _ticketRepository.GetAllTickets();

            var finalTickets = _mapper.Map<TicketDto>(tickets);

            return Ok(finalTickets);
        }


        [HttpGet("{cityId}/{pointOfInterestId}")]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTicketsForPointOfInterest(int cityId,int pointOfInterestId)
        {
            _logger.LogInformation("Returning tickets for specific point of interests");

            var tickets = await _ticketRepository.GetTicketsForPointOfInterest(cityId, pointOfInterestId);

            if (!tickets.Any())
            {
                var token = await _cityInfoService.GetAuthToken();

                var poi = await _cityInfoService.GetPointOfInterest(cityId, pointOfInterestId, token);

                if (poi.Id != null)
                {
                    return NotFound("No tickets sold for this point of interest");
                }

            }

            return Ok(_mapper.Map<IEnumerable<TicketDto>>(tickets));
         

        }

        [HttpPost("{cityId}/{pointOfInterestId}")]
        public async Task<ActionResult<BoughtTicketDto>> NewTicketBought(int cityId, int pointOfInterestId, BoughtTicketDto boughtTicket)
        {
            var ticket = _mapper.Map<Entities.Ticket>(boughtTicket);

            await _ticketRepository.NewTicketBought(cityId, pointOfInterestId, ticket);
            await _ticketRepository.SaveChangesAsync();

            _messageProducer.SendingMessage(boughtTicket);

            var ticketToPublish = _mapper.Map<Models.TicketDto>(ticket);

            return CreatedAtRoute("GetTickets",ticketToPublish);
        }
    }
}
