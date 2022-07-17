using System.ComponentModel.DataAnnotations;

namespace Shipping.API.Models.DTOs
{
    public class CityDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int GovId { get; set; }
        public string? Gov { get; set; }
    }
}
