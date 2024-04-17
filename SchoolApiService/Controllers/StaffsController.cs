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
    //[Authorize]
    public class StaffsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public StaffsController(SchoolDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetdbsStaff()
        {
            return await _context.dbsStaff
                .Include(m => m.Department)
                .Include(m => m.StaffSalary)
                .Include(m => m.StaffExperiences)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
            var staff = await _context.dbsStaff
                .Include(m => m.Department)
                .Include(m => m.StaffSalary)
                .Include(m => m.StaffExperiences)
                .FirstOrDefaultAsync(m => m.StaffId == id);

            if (staff == null)
            {
                //return NotFound();
                return NotFound("Sorry! No Staff is found. Try next time. Good luck.");
            }

            return staff;
        }
     

        #region Default_Post
        //[HttpPost]
        //public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        //{
        //    _context.dbsStaff.Add(staff);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStaff", new { id = staff.StaffId }, staff);
        //} 
        #endregion

        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            // Check if the DepartmentId is valid
            if (staff.DepartmentId != null)
            {
                staff.Department = await _context.dbsDepartment.FindAsync(staff.DepartmentId);
                if (staff.Department == null)
                {
                    return BadRequest("Invalid DepartmentId");
                }
            }

            // Check if the StaffSalaryId is valid
            if (staff.StaffSalaryId != null)
            {
                staff.StaffSalary = await _context.dbsStaffSalary.FindAsync(staff.StaffSalaryId);
                if (staff.StaffSalary == null)
                {
                    return BadRequest("Invalid StaffSalaryId");
                }
            }

            // Add the StaffExperiences to the context if they are provided
            if (staff.StaffExperiences != null && staff.StaffExperiences.Any())
            {
                foreach (var experience in staff.StaffExperiences)
                {
                    _context.dbsStaffExperience.Add(experience);
                }
            }

            // Add the Staff to the context
            _context.dbsStaff.Add(staff);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Unable to save changes. Please try again.");
            }

            return CreatedAtAction("GetdbsStaff", new { id = staff.StaffId }, staff);
        }


        #region Default_Put
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStaff(int id, Staff staff)
        //{
        //    if (id != staff.StaffId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(staff).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StaffExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //} 
        #endregion


        // PUT: api/Staffs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest("Invalid StaffId");
            }
            
            // Since StaffSalary is created in advance
            if (staff.StaffSalaryId != null)
            {
                staff.StaffSalary = await _context.dbsStaffSalary.FindAsync(staff.StaffSalaryId);
                if (staff.StaffSalary == null)
                {
                    return BadRequest("Invalid StaffSalaryId");
                }
            }

            
            // Since Department is created in advance
            if (staff.DepartmentId != null)
            {
                staff.Department = await _context.dbsDepartment.FindAsync(staff.DepartmentId);
                if (staff.Department == null)
                {
                    return BadRequest("Invalid DepartmentId");
                }
            }

            // Update the StaffExperiences if they are provided
            if (staff.StaffExperiences != null && staff.StaffExperiences.Any())
            {
                foreach (var experience in staff.StaffExperiences)
                {
                    if (experience.StaffExperienceId == 0)
                    {
                        _context.dbsStaffExperience.Add(experience);
                    }
                    else
                    {
                        _context.Entry(experience).State = EntityState.Modified;
                    }
                }
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _context.dbsStaff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.dbsStaff.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffExists(int id)
        {
            return _context.dbsStaff.Any(e => e.StaffId == id);
        }
    }
}
