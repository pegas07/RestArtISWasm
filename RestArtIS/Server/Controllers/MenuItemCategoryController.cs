using Microsoft.AspNetCore.Http;
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
    public class MenuItemCategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MenuItemCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.MenuItemCategories.ToListAsync();
            return Ok(devs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mc = await _context.MenuItemCategories.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(mc);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MenuItemCategory menuItemCategory)
        {
            _context.Add(menuItemCategory);
            await _context.SaveChangesAsync();
            return Ok(menuItemCategory.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(MenuItemCategory menuItemCategory)
        {
            _context.Entry(menuItemCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mc = new MenuCategory { Id = id };
            _context.Remove(mc);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
