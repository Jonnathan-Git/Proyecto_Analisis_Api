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
    public class InventoryTypesController : ControllerBase {
        private readonly AnalisisProyectoContext _context;

        public InventoryTypesController(AnalisisProyectoContext context) {
            _context = context;
        }

        // GET: api/InventoryTypes
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<InventoryType>>> GetInventoryTypes() {
            if (_context.InventoryTypes == null) {
                return NotFound();
            }
            return await _context.InventoryTypes.ToListAsync();
        }

        // GET: api/InventoryTypes/5
        [HttpGet]
        [Route("getInventoryType/{id}")]
        public async Task<ActionResult<InventoryType>> GetInventoryType(int id) {
            if (_context.InventoryTypes == null) {
                return NotFound();
            }
            var inventoryType = await _context.InventoryTypes.FindAsync(id);

            if (inventoryType == null) {
                return NotFound();
            }

            return inventoryType;
        }

        [HttpGet]
        [Route("getInventoryTypesByIdInventory/{id}")]
        public async Task<ActionResult<IEnumerable<InventoryType>>> GetInventoryTypesByIdInventory(int id) {
            if (_context.InventoryTypes == null) {
                return NotFound();
            }
            var inventoryTypes = await _context.InventoryTypes.Where(i => i.InventoryId == id).ToListAsync();

            if (inventoryTypes == null) {
                return NotFound();
            }

            return inventoryTypes;
        }

        // PUT: api/InventoryTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("updateInventoryType/")]
        public async Task<IActionResult> PutInventoryType(InventoryType inventoryType) {

            _context.Entry(inventoryType).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!InventoryTypeExists(inventoryType.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InventoryTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("createInventoryType")]
        public async Task<ActionResult<InventoryType>> PostInventoryType(InventoryType inventoryType) {
            if (_context.InventoryTypes == null) {
                return Problem("Entity set 'AnalisisProyectoContext.InventoryTypes'  is null.");
            }
            _context.InventoryTypes.Add(inventoryType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryType", new { id = inventoryType.Id }, inventoryType);
        }

        // DELETE: api/InventoryTypes/5
        [HttpDelete]
        [Route("deleteInventoryType/{id}")]
        public async Task<IActionResult> DeleteInventoryType(int id) {
            if (_context.InventoryTypes == null) {
                return NotFound();
            }
            var inventoryType = await _context.InventoryTypes.FindAsync(id);
            if (inventoryType == null) {
                return NotFound();
            }

            _context.InventoryTypes.Remove(inventoryType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryTypeExists(int id) {
            return (_context.InventoryTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
