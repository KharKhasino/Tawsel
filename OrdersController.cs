using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shipping.API.Data;
using Shipping.API.Extensions;
using Shipping.API.Models.DTOs;
using Shipping.API.Models.Entities;

namespace Shipping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext ctx;

        public OrdersController(AppDbContext context)
        {
            ctx = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var orders = await ctx.Orders.ToListAsync();
            return Ok(orders);
        }

        // GET: api/Orders/5
        [HttpGet("{id:int}")]
        [ActionName("GetOrder")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await ctx.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5
        //[HttpPut("{id:Guid}")]
        //public async Task<IActionResult> PutOrder([FromRoute] Guid id, Order order)
        //{
        //    if (id != order.Id)
        //    {
        //        return BadRequest();
        //    }

        //    ctx.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        await ctx.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Orders
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Order>> PostOrder(OrderDto order)
        {
            // Convert DTO to Entity
            var newOrder = new Order();
            newOrder.ConvertToDto();
            await ctx.Orders.AddAsync(newOrder);
            await ctx.SaveChangesAsync();

            //var newOrderDto = newOrder.ConvertToDto(newOrder);

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            if (ctx.Orders == null)
            {
                return NotFound();
            }
            var order = await ctx.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            ctx.Orders.Remove(order);
            await ctx.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (ctx.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
