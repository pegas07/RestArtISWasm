using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestArtIS.Server.Data;
using RestArtIS.Shared.Models;

namespace RestArtIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var s = await _context.Settings.ToListAsync();
            if (s.Count == 0)
            {
                _context.Add(new Settings());
                await _context.SaveChangesAsync();
                s = await _context.Settings.ToListAsync();
            }
            return Ok(s);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var s = await _context.Settings.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(s);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Settings settings)
        {
            _context.Add(settings);
            await _context.SaveChangesAsync();
            return Ok(settings.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Settings settings)
        {
            _context.Entry(settings).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var settings = new Settings { Id = id };
            _context.Remove(settings);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
