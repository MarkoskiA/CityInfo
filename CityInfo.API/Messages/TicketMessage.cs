namespace CityInfo.API.Messages
{
    public class TicketMessage
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public int PointOfInterestId { get; set; }

        public int CityId { get; set; }
    }
}
