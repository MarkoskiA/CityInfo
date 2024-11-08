﻿namespace Tickets.API.Models
{
    public class PointOfInterest
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int SoldTickets { get; set; }
    }
}
