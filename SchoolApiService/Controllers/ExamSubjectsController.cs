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
    public class ExamSubjectController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public ExamSubjectController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamSubject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamSubject>>> GetExamSubjects()
        {
            var examSubjects = await _context.dbsExamSubject
                .Include(es => es.Subject)
                .AsNoTracking()
                .ToListAsync();

            return examSubjects;
        }

        // GET: api/ExamSubject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamSubject>> GetExamSubject(int id)
        {
            var examSubject = await _context.dbsExamSubject
                .Include(es => es.Subject)
                .AsNoTracking()
                .FirstOrDefaultAsync(es => es.ExamSubjectId == id);

            if (examSubject == null)
            {
                return NotFound();
            }

            return examSubject;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExamSubject(int id, [FromBody] ExamSubject updatedExamSubject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var existingExamSubject = await _context.dbsExamSubject
                        .FirstOrDefaultAsync(es => es.ExamSubjectId == id);

                    if (existingExamSubject == null)
                    {
                        return NotFound($"ExamSubject with ID {id} not found.");
                    }

                    // Update properties of the existing exam subject
                    existingExamSubject.ExamDate = updatedExamSubject.ExamDate;
                    existingExamSubject.SubjectId = updatedExamSubject.SubjectId;
                    existingExamSubject.ExamScheduleId = updatedExamSubject.ExamScheduleId;

                    // Save changes to the database
                    await _context.SaveChangesAsync();

                    transaction.Commit();

                    return Ok(existingExamSubject);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex}");

                    transaction.Rollback();
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }


        // POST: api/ExamSubject
        [HttpPost]
        public async Task<ActionResult<ExamSubject>> PostExamSubject(ExamSubject examSubjectRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Create a new ExamSubject object
                var examSubject = new ExamSubject
                {
                    ExamDate = examSubjectRequest.ExamDate,
                    SubjectId = examSubjectRequest.SubjectId,
                    ExamScheduleId = examSubjectRequest.ExamScheduleId
                };

                // Add the ExamSubject to the context
                _context.dbsExamSubject.Add(examSubject);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Return a 201 Created response with the created ExamSubject
                return CreatedAtAction(nameof(GetExamSubject), new { id = examSubject.ExamSubjectId }, examSubject);
            }
            catch (DbUpdateException ex)
            {
                // Log the exception or handle it as per your application's requirement
                // For example, you can return a specific error message to the client
                return StatusCode(500, $"An error occurred while saving the ExamSubject: {ex.Message}");
            }
        }


        // DELETE: api/ExamSubject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamSubject(int id)
        {
            var examSubject = await _context.dbsExamSubject.FindAsync(id);
            if (examSubject == null)
            {
                return NotFound();
            }

            _context.dbsExamSubject.Remove(examSubject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamSubjectExists(int id)
        {
            return _context.dbsExamSubject.Any(e => e.ExamSubjectId == id);
        }
    }
}
