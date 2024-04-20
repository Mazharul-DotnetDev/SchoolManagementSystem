using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ExamSubjectsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public ExamSubjectsController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamSubject>>> GetdbsExamSubject()
        {
            var examSubjects = await _context.dbsExamSubject
                .Include(es => es.Subject)
                .ThenInclude(ess => ess.Standard)
                .AsNoTracking()
                .ToListAsync();


            return examSubjects;
        }

        // GET: api/ExamSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamSubject>> GetExamSubject(int id)
        {
            var examSubject = await _context.dbsExamSubject
                .Include(es => es.Subject)
                .ThenInclude(ess => ess.Standard)
                .AsNoTracking()
                .FirstOrDefaultAsync(es => es.ExamSubjectId == id);


            if (examSubject == null)
            {
                return NotFound();
            }

            return examSubject;
        }

        // PUT: api/ExamSubjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamSubject(int id, ExamSubject examSubject)
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

                    bool isExamDateProvided = examSubject.ExamDate != default;
                    bool isSubjectIdProvided = examSubject.SubjectId != default;
                    bool isExamTypeIdProvided = examSubject.ExamTypeId != default;
                    bool isExamStartTime = examSubject.ExamStartTime != default;
                    bool isExamEndTime = examSubject.ExamEndTime != default;

                    // Update properties of the existing exam subject only if they are provided in the updatedExamSubject
                    if (isExamTypeIdProvided)
                    {
                        // Check if the provided SubjectId exists
                        var existingExamType = await _context.dbsExamType
                            .FirstOrDefaultAsync(s => s.ExamTypeId == examSubject.ExamTypeId);

                        if (existingExamType == null)
                        {
                            // The provided SubjectId doesn't exist, so return BadRequest
                            return BadRequest($"SubjectId {examSubject.ExamTypeId} does not exist.");
                        }

                        existingExamSubject.SubjectId = examSubject.SubjectId;
                    }
                    if (isExamDateProvided)
                    {
                        existingExamSubject.ExamDate = examSubject.ExamDate;
                    }

                    if (isExamStartTime)
                    {
                        existingExamSubject.ExamStartTime = examSubject.ExamStartTime;
                    }

                    if (isExamEndTime)
                    {
                        existingExamSubject.ExamEndTime = examSubject.ExamEndTime;
                    }
                    if (isSubjectIdProvided)
                    {
                        // Check if the provided SubjectId exists
                        var existingSubject = await _context.dbsSubject
                            .FirstOrDefaultAsync(s => s.SubjectId == examSubject.SubjectId);

                        if (existingSubject == null)
                        {
                            // The provided SubjectId doesn't exist, so return BadRequest
                            return BadRequest($"SubjectId {examSubject.SubjectId} does not exist.");
                        }

                        existingExamSubject.SubjectId = examSubject.SubjectId;
                    }

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

        // POST: api/ExamSubjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostExamSubject(CreateExamSubjectVM examSubjectRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var examSubject = new ExamSubject
                    {
                        SubjectId = examSubjectRequest.SubjectId,
                        ExamScheduleStandardId = examSubjectRequest.ExamScheduleStandardId,
                        ExamDate = examSubjectRequest.ExamDate,
                        ExamStartTime = examSubjectRequest.ExamStartTime,
                        ExamEndTime = examSubjectRequest.ExamEndTime,
                        ExamTypeId = examSubjectRequest.ExamTypeId
                    };
                    _context.dbsExamSubject.Add(examSubject);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetExamSubject", new { id = examSubject.ExamSubjectId }, examSubject);

                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/ExamSubjects/5
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


    }

}
