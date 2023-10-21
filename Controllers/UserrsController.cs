using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnalisisProyecto.Models.DB;

namespace AnalisisProyecto.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserrsController : ControllerBase {
        private readonly AnalisisProyectoContext _context;

        public UserrsController(AnalisisProyectoContext context) {
            _context = context;
        }

        // GET: api/Userrs
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<IEnumerable<Userr>>> GetUserrs() {
            if (_context.Userrs == null) {
                return NotFound();
            }
            return await _context.Userrs.ToListAsync();
        }

        // GET: api/Userrs/5
        [HttpGet]
        [Route("getUser/{id}")]
        public async Task<ActionResult<Userr>> GetUserr(int id) {
            if (_context.Userrs == null) {
                return NotFound();
            }
            var userr = await _context.Userrs.FindAsync(id);

            if (userr == null) {
                return NotFound();
            }

            return userr;
        }

        // PUT: api/Userrs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("updateUser/{id}")]
        public async Task<IActionResult> PutUserr(int id, Userr userr) {
            if (id != userr.Id) {
                return BadRequest();
            }

            _context.Entry(userr).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!UserrExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return Ok(id);
        }

        // POST: api/Userrs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("createUser")]
        public async Task<ActionResult<Userr>> PostUserr(Userr userr) {
            if (_context.Userrs == null) {
                return Problem("Entity set 'AnalisisProyectoContext.Userrs'  is null.");
            }
            _context.Userrs.Add(userr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserr", new { id = userr.Id }, userr);
        }

        // DELETE: api/Userrs/5
        [HttpDelete]
        [Route("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUserr(int id) {
            if (_context.Userrs == null) {
                return NotFound();
            }
            var userr = await _context.Userrs.FindAsync(id);
            if (userr == null) {
                return NotFound();
            }

            userr.Deleted = true;
            _context.Entry(userr).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                return NotFound();
            }
            //_context.Userrs.Remove(userr);
            //await _context.SaveChangesAsync();

            return Ok(id);
        }

        private bool UserrExists(int id) {
            return (_context.Userrs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
