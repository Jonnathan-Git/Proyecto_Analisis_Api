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
    public class ComputerEquipmentsController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public ComputerEquipmentsController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/ComputerEquipments
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<ComputerEquipment>>> GetComputerEquipments()
        {
          if (_context.ComputerEquipments == null)
          {
              return NotFound();
          }
            return await _context.ComputerEquipments.ToListAsync();
        }

        // GET: api/ComputerEquipments/5
        [HttpGet]
        [Route("getById/{id}")]
        public async Task<ActionResult<ComputerEquipment>> GetComputerEquipment(int id)
        {
          if (_context.ComputerEquipments == null)
          {
              return NotFound();
          }
            var computerEquipment = await _context.ComputerEquipments.FindAsync(id);

            if (computerEquipment == null)
            {
                return NotFound();
            }

            return computerEquipment;
        }

        // PUT: api/ComputerEquipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> PutComputerEquipment(ComputerEquipment computerEquipment)
        {

            _context.Entry(computerEquipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        // POST: api/ComputerEquipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ComputerEquipment>> PostComputerEquipment(ComputerEquipment computerEquipment)
        {
          if (_context.ComputerEquipments == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.ComputerEquipments'  is null.");
          }
            _context.ComputerEquipments.Add(computerEquipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComputerEquipment", new { id = computerEquipment.Id }, computerEquipment);
        }

        // DELETE: api/ComputerEquipments/5
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteComputerEquipment(int id)
        {
            if (_context.ComputerEquipments == null)
            {
                return NotFound();
            }
            var computerEquipment = await _context.ComputerEquipments.FindAsync(id);
            if (computerEquipment == null)
            {
                return NotFound();
            }

            computerEquipment.Active = false;

            _context.ComputerEquipments.Update(computerEquipment);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComputerEquipmentExists(int id)
        {
            return (_context.ComputerEquipments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
