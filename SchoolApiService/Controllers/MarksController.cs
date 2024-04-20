using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class MarksController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public MarksController(SchoolDbContext context)
        {
            _context = context;
        }

        #region HttpGet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mark>>> GetdbsMark()
        {
            var marks = await _context.dbsMark
                .Include(m => m.Staff)
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .ToListAsync();

            return marks;
        } 
        #endregion

        #region HttpGetById
        // GET: api/Marks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mark>> GetMark(int id)
        {
            var mark = await _context.dbsMark
                .Include(m => m.Staff)
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.MarkId == id);

            if (mark == null)
            {
                return NotFound("Sorry! No Mark is found. Try next time. Good luck.");
            }

            return mark;
        } 
        #endregion

        #region HttpPut
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMark(int id, Mark mark)
        {
            if (id != mark.MarkId)
            {
                return BadRequest("The ID in the request body does not match the ID in the route parameter.");
            }

            // Check if the provided StaffId exists in the database
            if (mark.StaffId != null && !await _context.dbsStaff.AnyAsync(s => s.StaffId == mark.StaffId))
            {
                return BadRequest($"Invalid StaffId: {mark.StaffId}. The specified staff does not exist in the database.");
            }

            // Check if the provided StudentId exists in the database
            if (mark.StudentId != null && !await _context.dbsStudent.AnyAsync(s => s.StudentId == mark.StudentId))
            {
                return BadRequest($"Invalid StudentId: {mark.StudentId}. The specified student does not exist in the database.");
            }

            // Check if the provided SubjectId exists in the database
            if (mark.SubjectId != null && !await _context.dbsSubject.AnyAsync(s => s.SubjectId == mark.SubjectId))
            {
                return BadRequest($"Invalid SubjectId: {mark.SubjectId}. The specified subject does not exist in the database.");
            }

            //_context.Entry(mark).State = EntityState.Modified;

            // Update only the properties that are provided in the request
            //_context.Entry(mark).CurrentValues.SetValues(mark);

            // Why the following lines of code instead of the above two approaches? Answer: If the mark is updated without giving values of StudentId and SubjectId, it updates the Mark but it sets the StudentId and SubjectId to 'Null'.
            // Update only the received properties
            _context.Entry(mark).Property(p => p.TotalMarks).IsModified = mark.TotalMarks != null;
            _context.Entry(mark).Property(p => p.PassMarks).IsModified = mark.PassMarks != null;
            _context.Entry(mark).Property(p => p.ObtainedScore).IsModified = mark.ObtainedScore != null;
            _context.Entry(mark).Property(p => p.Grade).IsModified = mark.Grade != null;
            _context.Entry(mark).Property(p => p.PassStatus).IsModified = mark.PassStatus != null;
            _context.Entry(mark).Property(p => p.MarkEntryDate).IsModified = mark.MarkEntryDate != null;
            _context.Entry(mark).Property(p => p.Feedback).IsModified = mark.Feedback != null;
            _context.Entry(mark).Property(p => p.StaffId).IsModified = mark.StaffId != null;
            _context.Entry(mark).Property(p => p.StudentId).IsModified = mark.StudentId != null;
            _context.Entry(mark).Property(p => p.SubjectId).IsModified = mark.SubjectId != null;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkExists(id))
                {
                    return NotFound("Mark not found.");
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        } 
        #endregion

        #region HttpPost
        [HttpPost]
        public async Task<ActionResult<Mark>> PostMark(Mark mark)
        {
            try
            {
                // Check if the provided StaffId exists in the database
                var existingStaff = await _context.dbsStaff.FindAsync(mark.StaffId);
                if (existingStaff == null)
                {
                    return BadRequest("Invalid / Not given StaffId. Please provide a valid StaffId.");
                }

                // Check if the provided StudentId exists in the database
                var existingStudent = await _context.dbsStudent.FindAsync(mark.StudentId);
                if (existingStudent == null)
                {
                    return BadRequest("Invalid / Not given StudentId. Please provide a valid StudentId.");
                }

                // Check if the provided SubjectId exists in the database
                var existingSubject = await _context.dbsSubject.FindAsync(mark.SubjectId);
                if (existingSubject == null)
                {
                    return BadRequest("Invalid / Not given SubjectId. Please provide a valid SubjectId.");
                }

                // If all StudentId, SubjectId, & StaffId are valid, proceed with adding the mark
                _context.dbsMark.Add(mark);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetdbsMark", new { id = mark.MarkId }, new
                {
                    mark = mark,
                    message = $"You have just inserted ID: {mark.MarkId}"
                });
            }
            catch (Exception ex)
            {
                // Return a custom error message without any data.
                return BadRequest($"Ooops!!! Errrrrors!!: {ex.Message}");
            }
        }
        #endregion

        #region HttpDelete
        // DELETE: api/Marks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMark(int id)
        {
            var mark = await _context.dbsMark.FindAsync(id);
            if (mark == null)
            {
                return NotFound();
            }

            _context.dbsMark.Remove(mark);
            await _context.SaveChangesAsync();

            //return NoContent();
            return Ok();
        } 
        #endregion

        private bool MarkExists(int id)
        {
            return _context.dbsMark.Any(e => e.MarkId == id);
        }
    }
}
