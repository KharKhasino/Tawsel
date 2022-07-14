using Microsoft.EntityFrameworkCore;
using Shipping.API.Models.Entities;

namespace Shipping.API.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
       
        public DbSet<Order> Orders { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ShippingType> ShippingTypes { get; set; }
    }
}
