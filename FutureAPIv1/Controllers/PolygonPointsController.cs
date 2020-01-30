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
    public class PolygonPointsController : ControllerBase
    {
        private readonly FutureAPIv1Context _context;

        public PolygonPointsController(FutureAPIv1Context context)
        {
            _context = context;
        }

        // GET: api/PolygonPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolygonPoints>>> GetPolygonPoints()
        {
            return await _context.PolygonPoints.ToListAsync();
        }

        // GET: api/PolygonPoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PolygonPoints>> GetPolygonPoints(int id)
        {
            var polygonPoints = await _context.PolygonPoints.FindAsync(id);

            if (polygonPoints == null)
            {
                return NotFound();
            }

            return polygonPoints;
        }

        // PUT: api/PolygonPoints/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolygonPoints(int id, PolygonPoints polygonPoints)
        {
            if (id != polygonPoints.PolyPointID)
            {
                return BadRequest();
            }

            _context.Entry(polygonPoints).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolygonPointsExists(id))
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

        // POST: api/PolygonPoints
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PolygonPoints>> PostPolygonPoints(PolygonPoints polygonPoints)
        {
            _context.PolygonPoints.Add(polygonPoints);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolygonPoints", new { id = polygonPoints.PolyPointID }, polygonPoints);
        }

        // DELETE: api/PolygonPoints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PolygonPoints>> DeletePolygonPoints(int id)
        {
            var polygonPoints = await _context.PolygonPoints.FindAsync(id);
            if (polygonPoints == null)
            {
                return NotFound();
            }

            _context.PolygonPoints.Remove(polygonPoints);
            await _context.SaveChangesAsync();

            return polygonPoints;
        }

        private bool PolygonPointsExists(int id)
        {
            return _context.PolygonPoints.Any(e => e.PolyPointID == id);
        }
    }
}
