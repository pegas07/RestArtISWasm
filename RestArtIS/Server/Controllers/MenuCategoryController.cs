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
    public class MenuCategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MenuCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.MenuCategories.Include(mc => mc.MenuType).ToListAsync();
            return Ok(devs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var mc = await _context.MenuCategories.Include(mc => mc.MenuType).FirstOrDefaultAsync(a => a.Id == id);
            return Ok(mc);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MenuCategory menuCategory)
        {
            _context.Add(menuCategory);
            await _context.SaveChangesAsync();
            return Ok(menuCategory.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(MenuCategory menuCategory)
        {
            _context.Entry(menuCategory).State = EntityState.Modified;
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
