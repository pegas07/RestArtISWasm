using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestArtIS.Server.Data;
using RestArtIS.Shared.Models;

namespace RestArtIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemTemplateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MenuItemTemplateController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.MenuItemTemplates.ToListAsync();
            return Ok(devs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.MenuItemTemplates.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MenuItemTemplate menuItemTemplate)
        {
            _context.Add(menuItemTemplate);
            await _context.SaveChangesAsync();
            return Ok(menuItemTemplate.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(MenuItemTemplate menuItemTemplate)
        {
            _context.Entry(menuItemTemplate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var menuItemTemplate = new MenuItemTemplate { Id = id };
            _context.Remove(menuItemTemplate);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
