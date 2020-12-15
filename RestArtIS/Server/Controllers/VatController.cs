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
    public class VatController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VatController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var devs = await _context.Vats.Include(v => v.VatHistories).ToListAsync();
            return Ok(devs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dev = await _context.Vats.Include(v => v.VatHistories).FirstOrDefaultAsync(a => a.Id == id);
            return Ok(dev);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Vat vat)
        {
            _context.Add(vat);
            SaveVatHistories(vat.VatHistories);
            await _context.SaveChangesAsync();
            return Ok(vat.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Vat vat)
        {
            _context.Entry(vat).State = EntityState.Modified;
            SaveVatHistories(vat.VatHistories);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private void SaveVatHistories(ICollection<VatHistory> vatHistories)
        {
            vatHistories.Where(i => i.Id == 0)?.ToList()
                .ForEach(e =>
                {
                    _context.Add(e);
                });
            //_context.Add(vatHistories.Where(i => i.Id == 0));
            vatHistories.Where(i => i.Id > 0)?.ToList()?.ForEach(e => _context.Entry(e).State = EntityState.Modified);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vat = new Vat { Id = id };
            _context.Remove(vat);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
