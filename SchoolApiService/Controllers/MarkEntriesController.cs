using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MarkEntriesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public MarkEntriesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/MarkEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarkEntry>>> GetdbsMarkEntry()
        {
            return await _context.dbsMarkEntry
                .Include(m => m.Staff)
                .Include(m => m.Subject)
                .ToListAsync();
        }

        // GET: api/MarkEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarkEntry>> GetMarkEntry(int id)
        {
            var markEntry = await _context.dbsMarkEntry.FindAsync(id);

            if (markEntry == null)
            {
                return NotFound();
            }

            return markEntry;
        }

        // PUT: api/MarkEntries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarkEntry(int id, MarkEntry markEntry)
        {
            if (id != markEntry.MarkEntryId)
            {
                return BadRequest();
            }

            _context.Entry(markEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkEntryExists(id))
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

        // POST: api/MarkEntries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MarkEntry>> PostMarkEntry(MarkEntry markEntry)
        {
            _context.dbsMarkEntry.Add(markEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarkEntry", new { id = markEntry.MarkEntryId }, markEntry);
        }

        // DELETE: api/MarkEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarkEntry(int id)
        {
            var markEntry = await _context.dbsMarkEntry.FindAsync(id);
            if (markEntry == null)
            {
                return NotFound();
            }

            _context.dbsMarkEntry.Remove(markEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarkEntryExists(int id)
        {
            return _context.dbsMarkEntry.Any(e => e.MarkEntryId == id);
        }
    }
}
