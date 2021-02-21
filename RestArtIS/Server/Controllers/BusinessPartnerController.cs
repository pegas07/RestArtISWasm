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
    public class BusinessPartnerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BusinessPartnerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bps = await _context.BusinessPartners.Include(rd => rd.DeliveryRoute).ToListAsync();
            return Ok(bps);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var bp = await _context.BusinessPartners.Include(rd => rd.DeliveryRoute).FirstOrDefaultAsync(a => a.Id == id);
            return Ok(bp);
        }

        [Route("[action]/{text}")]
        [HttpGet]
        public async Task<IActionResult> Search(string text)
        {
            var bps = await _context.BusinessPartners.Include(rd => rd.DeliveryRoute).Where(bp => (bp.Name != null && bp.Name.Contains(text)) || (bp.Code != null && bp.Code.Contains(text))).ToListAsync();
            return Ok(bps);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BusinessPartner businessPartner)
        {
            businessPartner.DeliveryRoute = _context.DeliveryRoutes.FirstOrDefault(dr => dr.Id == businessPartner.DeliveryRouteId);
            _context.Add(businessPartner);
            await _context.SaveChangesAsync();
            return Ok(businessPartner.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BusinessPartner businessPartner)
        {
            _context.Entry(businessPartner).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var businessPartner = new BusinessPartner { Id = id };
            _context.Remove(businessPartner);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
