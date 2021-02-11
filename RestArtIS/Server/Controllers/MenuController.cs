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
    public class MenuController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.Menus.Include(m => m.MenuCategory).ToListAsync();
            return Ok(devs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.Menus
                .Include(m => m.MenuCategory)
                    .ThenInclude(mc => mc.MenuType)
                .Include(mi => mi.MenuItems).FirstOrDefaultAsync(a => a.Id == id);
            return Ok(dev);
        }

        [Route("[action]/{categoryId}")]
        [HttpGet]
        public async Task<IActionResult> GetDateFromTo(int categoryId)
        {
            var lastMenu = await _context.Menus.OrderByDescending(o => o.DateFrom).FirstOrDefaultAsync(m => m.MenuCategoryId == categoryId);
            var now = DateTime.Now.Date;
            DateTime from, to;
            
            if (lastMenu != null)
            {
                from = lastMenu.DateFrom.Value.AddDays(7);
                to = lastMenu.DateTo.Value.AddDays(7);
            }
            else
            {
                from = now.AddDays((double)(1 - now.DayOfWeek));
                to = now.AddDays((double)(7 - now.DayOfWeek));
            }
            Tuple<DateTime,DateTime> dates = new Tuple<DateTime, DateTime>(from, to);
            return Ok(dates);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Menu menu)
        {
            menu.MenuCategory = _context.MenuCategories.FirstOrDefault(m => m.Id == menu.MenuCategoryId);
            _context.Add(menu);
            await _context.SaveChangesAsync();
            return Ok(menu.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Menu menu)
        {           
            var existingMenu = _context.Menus.Include(i => i.MenuItems).FirstOrDefault(m => m.Id == menu.Id);
            _context.Entry(existingMenu).CurrentValues.SetValues(menu);
            foreach (var item in menu.MenuItems)
            {
                var existingItem = existingMenu.MenuItems.AsQueryable().FirstOrDefault(i => i.Id == item.Id);
                if (existingItem == null)
                {
                    if (!string.IsNullOrWhiteSpace(item.Name) && !string.IsNullOrWhiteSpace(item.Name))
                        existingMenu.MenuItems.Add(item);
                }
                else
                {
                    _context.Entry(existingItem).CurrentValues.SetValues(item);
                }                
            }

            foreach (var existingItem in existingMenu.MenuItems)
            {
                if (!menu.MenuItems.Any(m => m.Id == existingItem.Id))
                    _context.Remove(existingItem);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var menu = new Menu { Id = id };
            _context.Remove(menu);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
