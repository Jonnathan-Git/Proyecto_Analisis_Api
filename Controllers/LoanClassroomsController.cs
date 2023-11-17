using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalisisProyecto.Models.DB;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AnalisisProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanClassroomsController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public LoanClassroomsController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/LoanClassrooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanClassroom>>> GetLoanClassrooms()
        {
            if (_context.LoanClassrooms == null)
            {
                return NotFound();
            }
            return await _context.LoanClassrooms.ToListAsync();
        }

        // GET: api/LoanClassrooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanClassroom>> GetLoanClassroom(int id)
        {
            if (_context.LoanClassrooms == null)
            {
                return NotFound();
            }
            var loanClassroom = await _context.LoanClassrooms.FindAsync(id);

            if (loanClassroom == null)
            {
                return NotFound();
            }

            return loanClassroom;
        }

        // PUT: api/LoanClassrooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanClassroom(int id, LoanClassroom loanClassroom)
        {
            if (id != loanClassroom.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanClassroom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanClassroomExists(id))
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

        // POST: api/LoanClassrooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanClassroom>> PostLoanClassroom(LoanClassroom loanClassroom)
        {
            if (_context.LoanClassrooms == null)
            {
                return Problem("Entity set 'AnalisisProyectoContext.LoanClassrooms'  is null.");
            }
            _context.LoanClassrooms.Add(loanClassroom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanClassroom", new { id = loanClassroom.Id }, loanClassroom);
        }

        // DELETE: api/LoanClassrooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanClassroom(int id)
        {
            if (_context.LoanClassrooms == null)
            {
                return NotFound();
            }
            var loanClassroom = await _context.LoanClassrooms.FindAsync(id);
            if (loanClassroom == null)
            {
                return NotFound();
            }

            _context.LoanClassrooms.Remove(loanClassroom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LoanClassroomExists(int id)
        {
            return (_context.LoanClassrooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost("CheckAvailability")]
        public ActionResult<bool> CheckAvailability(ClassroomAvailability input)
        {
            try
            {
                var formattedStartDate = input.StartDate.ToString("yyyy-MM-dd");
                var formattedEndDate = input.EndDate.ToString("yyyy-MM-dd");

                var parameters = new[]
                {
            new SqlParameter("@day", SqlDbType.NVarChar) { Value = input.Day },
            new SqlParameter("@start_date", SqlDbType.Date) { Value = formattedStartDate },
            new SqlParameter("@end_date", SqlDbType.Date) { Value = formattedEndDate },
            new SqlParameter("@classroom_id", SqlDbType.Int) { Value = input.ClassroomId },
            new SqlParameter("@start_hour", SqlDbType.Time) { Value = input.StartHour },
            new SqlParameter("@end_hour", SqlDbType.Time) { Value = input.EndHour },
            new SqlParameter("@is_available", SqlDbType.Int) { Direction = ParameterDirection.Output }
        };

                // Ejecutar procedimiento almacenado y obtener el valor de @is_available
                _context.Database.ExecuteSqlRaw("EXEC CheckAvailability @day, @start_date, @end_date, @classroom_id, @start_hour, @end_hour, @is_available OUTPUT", parameters);

                // Obtener el valor de @is_available del array de parámetros
                var isAvailable = (int)parameters[6].Value;

                // Convertir el valor numérico a booleano (si es necesario)
                var result = (isAvailable == 1);

                // Verificar el resultado según tu lógica
                Console.WriteLine("Is Available: " + result);

                return result;
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                Console.WriteLine(ex.Message);
                return false;
            }
        }


    }
}