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
    public class StudentAttendancesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public StudentAttendancesController(SchoolDbContext context)
        {
            _context = context;
        }       


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentAttendance>>> GetdbsStudentAttendance()
        {
            return await _context.dbsStudentAttendance
                .Include (m => m.Students)
                .ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StudentAttendance>> GetStudentAttendance(int id)
        {
            //var studentAttendance = await _context.dbsStudentAttendance.FindAsync(id);

            var studentAttendance = await _context.dbsStudentAttendance
                .Include(m => m.Students)
                .FirstOrDefaultAsync(m => m.StudentAttendanceId == id);


            if (studentAttendance == null)
            {
                //return NotFound();
                return NotFound("Sorry! No StudentAttendance is found. Try next time. Good luck. Nota Bene: This message is generated from the Developer");
            }

            return studentAttendance;
        }


        //[HttpPost]
        //public async Task<ActionResult<StudentAttendance>> PostStudentAttendance(StudentAttendance studentAttendance)
        //{
        //    _context.dbsStudentAttendance.Add(studentAttendance);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetStudentAttendance", new { id = studentAttendance.StudentAttendanceId }, studentAttendance);
        //}


        [HttpPost]
        public async Task<ActionResult<StudentAttendance>> PostStudentAttendance(StudentAttendance studentAttendance)
        {
            // check if studentids exist in the staff table
            foreach (var studentId in studentAttendance.Students.Select(s => s.StudentId))
            {
                var student = await _context.dbsStudent.Where(s => s.StudentId == studentId)
                             .Include(s => s.Standard)
                             .FirstOrDefaultAsync();
                if (student == null)
                {
                    return BadRequest($"student with id {studentId} does not exist.");
                }

                _context.Local.Add(student);
            }



            // fetch student instances from the database
            foreach (var student in studentAttendance.Students)
            {
                _context.Entry(student).State = EntityState.Unchanged;
            }

            _context.dbsStudentAttendance.Add(studentAttendance);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("GetStudentAttendance", new { id = studentAttendance.StudentAttendanceId }, studentAttendance);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentAttendance(int id, StudentAttendance studentAttendance)
        {
            if (id != studentAttendance.StudentAttendanceId)
            {
                return BadRequest();
            }

            _context.Entry(studentAttendance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAttendanceExists(id))
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
        public async Task<IActionResult> DeleteStudentAttendance(int id)
        {
            var studentAttendance = await _context.dbsStudentAttendance.FindAsync(id);
            if (studentAttendance == null)
            {
                return NotFound();
            }

            _context.dbsStudentAttendance.Remove(studentAttendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentAttendanceExists(int id)
        {
            return _context.dbsStudentAttendance.Any(e => e.StudentAttendanceId == id);
        }
    }
}
