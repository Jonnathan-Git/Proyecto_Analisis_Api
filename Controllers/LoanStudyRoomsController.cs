using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalisisProyecto.Models.DB;
using AnalisisProyecto.Models.DTO;

namespace AnalisisProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanStudyRoomsController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public LoanStudyRoomsController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/LoanStudyRooms
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<LoanAndStudyRoom>>> GetLoanStudyRooms()
        {
          if (_context.LoanStudyRooms == null)
          {
              return NotFound();
          }
            List<LoanStudyRoom> lista = await _context.LoanStudyRooms.ToListAsync();
            List<LoanAndStudyRoom> lista_items = new List<LoanAndStudyRoom>();
            foreach (var item in lista)
            {
                //Consulta de Loan por id -- 
                Loan loan = await _context.Loans.FindAsync(item.LoanId);
                LoanAndStudyRoom lv = new LoanAndStudyRoom(item.Id,item.NumberOfPeople,item.LoanId, 
                    item.IdUserLibrary, item.StudyRoomId,item.ReturnHour, item.ExitHour, item.Active, loan.StartDate, loan.EndDate, item.State);
                Console.WriteLine(lv.Id);
                lista_items.Add(lv);
            }
            return lista_items;
        }


        [HttpGet]
        [Route("getLoanStudyRoomUser/{id}")]
        public async Task<ActionResult<IEnumerable<LoanAndStudyRoom>>> GetLoanStudyRoomsUser(int id)
        {
            var userLoanStudyRooms = await _context.LoanStudyRooms
                .Where(lsr => lsr.IdUserLibrary == id)
                .ToListAsync();

            if (userLoanStudyRooms == null || userLoanStudyRooms.Count == 0)
            {
                return Ok();
            }

            var result = new List<LoanAndStudyRoom>();
            foreach (var item in userLoanStudyRooms)
            {
                Loan loan = await _context.Loans.FindAsync(item.LoanId);

                LoanAndStudyRoom lv = new LoanAndStudyRoom(
                    item.Id, item.NumberOfPeople, item.LoanId,
                    item.IdUserLibrary, item.StudyRoomId, item.ReturnHour,
                    item.ExitHour, item.Active, loan.StartDate, loan.EndDate, item.State);

                Console.WriteLine(lv.Id);
                result.Add(lv);
            }

            return result;
        }


        // GET: api/LoanStudyRooms/5
        [HttpGet]
        [Route("getLoanStudyRoom/{id}")]
        public async Task<ActionResult<LoanStudyRoom>> GetLoanStudyRoom(int id)
        {
          if (_context.LoanStudyRooms == null)
          {
              return NotFound();
          }
            var loanStudyRoom = await _context.LoanStudyRooms.FindAsync(id);

            if (loanStudyRoom == null)
            {
                return NotFound();
            }

            return loanStudyRoom;
        }

        // PUT: api/LoanStudyRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("updateLoanStudyRooms/{id}")]
        public async Task<IActionResult> PutLoanStudyRoom(int id, LoanStudyRoom loanStudyRoom)
        {
            if (id != loanStudyRoom.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanStudyRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanStudyRoomExists(id))
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

        // POST: api/LoanStudyRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("createLoanStudyRoom")]
        public async Task<ActionResult<LoanStudyRoom>> PostLoanStudyRoom(LoanStudyRoom loanStudyRoom)
        {

          if (_context.LoanStudyRooms == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.LoanStudyRooms'  is null.");
          }
            _context.LoanStudyRooms.Add(loanStudyRoom);
            Console.WriteLine("Id:  "+loanStudyRoom.LoanId);
            await _context.SaveChangesAsync();

          
            return NoContent(); 
        }

        // DELETE: api/LoanStudyRooms/5
        [HttpDelete]
        [Route("deleteLoanStudyRooms/{id}")]
        public async Task<IActionResult> DeleteLoanStudyRoom(int id)
        {
            if (_context.LoanStudyRooms == null)
            {
                return NotFound();
            }
            var loanStudyRoom = await _context.LoanStudyRooms.FindAsync(id);
                loanStudyRoom.Active = false;
            if (loanStudyRoom == null)
            {
                return NotFound();
            }

          //  _context.LoanStudyRooms.Remove(loanStudyRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanStudyRoomExists(int id)
        {
            return (_context.LoanStudyRooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
