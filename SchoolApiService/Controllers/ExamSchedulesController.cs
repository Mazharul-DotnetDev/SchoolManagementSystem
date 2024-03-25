using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.SchoolContext;
using SchoolApp.Models.DataModels;
//using SchoolApp.Models.ViewModels;

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
                .Include(es => es.Standard)
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
                .Include(es => es.Standard)
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
        public async Task<IActionResult> UpdateExamSchedule(int id, ExamSchedule updatedExamSchedule)
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
                if (updatedExamSchedule.ExamTypeId.HasValue)
                {
                    existingExamSchedule.ExamTypeId = updatedExamSchedule.ExamTypeId;
                }

                // Update ExamSubjects if ExamSubjects collection is provided
                if (updatedExamSchedule.ExamSubjects != null && updatedExamSchedule.ExamSubjects.Any())
                {
                    existingExamSchedule.ExamSubjects.Clear(); // Clear existing ExamSubjects

                    foreach (var examSubject in updatedExamSchedule.ExamSubjects)
                    {
                        // Ensure ExamScheduleId is set correctly for each ExamSubject
                        examSubject.ExamScheduleId = id;
                        existingExamSchedule.ExamSubjects.Add(examSubject);
                    }
                }

                // Update Standard if provided
                if (updatedExamSchedule.StandardId != 0)
                {
                    existingExamSchedule.StandardId = updatedExamSchedule.StandardId;
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

        [HttpPost]
        public async Task<ActionResult<ExamSchedule>> PostExamSchedule(ExamSchedule examSchedule)
        {
            // Check if ExamType exists
            if (examSchedule.ExamTypeId.HasValue &&
                !await _context.dbsExamType.AnyAsync(e => e.ExamTypeId == examSchedule.ExamTypeId))
            {
                return BadRequest("Invalid ExamTypeId provided.");
            }

            // Check if Standard exists
            if (!await _context.dbsStandard.AnyAsync(s => s.StandardId == examSchedule.StandardId))
            {
                return BadRequest("Invalid StandardId provided.");
            }

            // Validate ExamSubjects (assuming GetExamSubjectsByIdsAsync retrieves ExamSubject objects based on IDs)
            var existingExamSubjects = await GetExamSubjectsByIdsAsync(examSchedule.ExamSubjects.Select(es => es.ExamSubjectId).ToList());

            // Check if the number of retrieved ExamSubjects matches the number of requested ExamSubjectIds
            if (existingExamSubjects.Count != examSchedule.ExamSubjects.Count)
            {
                return BadRequest("One or more invalid ExamSubjectIds provided.");
            }

            // Create a new ExamSchedule object
            var newExamSchedule = new ExamSchedule
            {
                ExamScheduleName = examSchedule.ExamScheduleName,
                ExamTypeId = examSchedule.ExamTypeId,
                StandardId = examSchedule.StandardId
            };

            // Add retrieved ExamSubject objects to the new ExamSchedule's ExamSubjects collection
            newExamSchedule.ExamSubjects = existingExamSubjects;

            // Save the ExamSchedule object
            _context.dbsExamSchedule.Add(newExamSchedule);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle potential database update exceptions (optional)
                // You can log the exception details here for debugging purposes
                return BadRequest("An error occurred while saving the exam schedule. Please contact the administrator.");
            }

            return CreatedAtAction("GetExamSchedule", new { id = newExamSchedule.ExamScheduleId }, newExamSchedule);
        }

        // Helper method (PostExamSchedule Method) to retrieve ExamSubjects by IDs (replace with your actual implementation)
        private async Task<List<ExamSubject>> GetExamSubjectsByIdsAsync(List<int> examSubjectIds)
        {
            return await _context.dbsExamSubject.Where(es => examSubjectIds.Contains(es.ExamSubjectId)).ToListAsync();
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
