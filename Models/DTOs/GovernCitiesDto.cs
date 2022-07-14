using System.ComponentModel.DataAnnotations;

namespace Shipping.API.Models.DTOs
{
    public class GovernCitiesDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public Dictionary<string, int> Cities { get; set; } = new Dictionary<string, int>();
    }
}
