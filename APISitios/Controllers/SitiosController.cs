using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APISitios.Context;
using APISitios.Models;

namespace APISitios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitiosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SitiosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Sitios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sitios>>> GetSitios()
        {
            return await _context.Sitios.ToListAsync();
        }

        // GET: api/Sitios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sitios>> GetSitios(int id)
        {
            var sitios = await _context.Sitios.FindAsync(id);

            if (sitios == null)
            {
                return NotFound();
            }

            return sitios;
        }

        // PUT: api/Sitios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSitios(int id, Sitios sitios)
        {
            if (id != sitios.Id)
            {
                return BadRequest();
            }

            _context.Entry(sitios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SitiosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Sitios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sitios>> PostSitios(Sitios sitios)
        {
            _context.Sitios.Add(sitios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSitios", new { id = sitios.Id }, sitios);
        }

        // DELETE: api/Sitios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSitios(int id)
        {
            var sitios = await _context.Sitios.FindAsync(id);
            if (sitios == null)
            {
                return NotFound();
            }

            _context.Sitios.Remove(sitios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SitiosExists(int id)
        {
            return _context.Sitios.Any(e => e.Id == id);
        }
    }
}
