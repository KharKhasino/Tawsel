using System.ComponentModel.DataAnnotations;

namespace Shipping.API.Models.Entities
{
    public class Governorate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
