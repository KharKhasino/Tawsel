using System.ComponentModel.DataAnnotations;

namespace Shipping.API.Models.Entities
{
    public class ShippingType
    {
        public Guid Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
