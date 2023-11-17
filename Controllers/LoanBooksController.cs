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
    public class LoanBooksController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public LoanBooksController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/LoanBooks
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<LoanBook>>> GetLoanBooks()
        {
          if (_context.LoanBooks == null)
          {
              return NotFound();
          }
            return await _context.LoanBooks
                .Include(p => p.IdLoanNavigation)
                .ToListAsync();
        }

        [HttpGet]
        [Route("getAllByUserId/{id}")]
        public async Task<ActionResult<IEnumerable<LoanBook>>> GetLoanBooksByUserId(int id) {
          if (_context.LoanBooks == null) {
              return NotFound();
          }
            return await _context.LoanBooks.Where(l => l.IdLibraryUser == id)
                .Include(p => p.IdLoanNavigation)
                .ToListAsync();
        }

        // GET: api/LoanBooks/5
        [HttpGet]
        [Route("getById/{id}")]
        public async Task<ActionResult<LoanBook>> GetLoanBook(int id)
        {
          if (_context.LoanBooks == null)
          {
              return NotFound();
          }
            var loanBook = await _context.LoanBooks.FindAsync(id);

            if (loanBook == null)
            {
                return NotFound();
            }

            return loanBook;
        }

        // PUT: api/LoanBooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> PutLoanBook(LoanBook loanBook)
        {
            if (_context.LoanBooks == null) {
                return Problem("Entity set 'AnalisisProyectoContext.Titles'  is null.");
            }
            _context.Entry(loanBook).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanBook", new { id = loanBook.Id }, loanBook);
        }

        [HttpPut]
        [Route("approve/{id}")]
        public async Task<IActionResult> AppoveLoanBook(int id) {
            if (_context.LoanBooks == null) {
                return Problem("Entity set 'AnalisisProyectoContext.Titles'  is null.");
            }
            var loan = await _context.LoanBooks.FindAsync(id);
            loan.State = 1;
            _context.Entry(loan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Solicitud Aprobada con Exito");
        }

        [HttpPut]
        [Route("reject/{id}")]
        public async Task<IActionResult> RejectLoanBook(int id) {
            if (_context.LoanBooks == null) {
                return Problem("Entity set 'AnalisisProyectoContext.Titles'  is null.");
            }
            var loan = await _context.LoanBooks.FindAsync(id);
            loan.State = 2;
            _context.Entry(loan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Solicitud fue Rechazada");
        }

        // POST: api/LoanBooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<LoanBook>> PostLoanBook(LoanBook loanBook)
        {
          if (_context.LoanBooks == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.LoanBooks'  is null.");
          }
            _context.LoanBooks.Add(loanBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanBook", new { id = loanBook.Id }, loanBook);
        }

        // DELETE: api/LoanBooks/5
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteLoanBook(int id)
        {
            if (_context.LoanBooks == null)
            {
                return NotFound();
            }
            var loanBook = await _context.LoanBooks.FindAsync(id);
            if (loanBook == null)
            {
                return NotFound();
            }

            _context.LoanBooks.Remove(loanBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanBookExists(int id)
        {
            return (_context.LoanBooks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
