namespace Shipping.API.Models.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }

        public int CustomerPhoneNo { get; set; }
        public string ShippingAdress { get; set; }
        public string Status { get; set; }
        public DateTime TimeCreated { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string ShippingType { get; set; }
        public string PaymentMethod { get; set; }

    }
}
