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
    public class InventoriesController : ControllerBase {
        private readonly AnalisisProyectoContext _context;

        public InventoriesController(AnalisisProyectoContext context) {
            _context = context;
        }

        // GET: api/Inventories
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories() {
            if (_context.Inventories == null) {
                return NotFound();
            }
            return await _context.Inventories.Where(u => u.deleted == false).ToListAsync();
        }

        // GET: api/Inventories/5
        [HttpGet]
        [Route("getInventory/{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(int id) {
            if (_context.Inventories == null) {
                return NotFound();
            }
            var inventory = await _context.Inventories.FindAsync(id);

            if (inventory == null) {
                return NotFound();
            }

            return inventory;
        }

        // PUT: api/Inventories/5
        [HttpPut]
        [Route("updateInventory/")]
        public async Task<IActionResult> PutInventory(Inventory inventory) {

            _context.Entry(inventory).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!InventoryExists(inventory.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Inventories
        [HttpPost]
        [Route("createInventory")]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory) {
            if (_context.Inventories == null) {
                return Problem("Entity set 'AnalisisProyectoContext.Inventories'  is null.");
            }

            if (inventory == null) return BadRequest("Inventory is null.");

            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventory", new { id = inventory.Id }, inventory);
        }

        // DELETE: api/Inventories/5
        [HttpDelete]
        [Route("deleteInventory/{id}")]
        public async Task<IActionResult> DeleteInventory(int id) {
            if (_context.Inventories == null) {
                return NotFound();
            }
            var inventory = await _context.Inventories.FindAsync(id);
            if (inventory == null) {
                return NotFound();
            }

            inventory.deleted = true;

            _context.Entry(inventory).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!InventoryExists(inventory.Id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            //_context.Inventories.Remove(inventory);
            //await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryExists(int id) {
            return (_context.Inventories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
