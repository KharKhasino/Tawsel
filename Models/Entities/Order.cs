using System.ComponentModel.DataAnnotations;

namespace Shipping.API.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(11,MinimumLength =11)]
        public int CustomerPhoneNo { get; set; }
        [Required]
        public string ShippingAdress { get; set; }
        public string? Status { get; set; }

        public DateTime TimeCreated { get; set; }

        public virtual Governorate Governorate { get; set; }
        public virtual City City { get; set; }
        public virtual PaymentMethod Payment { get; set; }
        public virtual ShippingType Shipping { get; set; }

    
    }
}
