using Microsoft.EntityFrameworkCore;
using Shipping.API.Data;
using Shipping.API.Models.Entities;

namespace Shipping.API.Repos
{
    public class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext context;
        public OrderRepo(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<Order> GetOrder(int id)
        {
            var result = await context.Orders.SingleOrDefaultAsync(o => o.Id == id);

            return result;

        }
    }
}
