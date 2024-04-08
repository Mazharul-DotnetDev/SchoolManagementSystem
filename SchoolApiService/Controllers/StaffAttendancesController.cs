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
    public class StaffAttendancesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public StaffAttendancesController(SchoolDbContext context)
        {
            _context = context;
        }

        #region Default_Get
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<StaffAttendance>>> GetdbsStaffAttendance()
        //{
        //    return await _context.dbsStaffAttendance.ToListAsync();
        //}
        #endregion

        #region Manual_Get_Final
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffAttendance>>> GetdbsStaffAttendance()
        {
            return await _context.dbsStaffAttendance
                .Include(m => m.Staffs)
                .ToListAsync();
        } 
        #endregion


        #region Default_GetById
        //[HttpGet("{id}")]
        //public async Task<ActionResult<StaffAttendance>> GetStaffAttendance(int id)
        //{
        //    var staffAttendance = await _context.dbsStaffAttendance.FindAsync(id);

        //    if (staffAttendance == null)
        //    {
        //        return NotFound();
        //    }

        //    return staffAttendance;
        //}
        #endregion

        #region Manual_GetById_Final
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffAttendance>> GetStaffAttendance(int id)
        {
            //var staffAttendance = await _context.dbsStaffAttendance.FindAsync(id);

            var staffAttendance = await _context.dbsStaffAttendance
                .Include(m => m.Staffs)
                .FirstOrDefaultAsync(m => m.StaffAttendanceId == id);

            if (staffAttendance == null)
            {
                //return NotFound();
                return NotFound("Sorry! No StaffAttendance is found. Try next time. Good luck. Nota Bene: This message is generated from the Developer");
            }

            return staffAttendance;
        } 
        #endregion


        #region Default_Post
        //[HttpPost]
        //public async Task<ActionResult<StaffAttendance>> PostStaffAttendance(StaffAttendance staffAttendance)
        //{
        //    _context.dbsStaffAttendance.Add(staffAttendance);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStaffAttendance", new { id = staffAttendance.StaffAttendanceId }, staffAttendance);
        //} 
        #endregion

        #region Manual_Post_Final

        [HttpPost]
        public async Task<ActionResult<StaffAttendance>> poststaffattendance(StaffAttendance staffattendance)
        {
            // check if staffids exist in the staff table
            foreach (var staffid in staffattendance.Staffs.Select(s => s.StaffId))
            {
                var staffexists = await _context.dbsStaff.AnyAsync(s => s.StaffId == staffid);
                if (!staffexists)
                {
                    return BadRequest($"staff with id {staffid} does not exist.");
                }
            }

            // fetch staff instances from the database
            foreach (var staff in staffattendance.Staffs)
            {
                _context.Entry(staff).State = EntityState.Unchanged;
            }

            _context.dbsStaffAttendance.Add(staffattendance);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return CreatedAtAction("getstaffattendance", new { id = staffattendance.StaffAttendanceId }, staffattendance);
        }

        #endregion


        #region Default_Put
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStaffAttendance(int id, StaffAttendance staffAttendance)
        //{
        //    if (id != staffAttendance.StaffAttendanceId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(staffAttendance).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StaffAttendanceExists(id))
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

        #region Manual_Put_Final
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffAttendance(int id, StaffAttendance staffAttendance)
        {
            if (id != staffAttendance.StaffAttendanceId)
            {
                return BadRequest("StaffAttendanceId mismatch in request body and URL");
            }

            // Check if StaffAttendance exists
            if (!StaffAttendanceExists(id))
            {
                return NotFound("StaffAttendance not found with the provided ID");
            }

            // Retrieve existing StaffAttendance
            var existingAttendance = await _context.dbsStaffAttendance.Include(a => a.Staffs).FirstOrDefaultAsync(e => e.StaffAttendanceId == id);

            if (existingAttendance == null)
            {
                return NotFound("StaffAttendance not found with the provided ID");
            }

            // Validate Staff IDs (if provided)
            var invalidStaffIds = staffAttendance.Staffs?.Where(s => !_context.dbsStaff.Any(existingStaff => existingStaff.StaffId == s.StaffId)).Select(s => s.StaffId).ToList();

            if (invalidStaffIds?.Any() == true)
            {
                return BadRequest($"Invalid Staff IDs: {string.Join(", ", invalidStaffIds)}");
            }

            // Update existing StaffAttendance properties
            existingAttendance.WorkingDate = staffAttendance.WorkingDate; // Update WorkingDate
            existingAttendance.IsPresent = staffAttendance.IsPresent;   // Update IsPresent

            // Update Staffs collection (optional)
            if (staffAttendance.Staffs != null)
            {
                // Clear existing Staffs collection to avoid duplicates
                existingAttendance.Staffs.Clear();

                // Add new or existing Staffs based on provided IDs
                foreach (var staffId in staffAttendance.Staffs.Select(s => s.StaffId))
                {
                    var existingStaff = await _context.dbsStaff.FindAsync(staffId);
                    if (existingStaff != null)
                    {
                        existingAttendance.Staffs.Add(existingStaff);
                    }
                }
            }

            // Mark StaffAttendance for update (assuming DbContext change tracking)
            _context.Entry(existingAttendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw; // Re-throw for potential logging or handling
            }

            return NoContent();
        }
        #endregion


        #region Default_Delete

        // Not functional

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffAttendance(int id)
        {
            var staffAttendance = await _context.dbsStaffAttendance.FindAsync(id);
            if (staffAttendance == null)
            {
                return NotFound();
            }

            _context.dbsStaffAttendance.Remove(staffAttendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion


        private bool StaffAttendanceExists(int id)
        {
            return _context.dbsStaffAttendance.Any(e => e.StaffAttendanceId == id);
        }
    }
}
