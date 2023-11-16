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
    public class LoansController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public LoansController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/Loans
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
        {
          if (_context.Loans == null)
          {
              return NotFound();
          }
            return await _context.Loans.ToListAsync();
        }

        // GET: api/Loans/5
        [HttpGet]
        [Route("getById/{id}")]
        public async Task<ActionResult<Loan>> GetLoan(int id)
        {
          if (_context.Loans == null)
          {
              return NotFound();
          }
            var loan = await _context.Loans.FindAsync(id);

            if (loan == null)
            {
                return NotFound();
            }

            return loan;
        }

        // PUT: api/Loans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> PutLoan(Loan loan)
        {
            if (_context.Loans == null) {
                return Problem("Entity set 'AnalisisProyectoContext.Titles'  is null.");
            }
            _context.Entry(loan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitle", new { id = loan.Id }, loan);
        }

        // POST: api/Loans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Loan>> PostLoan(Loan loan)
        {
          if (_context.Loans == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.Loans'  is null.");
          }
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoan", new { id = loan.Id }, loan);
        }

        // DELETE: api/Loans/5
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            if (_context.Loans == null)
            {
                return NotFound();
            }
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
            {
                return NotFound();
            }

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanExists(int id)
        {
            return (_context.Loans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
