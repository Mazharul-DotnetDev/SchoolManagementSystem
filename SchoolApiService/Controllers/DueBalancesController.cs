using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DueBalancesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public DueBalancesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/DueBalances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DueBalance>>> GetdbsDueBalance()
        {
            return await _context.dbsDueBalance.ToListAsync();
        }

        // GET: api/DueBalances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DueBalance>> GetDueBalance(int id)
        {
            var dueBalance = await _context.dbsDueBalance.FindAsync(id);

            if (dueBalance == null)
            {
                return NotFound();
            }

            return dueBalance;
        }

        // PUT: api/DueBalances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDueBalance(int id, DueBalance dueBalance)
        {
            if (id != dueBalance.DueBalanceId)
            {
                return BadRequest();
            }

            _context.Entry(dueBalance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DueBalanceExists(id))
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

        // POST: api/DueBalances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DueBalance>> PostDueBalance(DueBalance dueBalance)
        {
            _context.dbsDueBalance.Add(dueBalance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDueBalance", new { id = dueBalance.DueBalanceId }, dueBalance);
        }

        // DELETE: api/DueBalances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDueBalance(int id)
        {
            var dueBalance = await _context.dbsDueBalance.FindAsync(id);
            if (dueBalance == null)
            {
                return NotFound();
            }

            _context.dbsDueBalance.Remove(dueBalance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DueBalanceExists(int id)
        {
            return _context.dbsDueBalance.Any(e => e.DueBalanceId == id);
        }
    }
}
