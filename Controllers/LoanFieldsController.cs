﻿using System;
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
    public class LoanFieldsController : ControllerBase
    {
        private readonly AnalisisProyectoContext _context;

        public LoanFieldsController(AnalisisProyectoContext context)
        {
            _context = context;
        }

        // GET: api/LoanFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanField>>> GetLoanFields()
        {
          if (_context.LoanFields == null)
          {
              return NotFound();
          }
            return await _context.LoanFields.ToListAsync();
        }

        // GET: api/LoanFields/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanField>> GetLoanField(int id)
        {
          if (_context.LoanFields == null)
          {
              return NotFound();
          }
            var loanField = await _context.LoanFields.FindAsync(id);

            if (loanField == null)
            {
                return NotFound();
            }

            return loanField;
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> PutLoanField(LoanField loanField)
        {
            if (_context.LoanFields == null)
            {
                return Problem("Entity set 'AnalisisProyectoContext.Titles'  is null.");
            }
            _context.Entry(loanField).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanField", new { id = loanField.Id }, loanField);

        }
       

        // POST: api/LoanFields
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LoanField>> PostLoanField(LoanField loanField)
        {
          if (_context.LoanFields == null)
          {
              return Problem("Entity set 'AnalisisProyectoContext.LoanFields'  is null.");
          }
            _context.LoanFields.Add(loanField);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanField", new { id = loanField.Id }, loanField);
        }


        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteLoanField(LoanField loanField)
        {
            if (_context.LoanFields == null)
            {
                return NotFound();
            }
            _context.Entry(loanField).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            if (loanField == null)
            {
                return NotFound();
            }

            return NoContent();
        }


        private bool LoanFieldExists(int id)
        {
            return (_context.LoanFields?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
