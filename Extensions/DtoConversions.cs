using Shipping.API.Models.DTOs;
using Shipping.API.Models.Entities;

namespace Shipping.API.Extensions
{
    public static class DtoConversions
    {
        public static OrderDto ConvertToDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                CustomerPhoneNo = order.CustomerPhoneNo,
                ShippingAdress = order.ShippingAdress,
                Status = order.Status,
                ShippingType = order.Shipping.Type,
                PaymentMethod = order.Payment.Type,
                Governorate = order.Governorate.Name,
                City = order.City.Name
            };
        }
        //public static Order ConvertFromDto(this OrderDto orderDto)
        //{
        //    return new Order
        //    {
        //        Id = orderDto.Id,
        //        CustomerName = orderDto.CustomerName,
        //        ShippingAdress = orderDto.ShippingAdress,
        //        Status = orderDto.Status,
        //        Shipping = orderDto.ShippingType
        //    };
        //}

        public static CityDto ConvertToDto(this City city)
        {
            return new CityDto
            {
                Name = city.Name,
                Price = city.Price,
                Gov = city.Governorate.Name,
                GovId = city.Gov_Id
            };
        }
        public static GovernDto ConvertToDto(this Governorate gov)
        {
            return new GovernDto
            {
                Id = gov.Id,
                Name = gov.Name,

            };
        }

        public static IEnumerable<GovernDto> ConvertToDto(this IEnumerable<Governorate> govs)
        {
            return (from gov in govs
                    select new GovernDto
                    {
                        Id = gov.Id,
                        Name = gov.Name,
                    }).ToList();
        }
    }
}
