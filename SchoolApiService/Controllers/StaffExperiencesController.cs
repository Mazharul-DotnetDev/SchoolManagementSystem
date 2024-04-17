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
    public class StaffExperiencesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public StaffExperiencesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/StaffExperiences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffExperience>>> GetdbsStaffExperience()
        {
            return await _context.dbsStaffExperience.ToListAsync();
        }

        // GET: api/StaffExperiences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffExperience>> GetStaffExperience(int id)
        {
            var staffExperience = await _context.dbsStaffExperience.FindAsync(id);

            if (staffExperience == null)
            {
                return NotFound();
            }

            return staffExperience;
        }

        // PUT: api/StaffExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffExperience(int id, StaffExperience staffExperience)
        {
            if (id != staffExperience.StaffExperienceId)
            {
                return BadRequest();
            }

            _context.Entry(staffExperience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExperienceExists(id))
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

        // POST: api/StaffExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StaffExperience>> PostStaffExperience(StaffExperience staffExperience)
        {
            _context.dbsStaffExperience.Add(staffExperience);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffExperience", new { id = staffExperience.StaffExperienceId }, staffExperience);
        }

        // DELETE: api/StaffExperiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffExperience(int id)
        {
            var staffExperience = await _context.dbsStaffExperience.FindAsync(id);
            if (staffExperience == null)
            {
                return NotFound();
            }

            _context.dbsStaffExperience.Remove(staffExperience);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffExperienceExists(int id)
        {
            return _context.dbsStaffExperience.Any(e => e.StaffExperienceId == id);
        }
    }
}
