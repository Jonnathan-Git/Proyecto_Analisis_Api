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
    public class LoanSportsEquipmentsController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public LoanSportsEquipmentsController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/LoanSportsEquipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanSportsEquipment>>> GetLoanSportsEquipments()
        {
          if (_context.LoanSportsEquipments == null)
          {
              return NotFound();
          }
            return await _context.LoanSportsEquipments.ToListAsync();
        }

        // GET: api/LoanSportsEquipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanSportsEquipment>> GetLoanSportsEquipment(int id)
        {
          if (_context.LoanSportsEquipments == null)
          {
              return NotFound();
          }
            var loanSportsEquipment = await _context.LoanSportsEquipments.FindAsync(id);

            if (loanSportsEquipment == null)
            {
                return NotFound();
            }

            return loanSportsEquipment;
        }

        // PUT: api/LoanSportsEquipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanSportsEquipment(int id, LoanSportsEquipment loanSportsEquipment)
        {
            if (id != loanSportsEquipment.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanSportsEquipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanSportsEquipmentExists(id))
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

        // POST: api/LoanSportsEquipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanSportsEquipment>> PostLoanSportsEquipment(LoanSportsEquipment loanSportsEquipment)
        {
          if (_context.LoanSportsEquipments == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.LoanSportsEquipments'  is null.");
          }
            _context.LoanSportsEquipments.Add(loanSportsEquipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanSportsEquipment", new { id = loanSportsEquipment.Id }, loanSportsEquipment);
        }

        // DELETE: api/LoanSportsEquipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanSportsEquipment(int id)
        {
            if (_context.LoanSportsEquipments == null)
            {
                return NotFound();
            }
            var loanSportsEquipment = await _context.LoanSportsEquipments.FindAsync(id);
            if (loanSportsEquipment == null)
            {
                return NotFound();
            }

            _context.LoanSportsEquipments.Remove(loanSportsEquipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanSportsEquipmentExists(int id)
        {
            return (_context.LoanSportsEquipments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
