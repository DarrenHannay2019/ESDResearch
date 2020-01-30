using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FutureAPIv1;
using FutureAPIv1.Data;

namespace FutureAPIv1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolygonsController : ControllerBase
    {
        private readonly FutureAPIv1Context _context;

        public PolygonsController(FutureAPIv1Context context)
        {
            _context = context;
        }

        // GET: api/Polygons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Polygons>>> GetPolygons()
        {
            return await _context.Polygons.ToListAsync();
        }

        // GET: api/Polygons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Polygons>> GetPolygons(int id)
        {
            var polygons = await _context.Polygons.FindAsync(id);

            if (polygons == null)
            {
                return NotFound();
            }

            return polygons;
        }

        // PUT: api/Polygons/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolygons(int id, Polygons polygons)
        {
            if (id != polygons.objectID)
            {
                return BadRequest();
            }

            _context.Entry(polygons).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolygonsExists(id))
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

        // POST: api/Polygons
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Polygons>> PostPolygons(Polygons polygons)
        {
            _context.Polygons.Add(polygons);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolygons", new { id = polygons.objectID }, polygons);
        }

        // DELETE: api/Polygons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Polygons>> DeletePolygons(int id)
        {
            var polygons = await _context.Polygons.FindAsync(id);
            if (polygons == null)
            {
                return NotFound();
            }

            _context.Polygons.Remove(polygons);
            await _context.SaveChangesAsync();

            return polygons;
        }

        private bool PolygonsExists(int id)
        {
            return _context.Polygons.Any(e => e.objectID == id);
        }
    }
}
