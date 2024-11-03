namespace Tickets.API.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        
        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int PointOfInterestId { get; set; }

        public int CityId { get; set; }

    }
}
