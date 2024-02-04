using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.Models;

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize()]
    public class EmployeeTypesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public EmployeeTypesController(SchoolDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeType>>> GetdbsEmployeeType()
        {
            return await _context.dbsEmployeeType.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeType>> GetEmployeeType(int id)
        {
            var employeeType = await _context.dbsEmployeeType.FindAsync(id);

            if (employeeType == null)
            {
                return NotFound();
            }

            return employeeType;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeType(int id, EmployeeType employeeType)
        {
            if (id != employeeType.EmployeeTypeId)
            {
                return BadRequest();
            }

            _context.Entry(employeeType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeTypeExists(id))
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

        
        [HttpPost]
        public async Task<ActionResult<EmployeeType>> PostEmployeeType(EmployeeType employeeType)
        {
            _context.dbsEmployeeType.Add(employeeType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeType", new { id = employeeType.EmployeeTypeId }, employeeType);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeType(int id)
        {
            var employeeType = await _context.dbsEmployeeType.FindAsync(id);
            if (employeeType == null)
            {
                return NotFound();
            }

            _context.dbsEmployeeType.Remove(employeeType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeTypeExists(int id)
        {
            return _context.dbsEmployeeType.Any(e => e.EmployeeTypeId == id);
        }
    }
}
