using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalisisProyecto.Models.DB;

namespace AnalisisProyecto.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase {
        private readonly AnalisisProyectoContext _context;

        public AreasController(AnalisisProyectoContext context) {
            _context = context;
        }

        // GET: api/Areas
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas() {
            if (_context.Areas == null) {
                return NotFound();
            }
            return await _context.Areas.ToListAsync();
        }

        // GET: api/Areas/5
        [HttpGet]
        [Route("getArea/{id}")]
        public async Task<ActionResult<Area>> GetArea(int id) {
            if (_context.Areas == null) {
                return NotFound();
            }
            var area = await _context.Areas.FindAsync(id);

            if (area == null) {
                return NotFound();
            }

            return area;
        }

        [HttpGet]
        [Route("getAreasByIdInventory/{id}")]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreasByIdInventory(int id) {
            if (_context.Areas == null) {
                return NotFound();
            }
            var areas = await _context.Areas.Where(i => i.InventoryId == id).ToListAsync();

            if (areas == null) {
                return NotFound();
            }

            return areas;
        }

        // PUT: api/Areas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("updateArea/")]
        public async Task<IActionResult> PutArea(Area area) { 

            _context.Entry(area).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!AreaExists(area.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Areas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("createArea")]
        public async Task<ActionResult<Area>> PostArea(Area area) {
            if (_context.Areas == null) {
                return Problem("Entity set 'AnalisisProyectoContext.Areas'  is null.");
            }

            if (area.Area1 == null) {
                return BadRequest();
            }
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArea", new { id = area.Id }, area);
        }

        // DELETE: api/Areas/5
        [HttpDelete]
        [Route("deleteArea/{id}")]
        public async Task<IActionResult> DeleteArea(int id) {
            if (_context.Areas == null) {
                return NotFound();
            }
            var area = await _context.Areas.FindAsync(id);
            if (area == null) {
                return NotFound();
            }

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaExists(int id) {
            return (_context.Areas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
