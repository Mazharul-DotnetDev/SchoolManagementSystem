using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class MarksController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public MarksController(SchoolDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mark>>> GetdbsMark()
        {
            var marks = await _context.dbsMark
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .ToListAsync();

            return marks;
        }

        // GET: api/Marks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mark>> GetMark(int id)
        {
            var mark = await _context.dbsMark
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.MarkId == id);

            if (mark == null)
            {
                return NotFound("Sorry! No Mark is found. Try next time. Good luck.");
            }

            return mark;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutMark(int id, Mark mark)
        {
            if (id != mark.MarkId)
            {
                return BadRequest("The ID in the request body does not match the ID in the route parameter.");
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

            _context.Entry(mark).State = EntityState.Modified;

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

            return Ok("Mark updated successfully!");
        }




        [HttpPost]
        public async Task<ActionResult<Mark>> PostMark(Mark mark)
        {
            try
            {
                // Check if the provided StudentId exists in the database
                var existingStudent = await _context.dbsStudent.FindAsync(mark.StudentId);
                if (existingStudent == null)
                {
                    return BadRequest("Invalid StudentId. Please provide a valid StudentId.");
                }

                // Check if the provided SubjectId exists in the database
                var existingSubject = await _context.dbsSubject.FindAsync(mark.SubjectId);
                if (existingSubject == null)
                {
                    return BadRequest("Invalid SubjectId. Please provide a valid SubjectId.");
                }

                // If both StudentId and SubjectId are valid, proceed with adding the mark
                _context.dbsMark.Add(mark);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMark", new { id = mark.MarkId }, new
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

            return NoContent();
        }

        private bool MarkExists(int id)
        {
            return _context.dbsMark.Any(e => e.MarkId == id);
        }
    }
}
