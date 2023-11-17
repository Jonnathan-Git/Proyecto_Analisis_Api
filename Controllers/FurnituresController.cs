using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalisisProyecto.Models.DB;

namespace AnalisisProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnituresController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public FurnituresController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/Furnitures
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<Furniture>>> GetFurnitures()
        {
          if (_context.Furnitures == null)
          {
              return NotFound();
          }
            return await _context.Furnitures.ToListAsync();
        }

        // GET: api/Furnitures/5
        [HttpGet()]
        [Route("getFurniture/{id}")]
        public async Task<ActionResult<Furniture>> GetFurniture(int id)
        {
          if (_context.Furnitures == null)
          {
              return NotFound();
          }
            var furniture = await _context.Furnitures.FindAsync(id);

            if (furniture == null)
            {
                return NotFound();
            }

            return furniture;
        }

        // PUT: api/Furnitures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        [Route("updateFurnitures/{id}")]
        public async Task<IActionResult> PutFurniture(int id, Furniture furniture)
        {
            if (id != furniture.Id)
            {
                return BadRequest();
            }

            _context.Entry(furniture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FurnitureExists(id))
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

        // POST: api/Furnitures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("createFurniture")]
        public async Task<ActionResult<Furniture>> PostFurniture(Furniture furniture)
        {
          if (_context.Furnitures == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.Furnitures'  is null.");
          }
            _context.Furnitures.Add(furniture);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFurniture", new { id = furniture.Id }, furniture);
        }

        // DELETE: api/Furnitures/5
        [HttpDelete()]
        [Route("deleteFurnitures/{id}")]
        public async Task<IActionResult> DeleteFurniture(int id)
        {
            if (_context.Furnitures == null)
            {
                return NotFound();
            }
            var furniture = await _context.Furnitures.FindAsync(id);
            furniture.Active= false;
            if (furniture == null)
            {
                return NotFound();
            }

           // _context.Furnitures.Remove(furniture);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FurnitureExists(int id)
        {
            return (_context.Furnitures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
