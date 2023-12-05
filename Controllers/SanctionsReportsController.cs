using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalisisProyecto.Models.DB;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace AnalisisProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanctionsReportsController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public SanctionsReportsController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/SanctionsReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanctionsReport>>> GetSanctionsReports()
        {
          if (_context.SanctionsReports == null)
          {
              return NotFound();
          }

          var sanctionsReports = _context.SanctionsReports
                .Include(l=> l.IdSanctionComputerEquipmentNavigation)
                .Include(i=>i.IdLibraryUserNavigation).ThenInclude(i=>i.IdUserNavigation)
                .Include(r=> r.IdReturnComputerEquipmentNavigation)
                .ToList();


            return Ok(sanctionsReports);
        }

        // GET: api/SanctionsReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanctionsReport>> GetSanctionsReport(int id)
        {
          if (_context.SanctionsReports == null)
          {
              return NotFound();
          }
            var sanctionsReport = await _context.SanctionsReports.FindAsync(id);

            if (sanctionsReport == null)
            {
                return NotFound();
            }

            return sanctionsReport;
        }

        // PUT: api/SanctionsReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSanctionsReport(int id, SanctionsReport sanctionsReport)
        {
            if (id != sanctionsReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(sanctionsReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanctionsReportExists(id))
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

        // POST: api/SanctionsReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SanctionsReport>> PostSanctionsReport(SanctionsReport sanctionsReport)
        {
          if (_context.SanctionsReports == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.SanctionsReports'  is null.");
          }
            _context.SanctionsReports.Add(sanctionsReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSanctionsReport", new { id = sanctionsReport.Id }, sanctionsReport);
        }

        // DELETE: api/SanctionsReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanctionsReport(int id)
        {
            if (_context.SanctionsReports == null)
            {
                return NotFound();
            }
            var sanctionsReport = await _context.SanctionsReports.FindAsync(id);
            if (sanctionsReport == null)
            {
                return NotFound();
            }

            sanctionsReport.Active = false;
            _context.SanctionsReports.Update(sanctionsReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SanctionsReportExists(int id)
        {
            return (_context.SanctionsReports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
