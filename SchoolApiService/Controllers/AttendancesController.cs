using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApiService.ViewModels;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;

namespace SchoolApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AttendancesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public AttendancesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Attendances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetdbsAttendance()
        {
            return await _context.dbsAttendance.ToListAsync();
        }

        // GET: api/Attendances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendance(int id)
        {
            var attendance = await _context.dbsAttendance.FindAsync(id);

            if (attendance == null)
            {
                return NotFound();
            }

            return attendance;
        }

        [HttpGet("GetList/{Type}")]
        public async Task<ActionResult> GetList(AttendanceType Type)
        {


            List <AttList> data = new List <AttList> ();
            switch (Type)
            {
                case AttendanceType.Student:
                    data = await _context.dbsStudent.Select(s => new AttList()
                    {
                        AttId = s.UniqueStudentAttendanceNumber,
                        Name = $"{s.StudentId} - "+s.StudentName
                    }).ToListAsync(); 
                    break;
                case AttendanceType.Staff:
                    data = await _context.dbsStaff.Select(s => new AttList()
                    {
                        AttId = s.UniqueStaffAttendanceNumber,
                        Name = $"{s.StaffId} - " + s.StaffName
                    }).ToListAsync();
                    break;
            }
            return Ok(data);
        }

        #region Default_Post
        //[HttpPost]
        //public async Task<ActionResult<Attendance>> PostAttendance(Attendance attendance)
        //{
        //    _context.dbsAttendance.Add(attendance);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAttendance", new { id = attendance.AttendanceId }, attendance);
        //} 
        #endregion


        [HttpPost]
        public async Task<IActionResult> PostAttendance(Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the provided attendance type is valid
            if (!Enum.IsDefined(typeof(AttendanceType), attendance.Type))
            {
                return BadRequest("Invalid attendance type.");
            }
           
            // Check if the provided attendance identification number exists
            bool exists = false;
            switch (attendance.Type)
            {
                case AttendanceType.Student:
                    exists = await _context.dbsStudent.AnyAsync(s => s.UniqueStudentAttendanceNumber == attendance.AttendanceIdentificationNumber);
                    break;
                case AttendanceType.Staff:
                    exists = await _context.dbsStaff.AnyAsync(s => s.UniqueStaffAttendanceNumber == attendance.AttendanceIdentificationNumber);
                    break;
                default:
                    return BadRequest("Invalid attendance type.");
            }

            if (!exists)
            {
                return BadRequest("Invalid attendance identification number.");
            }

            _context.dbsAttendance.Add(attendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendance", new { id = attendance.AttendanceId }, attendance);
        }


        #region Default_PUT
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAttendance(int id, Attendance attendance)
        //{
        //    if (id != attendance.AttendanceId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(attendance).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AttendanceExists(id))
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



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(int id, Attendance attendance)
        {
            if (id != attendance.AttendanceId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Validation for update is similar to create, but without checking existence of attendance itself

            if (attendance.Type == AttendanceType.Student)
            {
                var studentExists = await _context.dbsStudent.AnyAsync(s => s.UniqueStudentAttendanceNumber == attendance.AttendanceIdentificationNumber);
                if (!studentExists)
                {
                    return BadRequest("Invalid student attendance number");
                }
            }
            else if (attendance.Type == AttendanceType.Staff)
            {
                var staffExists = await _context.dbsStaff.AnyAsync(s => s.UniqueStaffAttendanceNumber == attendance.AttendanceIdentificationNumber);
                if (!staffExists)
                {
                    return BadRequest("Invalid staff attendance number");
                }
            }
            else
            {
                return BadRequest("Invalid attendance type");
            }

            _context.Entry(attendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceExists(id))
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


        // DELETE: api/Attendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var attendance = await _context.dbsAttendance.FindAsync(id);
            if (attendance == null)
            {
                return NotFound();
            }

            _context.dbsAttendance.Remove(attendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AttendanceExists(int id)
        {
            return _context.dbsAttendance.Any(e => e.AttendanceId == id);
        }
    }
}
