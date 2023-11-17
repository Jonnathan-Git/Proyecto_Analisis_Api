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
    public class LoanVehiclesController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public LoanVehiclesController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/LoanVehicles
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<LoanVehicle>>> GetLoanVehicles()
        {
          if (_context.LoanVehicles == null)
          {
              return NotFound();
          }
            return await _context.LoanVehicles.ToListAsync();
        }

        // GET: api/LoanVehicles/5
        [HttpGet()]
        [Route("getLoanVehicle/{id}")]
        public async Task<ActionResult<LoanVehicle>> GetLoanVehicle(int id)
        {
          if (_context.LoanVehicles == null)
          {
              return NotFound();
          }
            var loanVehicle = await _context.LoanVehicles.FindAsync(id);

            if (loanVehicle == null)
            {
                return NotFound();
            }

            return loanVehicle;
        }
        [HttpGet()]
        [Route("getLoanVehicleAllById/{id}")]
        public async Task<ActionResult<IEnumerable<LoanVehicle>>> GetLoanVehicleAllById(int id) {
            if (_context.LoanVehicles == null) {
                return NotFound();
            }
            return await _context.LoanVehicles.Where(v => v.IdUser == id).Include(p => p.IdLoanNavigation).ToListAsync();
        }

        // PUT: api/LoanVehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut()]
        [Route("updateLoanVehicle/{id}")]
        public async Task<IActionResult> PutLoanVehicle(int id, LoanVehicle loanVehicle)
        {
            if (id != loanVehicle.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanVehicle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanVehicleExists(id))
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

        // POST: api/LoanVehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("createLoanVehicle")]
        public async Task<ActionResult<LoanVehicle>> PostLoanVehicle(LoanVehicle loanVehicle)
        {
          if (_context.LoanVehicles == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.LoanVehicles'  is null.");
          }
            _context.LoanVehicles.Add(loanVehicle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanVehicle", new { id = loanVehicle.Id }, loanVehicle);
        }

        // DELETE: api/LoanVehicles/5
        [HttpDelete()]
        [Route("deleteLoanVehicles/{id}")]
        public async Task<IActionResult> DeleteLoanVehicle(int id)
        {
            if (_context.LoanVehicles == null)
            {
                return NotFound();
            }
            var loanVehicle = await _context.LoanVehicles.FindAsync(id);
            loanVehicle.Active = false;
            if (loanVehicle == null)
            {
                return NotFound();
            }

           // _context.LoanVehicles.Remove(loanVehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanVehicleExists(int id)
        {
            return (_context.LoanVehicles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
