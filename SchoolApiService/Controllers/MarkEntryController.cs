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
    public class MarkEntryController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public MarkEntryController(SchoolDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarkEntry>>> GetdbsMarkEntry()
        {
            return await _context.dbsMarkEntry
                .Include(m => m.Staff)
                .Include(m => m.ExamSchedule)
                .Include(m => m.ExamType)
                .Include(m => m.Subject)
                .Include(m => m.Students)
                .ToListAsync();
        }

        // GET: api/MarkEntry/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarkEntry>> GetMarkEntry(int id)
        {
            var markEntry = await _context.dbsMarkEntry
                .Include(m => m.Staff)
                .Include(m => m.ExamSchedule)
                .Include(m => m.ExamType)
                .Include(m => m.Subject)
                .Include(m => m.Students)
                .FirstOrDefaultAsync(m => m.MarkEntryId == id);
               
            if (markEntry == null)
            {
                return NotFound("Sorry! No Mark is found. Try next time. Good luck.");
            }

            return markEntry;
        }

       
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


        #region Default_Post
        //[HttpPost]
        //public async Task<ActionResult<MarkEntry>> PostMarkEntry(MarkEntry markEntry)
        //{
        //    _context.dbsMarkEntry.Add(markEntry);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMarkEntry", new { id = markEntry.MarkEntryId }, markEntry);
        //} 
        #endregion


        [HttpPost]
        public async Task<IActionResult> PostMarkEntry(MarkEntry markEntry)
        {
            try
            {
                // Check if the SubjectId provided is valid and exists
                var subject = await _context.dbsSubject
                    .Include(s => s.Standard)
                    .FirstOrDefaultAsync(s => s.SubjectId == markEntry.SubjectId);

                if (subject == null)
                {
                    return BadRequest("Invalid SubjectId provided.");
                }

                // Check if the StaffId provided is valid and exists
                var staff = await _context.dbsStaff
                    .FirstOrDefaultAsync(s => s.StaffId == markEntry.StaffId);

                if (staff == null)
                {
                    return BadRequest("Invalid StaffId provided.");
                }

                // Check if the ExamScheduleId provided is valid and exists
                var examSchedule = await _context.dbsExamSchedule
                    .FirstOrDefaultAsync(e => e.ExamScheduleId == markEntry.ExamScheduleId);

                if (examSchedule == null)
                {
                    return BadRequest("Invalid ExamScheduleId provided.");
                }

                // Check if the provided Students' ids are valid for the given Subject
                if (markEntry.Students != null && markEntry.Students.Any())
                {
                    var validStudentIds = await _context.dbsStudent
                        .Where(s => s.StandardId == subject.StandardId) // Filter by the same standard as the subject
                        .Select(s => s.StudentId)
                        .ToListAsync();

                    var invalidStudentIds = markEntry.Students
                        .Select(s => s.StudentId)
                        .Except(validStudentIds)
                        .ToList();

                    if (invalidStudentIds.Any())
                    {
                        return BadRequest($"Invalid StudentIds provided: {string.Join(", ", invalidStudentIds)}");
                    }
                }

                // All checks passed, proceed to save the mark entry
                _context.dbsMarkEntry.Add(markEntry);
                await _context.SaveChangesAsync();

                //return Ok("Marks entry successful.");
                return CreatedAtAction("GetMarkEntry", new { id = markEntry.MarkEntryId }, markEntry);
            }
            catch (Exception ex)
            {
                
                //return StatusCode(500, "An error occurred while processing the request.");
                return StatusCode(500, ex.Message);
            }
        }





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
