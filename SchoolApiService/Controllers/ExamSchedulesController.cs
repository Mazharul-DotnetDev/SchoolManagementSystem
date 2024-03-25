using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;
using SchoolApp.Models.ViewModels;

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

        // GET: api/ExamSchedules/GetExamSchedules
        [HttpGet("GetExamSchedules")]
        public async Task<ActionResult<IEnumerable<ExamSchedule>>> GetExamSchedules()
        {
            var examSchedules = await _context.dbsExamSchedule
                .Include(es => es.ExamType)
                .Include(es => es.ExamSubjects)
                    .ThenInclude(es => es.Subject)
                .ToListAsync();

            if (examSchedules == null)
            {
                return NotFound(); // 404 Not Found
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
                    .ThenInclude(es => es.Subject) // Include related Subject entities
                .AsNoTracking()
                .FirstOrDefaultAsync(es => es.ExamScheduleId == id);

            if (examSchedule == null)
            {
                return NotFound();
            }

            return examSchedule;
        }


        // PUT: api/ExamSchedules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExamSchedule(int id, SaveExamScheduleVM updatedExamSchedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingExamSchedule = await _context.dbsExamSchedule
                    .Include(es => es.ExamSubjects)
                    .FirstOrDefaultAsync(es => es.ExamScheduleId == id);

                if (existingExamSchedule == null)
                {
                    return NotFound($"ExamSchedule with ID {id} not found.");
                }

                // Update properties of the existing exam schedule if provided
                if (!string.IsNullOrEmpty(updatedExamSchedule.ExamScheduleName))
                {
                    existingExamSchedule.ExamScheduleName = updatedExamSchedule.ExamScheduleName;
                }
                if (updatedExamSchedule.ExamTypeId != 0)
                {
                    existingExamSchedule.ExamTypeId = updatedExamSchedule.ExamTypeId;
                }

                // Update ExamSubjects if SubjectIds are provided
                if (updatedExamSchedule.SubjectIds != null && updatedExamSchedule.SubjectIds.Any())
                {
                    existingExamSchedule.ExamSubjects.Clear(); // Clear existing ExamSubjects

                    foreach (var subjectId in updatedExamSchedule.SubjectIds)
                    {
                        var existingExamSubject = await _context.dbsExamSubject.FindAsync(subjectId);
                        if (existingExamSubject != null)
                        {
                            existingExamSubject.ExamScheduleId = id; // Update ExamScheduleId of existing ExamSubject
                        }
                        // You can handle the case where a SubjectId doesn't exist if needed
                    }
                }

                await _context.SaveChangesAsync();

                return Ok(existingExamSchedule);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        // POST: api/ExamSchedules
        [HttpPost("PostExamSchedule")]
        public async Task<ActionResult<ExamSchedule>> PostExamSchedule(SaveExamScheduleVM examScheduleRequest)
        {
            // Create a new ExamSchedule object
            var examSchedule = new ExamSchedule
            {
                ExamScheduleName = examScheduleRequest.ExamScheduleName,
                ExamTypeId = examScheduleRequest.ExamTypeId
            };

            // Add the ExamSchedule to the context
            _context.dbsExamSchedule.Add(examSchedule);

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();

                // Add ExamSubjects if SubjectIds are provided
                if (examScheduleRequest.SubjectIds != null && examScheduleRequest.SubjectIds.Any())
                {
                    foreach (var subjectId in examScheduleRequest.SubjectIds)
                    {
                        // Check if the ExamSubjectId already exists
                        var existingExamSubject = await _context.dbsExamSubject.FindAsync(subjectId);
                        if (existingExamSubject != null)
                        {
                            // If it exists, associate it with the current exam schedule
                            existingExamSubject.ExamScheduleId = examSchedule.ExamScheduleId;
                        }
                        //else
                        //{
                        //	// If it doesn't exist, create a new ExamSubject with the provided ID
                        //	var examSubject = new ExamSubject
                        //	{
                        //		ExamSubjectId = subjectId,
                        //		ExamScheduleId = examSchedule.ExamScheduleId
                        //	};
                        //	_context.ExamSubjects.Add(examSubject);
                        //}
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


    }
}
