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
    public class DeliveryRouteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeliveryRouteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.DeliveryRoutes.ToListAsync();
            return Ok(devs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.DeliveryRoutes.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DeliveryRoute deliveryRoute)
        {
            _context.Add(deliveryRoute);
            await _context.SaveChangesAsync();
            return Ok(deliveryRoute.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(DeliveryRoute deliveryRoute)
        {
            _context.Entry(deliveryRoute).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deliveryRoute = new DeliveryRoute { Id = id };
            _context.Remove(deliveryRoute);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
