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
    public class StaffSalariesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public StaffSalariesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/StaffSalaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffSalary>>> GetdbsStaffSalary()
        {
            return await _context.dbsStaffSalary.ToListAsync();
        }

        // GET: api/StaffSalaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffSalary>> GetStaffSalary(int id)
        {
            var staffSalary = await _context.dbsStaffSalary.FindAsync(id);

            if (staffSalary == null)
            {
                return NotFound();
            }

            return staffSalary;
        }

        // PUT: api/StaffSalaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffSalary(int id, StaffSalary staffSalary)
        {
            if (id != staffSalary.StaffSalaryId)
            {
                return BadRequest();
            }

            _context.Entry(staffSalary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffSalaryExists(id))
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

        // POST: api/StaffSalaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StaffSalary>> PostStaffSalary(StaffSalary staffSalary)
        {
            _context.dbsStaffSalary.Add(staffSalary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffSalary", new { id = staffSalary.StaffSalaryId }, staffSalary);
        }

        // DELETE: api/StaffSalaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffSalary(int id)
        {
            var staffSalary = await _context.dbsStaffSalary.FindAsync(id);
            if (staffSalary == null)
            {
                return NotFound();
            }

            _context.dbsStaffSalary.Remove(staffSalary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffSalaryExists(int id)
        {
            return _context.dbsStaffSalary.Any(e => e.StaffSalaryId == id);
        }
    }
}
