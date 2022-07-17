using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.API.Models.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [ForeignKey("Governorate")]
        [Display(Name = "Governorate")]
        public int Gov_Id { get; set; }

        public virtual Governorate Governorate { get; set; }
    }
}
