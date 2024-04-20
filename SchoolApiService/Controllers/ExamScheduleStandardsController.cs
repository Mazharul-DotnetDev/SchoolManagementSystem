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
    public class ExamScheduleStandardsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public ExamScheduleStandardsController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/ExamScheduleStandards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamScheduleStandard>>> GetdbsExamScheduleStandard()
        {
            var examScheduleStandard = await _context.dbsExamScheduleStandard
                .Include(es => es.Standard)
                .Include(es => es.ExamSubjects)
                .ThenInclude(esSj => esSj.Subject)
                .AsNoTracking()
                .ToListAsync();

            return examScheduleStandard;
        }

        // GET: api/ExamScheduleStandards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamScheduleStandard>> GetExamScheduleStandard(int id)
        {
            var examScheduleStandard = await _context.dbsExamScheduleStandard
                .Include(es => es.Standard)
                .Include(es => es.ExamSubjects)
                .ThenInclude(esSj => esSj.Subject)
                .AsNoTracking()
                .FirstOrDefaultAsync(es => es.ExamScheduleStandardId == id);

            if (examScheduleStandard == null)
            {
                return NotFound();
            }

            return examScheduleStandard;
        }

        // PUT: api/ExamScheduleStandards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamScheduleStandard(int id, UpdateExamScheduleStandardVM request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var existingESStandard = await _context.dbsExamScheduleStandard.FirstOrDefaultAsync(es => es.ExamScheduleStandardId == id);

                    if (existingESStandard == null)
                    {
                        return NotFound($"ESStandard with ID {id} not found.");
                    }

                    if (existingESStandard.StandardId != request.StandardId)
                    {
                        var examSubjects = await _context.dbsExamSubject.Where(it => it.ExamScheduleStandardId == id).ToListAsync();
                        _context.dbsExamSubject.RemoveRange(examSubjects);
                    }
                    existingESStandard.StandardId = request.StandardId;
                    existingESStandard.ExamScheduleId = request.ExamScheduleId;
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();

                    return Ok(existingESStandard);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }



        }

        // POST: api/ExamScheduleStandards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostExamScheduleStandard(CreateExamScheduleStandardVM request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (
                            await _context.dbsExamScheduleStandard.AnyAsync(it =>
                            it.ExamScheduleId == request.ExamScheduleId &&
                            it.StandardId == request.StandardId
                            )
                        ) throw new Exception("Exam schedule standard already exist.");

                    var examScheduleStandard = new ExamScheduleStandard
                    {
                        ExamScheduleId = request.ExamScheduleId,
                        StandardId = request.StandardId
                    };

                    await _context.dbsExamScheduleStandard.AddAsync(examScheduleStandard);
                    await _context.SaveChangesAsync();

                    List<ExamSubject> examSubjects = [];
                    foreach (var examSubject in request.ExamSubjects)
                    {
                        if (request.StandardId == await _context.dbsSubject.Where(it => it.SubjectId == examSubject.SubjectId).Select(it => it.StandardId).SingleOrDefaultAsync())
                        {
                            examSubjects.Add(new ExamSubject
                            {
                                ExamDate = examSubject.ExamDate,
                                ExamStartTime = examSubject.ExamStartTime,
                                ExamEndTime = examSubject.ExamEndTime,
                                SubjectId = examSubject.SubjectId,
                                ExamScheduleStandardId = examScheduleStandard.ExamScheduleStandardId,
                                ExamTypeId = examSubject.ExamTypeId,
                            });
                        }
                    }
                    await _context.dbsExamSubject.AddRangeAsync(examSubjects);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    _context.dbsExamScheduleStandard.Add(examScheduleStandard);
                    await _context.SaveChangesAsync();


                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        // DELETE: api/ExamScheduleStandards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamScheduleStandard(int id)
        {
            var examScheduleStandard = await _context.dbsExamScheduleStandard.FindAsync(id);
            if (examScheduleStandard == null)
            {
                return NotFound();
            }

            _context.dbsExamScheduleStandard.Remove(examScheduleStandard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamScheduleStandardExists(int id)
        {
            return _context.dbsExamScheduleStandard.Any(e => e.ExamScheduleStandardId == id);
        }
    }
}
