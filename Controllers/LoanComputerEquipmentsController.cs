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
    public class LoanComputerEquipmentsController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public LoanComputerEquipmentsController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/LoanComputerEquipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanComputerEquipment>>> GetLoanComputerEquipments()
        {
          if (_context.LoanComputerEquipments == null)
          {
              return NotFound();
          }
            return await _context.LoanComputerEquipments.ToListAsync();
        }

        // GET: api/LoanComputerEquipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanComputerEquipment>> GetLoanComputerEquipment(int id)
        {
          if (_context.LoanComputerEquipments == null)
          {
              return NotFound();
          }
            var loanComputerEquipment = await _context.LoanComputerEquipments.FindAsync(id);

            if (loanComputerEquipment == null)
            {
                return NotFound();
            }

            return loanComputerEquipment;
        }

        [HttpGet]
        [Route("getLoanComputerEquipmentByIdUser/{idUser}")]
        public async Task<ActionResult<IEnumerable<LoanComputerEquipment>>> GetLoanComputerEquipmentByIdUser(int idUser)
        {
          if (_context.LoanComputerEquipments == null)
            {
              return NotFound();
          }
            var loanComputerEquipment = _context.LoanComputerEquipments.Where(x => x.IdLibraryUser == idUser)
                .Select(l => new LoanComputerEquipment
                {
                    Id = l.Id,
                    IdLibraryUser = l.IdLibraryUser,
                    IdComputerEquipment = l.IdComputerEquipment,
                    IdLoan = l.IdLoan,
                    Assets = l.Assets,
                    AssetEvaluation = l.AssetEvaluation,
                    DestinationPlace = l.DestinationPlace,
                    State = l.State,
                    Dependence = l.Dependence,
                    RequestActivity = l.RequestActivity,

                    IdLibraryUserNavigation = new LibraryUser
                    {
                        Id = l.IdLibraryUserNavigation.Id,
                        IdUser = l.IdLibraryUserNavigation.IdUser,

                        IdUserNavigation = new Userr
                        {
                            Name = l.IdLibraryUserNavigation.IdUserNavigation.Name
                        }
                    }
                }).ToList();

            if (loanComputerEquipment == null)
            {
                return NotFound();
            }

            return loanComputerEquipment;
        }

        // PUT: api/LoanComputerEquipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanComputerEquipment(int id, LoanComputerEquipment loanComputerEquipment)
        {
            if (id != loanComputerEquipment.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanComputerEquipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanComputerEquipmentExists(id))
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

        // POST: api/LoanComputerEquipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanComputerEquipment>> PostLoanComputerEquipment(LoanComputerEquipment loanComputerEquipment)
        {
          if (_context.LoanComputerEquipments == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.LoanComputerEquipments'  is null.");
          }
            _context.LoanComputerEquipments.Add(loanComputerEquipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanComputerEquipment", new { id = loanComputerEquipment.Id }, loanComputerEquipment);
        }

        // DELETE: api/LoanComputerEquipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanComputerEquipment(int id)
        {
            if (_context.LoanComputerEquipments == null)
            {
                return NotFound();
            }
            var loanComputerEquipment = await _context.LoanComputerEquipments.FindAsync(id);
            if (loanComputerEquipment == null)
            {
                return NotFound();
            }

            _context.LoanComputerEquipments.Remove(loanComputerEquipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanComputerEquipmentExists(int id)
        {
            return (_context.LoanComputerEquipments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
