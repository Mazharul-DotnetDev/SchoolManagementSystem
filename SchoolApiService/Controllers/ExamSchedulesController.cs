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
    public class ExamSchedulesController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public ExamSchedulesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamSchedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamSchedule>>> GetExamSchedules()
        {
            var examSchedules = await _context.dbsExamSchedule
                .Include(es => es.ExamType)
                .Include(es => es.ExamSubjects)
                .ToListAsync();

            // Load Subjects for each ExamSubject
            foreach (var examSchedule in examSchedules)
            {
                await _context.Entry(examSchedule)
                    .Collection(es => es.ExamSubjects)
                    .Query()
                    .Include(es => es.Subject)
                    .LoadAsync();
            }

            return examSchedules;
        }

        // GET: api/ExamSchedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamSchedule>> GetExamSchedule(int id)
        {
            var examSchedule = await _context.dbsExamSchedule
                .Include(es => es.ExamType)
                .Include(es => es.ExamSubjects)
                .AsNoTracking() // Use AsNoTracking for read-only operations
                .FirstOrDefaultAsync(es => es.ExamScheduleId == id);

            if (examSchedule == null)
            {
                return NotFound();
            }

            // Explicitly load related subjects
            if (examSchedule.ExamSubjects != null && examSchedule.ExamSubjects.Any())
            {
                foreach (var examSubject in examSchedule.ExamSubjects)
                {
                    await _context.Entry(examSubject)
                        .Reference(es => es.Subject)
                        .LoadAsync();
                }
            }

            return examSchedule;
        }


        // POST: api/ExamSchedules
        [HttpPost]
        public async Task<ActionResult<ExamSchedule>> PostExamSchedule(ExamSchedule examScheduleRequest)
        {
            // Create a new ExamSchedule object
            var examSchedule = new ExamSchedule
            {
                ExamScheduleName = examScheduleRequest.ExamScheduleName,
                ExamTypeId = examScheduleRequest.ExamTypeId,
                SubjectId = examScheduleRequest.SubjectId
            };

            // Add the ExamSchedule to the context
            _context.dbsExamSchedule.Add(examSchedule);

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();

                // Add ExamSubjects if SubjectIds are provided
                if (examScheduleRequest.SubjectId != null && examScheduleRequest.SubjectId.Any())
                {
                    foreach (var subjectId in examScheduleRequest.SubjectId)
                    {
                        var examSubject = new ExamSubject
                        {
                            SubjectId = subjectId,
                            ExamScheduleId = examSchedule.ExamScheduleId
                        };
                        _context.dbsExamSubject.Add(examSubject);
                    }
                    await _context.SaveChangesAsync();
                }

                // Return a 201 Created response with the created ExamSchedule
                return CreatedAtAction(nameof(GetExamSchedule), new { id = examSchedule.ExamScheduleId }, examSchedule);
            }
            catch (DbUpdateException ex)
            {
                // Log the exception or handle it as per your application's requirement
                // For example, you can return a specific error message to the client
                return StatusCode(500, $"An error occurred while saving the ExamSchedule: {ex.Message}");
            }
        }

        // PUT: api/ExamSchedules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExamSchedule(int id, [FromBody] ExamSchedule updatedExamSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var existingExamSchedule = await _context.dbsExamSchedule
                        .Include(es => es.ExamSubjects)
                        .FirstOrDefaultAsync(es => es.ExamScheduleId == id);

                    if (existingExamSchedule == null)
                    {
                        return NotFound($"ExamSchedule with ID {id} not found.");
                    }

                    // Update properties of the existing exam schedule
                    existingExamSchedule.ExamScheduleName = updatedExamSchedule.ExamScheduleName;
                    existingExamSchedule.ExamTypeId = updatedExamSchedule.ExamTypeId;
                    existingExamSchedule.SubjectId = updatedExamSchedule.SubjectId;

                    // Clear existing ExamSubjects
                    existingExamSchedule.ExamSubjects.Clear();

                    // Add new ExamSubjects if SubjectId is provided
                    if (updatedExamSchedule.SubjectId != null && updatedExamSchedule.SubjectId.Any())
                    {
                        foreach (var subjectId in updatedExamSchedule.SubjectId)
                        {
                            existingExamSchedule.ExamSubjects.Add(new ExamSubject { SubjectId = subjectId });
                        }
                    }

                    // Save changes to the database
                    await _context.SaveChangesAsync();

                    transaction.Commit();

                    return Ok(existingExamSchedule);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex}");

                    transaction.Rollback();
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }




        // DELETE: api/ExamSchedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamSchedule(int id)
        {
            var examSchedule = await _context.dbsExamSchedule.FindAsync(id);
            if (examSchedule == null)
            {
                return NotFound();
            }

            _context.dbsExamSchedule.Remove(examSchedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamScheduleExists(int id)
        {
            return _context.dbsExamSchedule.Any(es => es.ExamScheduleId == id);
        }
    }
}
