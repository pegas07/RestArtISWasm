using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestArtIS.Server.Data;
using RestArtIS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestArtIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.Orders
                .Include(rd => rd.DeliveryRoute)
                .Include(oi => oi.OrderItems)
                .ToListAsync();
            return Ok(devs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.Orders
                .Include(rd => rd.DeliveryRoute)
                .Include(oi => oi.OrderItems)
                .FirstOrDefaultAsync(a => a.Id == id);
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            order.DeliveryRoute = _context.DeliveryRoutes.FirstOrDefault(dr => dr.Id == order.DeliveryRouteId);
            _context.Add(order);
            await _context.SaveChangesAsync();
            return Ok(order.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = new Order { Id = id };
            _context.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
