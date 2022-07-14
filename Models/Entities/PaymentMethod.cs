using System.ComponentModel.DataAnnotations;

namespace Shipping.API.Models.Entities
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
