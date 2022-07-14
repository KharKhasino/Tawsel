using System.ComponentModel.DataAnnotations;

namespace Shipping.API.Models.DTOs
{
    public class GovernDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
