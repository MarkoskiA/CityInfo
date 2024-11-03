using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tickets.API.Entities
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int PointOfInterestId { get; set; }

        [Required]
        public int CityID { get; set; }


        public Ticket(string email, string name, int pointOfInterestId, int cityID)
        {
            Email = email;
            Name = name;
            PointOfInterestId = pointOfInterestId;
            CityID = cityID;
        }
    }
}
