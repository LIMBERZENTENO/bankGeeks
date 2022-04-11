#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankGeeks.Models;

namespace BankGeeks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorsController : ControllerBase
    {
        private readonly CalculatorContext _context;

        public CalculatorsController(CalculatorContext context)
        {
            _context = context;
        }

        // GET: api/Calculators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calculator>>> GetCalculators()
        {
            return await _context.Calculator.ToListAsync();
        }

        // GET: api/Calculators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calculator>> GetCalculator(long id)
        {
            var calculator = await _context.Calculator.FindAsync(id);

            if (calculator == null)
            {
                return NotFound();
            }

            return calculator;
        }

        // PUT: api/Calculators/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculator(long id, Calculator calculator)
        {
            if (id != calculator.id)
            {
                return BadRequest();
            }

            _context.Entry(calculator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculatorExists(id))
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

        // POST: api/Calculators
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calculator>> PostCalculator([FromForm]Calculator calculator)
        {
            _context.Calculator.Add(calculator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalculator", new { id = calculator.id }, calculator);
        }

        // DELETE: api/Calculators/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalculator(long id)
        {
            var calculator = await _context.Calculator.FindAsync(id);
            if (calculator == null)
            {
                return NotFound();
            }

            _context.Calculator.Remove(calculator);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalculatorExists(long id)
        {
            return _context.Calculator.Any(e => e.id == id);
        }
    }
}
